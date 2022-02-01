﻿using EDiary.Models;
using EDiary.Service;
using EDiary.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EDiary.Controllers
{
    [Authorize(Roles = "student")]
    public class StudentController : Controller
    {
        EDContext context;
        private UserManager<IdentityUser> userManager;
        public StudentController(UserManager<IdentityUser> userManager, EDContext context) => (this.userManager, this.context) = (userManager, context);

        //представление ученика(имя)
        public IActionResult Student()
        {
            //средний балл
            ViewBag.averageMark = Math.Round((from st in context.students
                                              join sm in context.setMarks on st.studentId equals sm.studentId
                                              join mark in context.marks on sm.markId equals mark.markId
                                              where mark.mark != "н/б" && mark.mark != "н/а" && mark.mark != "зач" && mark.mark != "незач" && mark.mark != "н" && st.studentUser == userManager.GetUserId(User)
                                              select Convert.ToInt32(mark.mark)).Average(), 2);

            //ФИО учника
            var student = (from students in context.students
                           join aspusers in context.Users on students.studentUser equals aspusers.Id
                           where students.studentUser == userManager.GetUserId(User)
                           select new StudentModel
                           {
                               studentId = students.studentId,
                               studentSurname = students.studentSurname,
                               studentName = students.studentName,
                               studentLastname = students.studentLastname,
                               studentPic = students.studentPic,
                               studentStatus = students.status.emoji
                           }).ToList();
            //предметы
            var studentSubject = (from sub in context.subjects
                                  join sT in context.subjectTaughts on sub.subjectId equals sT.subjectId
                                  join gr in context.groups on sT.groupId equals gr.groupId
                                  join st in context.students on gr.groupId equals st.studentGroup
                                  join aspusers in context.Users on st.studentUser equals aspusers.Id
                                  where st.studentUser == userManager.GetUserId(User)
                                  select new SubjectGroupModel
                                  {
                                      tsubjectId = sT.tsubjectId,
                                      subjectName = sub.subjectName,
                                      subIcon = sub.Icon.subjectPicture
                                  }).ToList();
            //лабы
            var studentLabs = (from students in context.students
                               join aspusers in context.Users on students.studentUser equals aspusers.Id
                               join subGr in context.subgroups on students.studentSubgroup equals subGr.subgroupId
                               join labs in context.labs on subGr.subgroupId equals labs.subgroupId
                               join sT in context.subjectTaughts on labs.tsubjectId equals sT.tsubjectId
                               join gr in context.groups on sT.groupId equals gr.groupId
                               join sub in context.subjects on sT.subjectId equals sub.subjectId
                               where students.studentUser == userManager.GetUserId(User)
                               select new SubjectGroupModel
                               {
                                   subjectName = labs.labName.Replace(", 2-ая подгруппа", "").Replace(", 1-ая подгруппа", ""),
                                   labaId = labs.labId,
                                   tsubjectId = sT.tsubjectId,
                                   subIcon = sub.Icon.subjectPicture
                               }).ToList();

            //задачи
            var studentTasks = (from students in context.students
                                join aspusers in context.Users on students.studentUser equals aspusers.Id
                                join subGr in context.subgroups on students.studentSubgroup equals subGr.subgroupId
                                join labs in context.labs on subGr.subgroupId equals labs.subgroupId
                                join sT in context.subjectTaughts on labs.tsubjectId equals sT.tsubjectId
                                join gr in context.groups on sT.groupId equals gr.groupId
                                join sub in context.subjects on sT.subjectId equals sub.subjectId
                                where students.studentUser == userManager.GetUserId(User)
                                select new SubjectGroupModel
                                {
                                    subjectName = labs.labName.Replace("(лабораторная, 2-ая подгруппа)", "").Replace("(лабораторная, 1-ая подгруппа)", ""),
                                    labaId = labs.labId,
                                    tsubjectId = sT.tsubjectId,
                                    zachCount = context.marks.Join(context.setMarks, mark => mark.markId, sM => sM.markId, (mark, sM) => new { mark, sM })
                                                                       .Join(context.lessons, sM => sM.sM.lessonId, less => less.lessonId, (sM, less) => new { sM, less })
                                                                       .Join(context.subjectTaughts, less => less.less.tsubjectId, sT => sT.tsubjectId, (less, sT) => new { less, sT })
                                                                       .Join(context.labs, sT => sT.sT.tsubjectId, laba => laba.tsubjectId, (sT, laba) => new { sT, laba })
                                                                       .Where(m => m.sT.less.sM.mark.mark == "зач")
                                                                       .GroupBy(sT => sT.laba.labId)
                                                                       .Select(m => m.Count()).FirstOrDefault(),
                                    labaCount = labs.countLabs
                                }).ToList();
            var statuses = context.emojiStatuses.Take(8).ToList();
            var subLabs = studentSubject.Concat(studentLabs).OrderBy(x=>x.subjectName);
            AspStudentGroupModel studentSubjectGroup = new AspStudentGroupModel { students = student, subjects = subLabs, tasks = studentTasks, statuses = statuses};
            return View(studentSubjectGroup);
        }

        //добавление фотографии студента
        [HttpPost]
        public IActionResult AddPicture(AvatarStatusModel studentPicture)
        {
            context.Database.BeginTransaction();
            var student = context.students.Where(stId => stId.studentUser == userManager.GetUserId(User)).FirstOrDefault();
            byte[] pic = null;
            using (var binaryReader = new BinaryReader(studentPicture.Picture.OpenReadStream()))
            {
                pic = binaryReader.ReadBytes((int)studentPicture.Picture.Length);
            }
            student.studentPic = pic;
            context.students.Update(student);
            context.SaveChanges();
            context.Database.CommitTransaction();
            return RedirectToAction("Student", "Student");
        }

        //добавление эмоджи статуса
        [HttpPost]
        public IActionResult AddStatus(AvatarStatusModel studentStatus)
        {
            context.Database.BeginTransaction();
            var student = context.students.Where(stId => stId.studentUser == userManager.GetUserId(User)).FirstOrDefault();
            student.studentStatus = studentStatus.statusId;
            context.students.Update(student);
            context.SaveChanges();
            context.Database.CommitTransaction();
            return RedirectToAction("Student", "Student");
        }
    }
}
