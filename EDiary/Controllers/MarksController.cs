﻿using EDiary.Models;
using EDiary.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDiary.Controllers
{ 
    [Authorize]
    public class MarksController : Controller
    {
        EDContext context;
        public MarksController(EDContext context) => this.context = context;

        //представление журнала
        public IActionResult Jurnal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Jurnal(int id)
        {
            var subid = id;
            /*преподаватель, группа и предмет*/
            var teacherJurnal = (from user in context.users
                                 join tr in context.teachers on user.idUser equals tr.teacherUser
                                 join subTaught in context.subjectTaughts on tr.teacherId equals subTaught.teacherId
                                 where subTaught.tsubjectId == subid
                                 select new Users
                                 {
                                     userSurname = user.userSurname,
                                     userName = user.userName,
                                     userLastname = user.userLastname
                                 }).ToList();

            var groupJurnal = (from subTaught in context.subjectTaughts
                               join gr in context.groups on subTaught.groupId equals gr.groupId
                               where subTaught.tsubjectId == subid
                               select new collegeGroup
                               {
                                   groupName = gr.groupName,
                               }).ToList();

            var subjectJurnal = (from subTaught in context.subjectTaughts
                                 join st in context.subjects on subTaught.subjectId equals st.subjectId
                                 where subTaught.tsubjectId == subid
                                 select new Subject
                                 {
                                   subjectName = st.subjectName
                                 }).ToList();
            /*студенты*/
            var studentsJurnal = (from st in context.students
                                  join user in context.users on st.studentUser equals user.idUser
                                  select new Users
                                  {
                                      idUser = st.studentId,
                                      userSurname = user.userSurname,
                                      userName = user.userName,
                                      userLastname = user.userLastname
                                  }).ToList();

            var lessonJurnal = (from lesson in context.lessons
                                //join setMark in context.setMarks on lesson.lessonId equals setMark.lessonId
                                where lesson.tsubjectId == subid
                                select new Lesson
                                {
                                    lessonId = lesson.lessonId,
                                    lessonDate = lesson.lessonDate
                                }).ToList();

            var setMarks = (from setMark in context.setMarks
                            join st in context.students on setMark.studentId equals st.studentId
                            join lesson in context.lessons on setMark.lessonId equals lesson.lessonId
                            join mark in context.marks on setMark.markId equals mark.markId
                            join subTaught in context.subjectTaughts on lesson.tsubjectId equals subTaught.tsubjectId
                            where subTaught.tsubjectId == subid
                            select new setMark
                            {
                                mark = new Mark() { mark = mark.mark, markId = mark.markId},
                                lessonId = setMark.lessonId,
                                setmarkId = setMark.setmarkId,
                                studentId = setMark.studentId
                            }).ToList();

            var jurnal = new JurnalModel { Teachers = teacherJurnal, Groups = groupJurnal, Lessons = lessonJurnal, Students = studentsJurnal, Subjects = subjectJurnal, setMarks = setMarks };
            return View(jurnal);
        }
    }
}
