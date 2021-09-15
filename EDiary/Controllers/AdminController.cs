﻿using EDiary.Models;
using EDiary.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EDiary.Repositories;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EDiary.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        UserManager<IdentityUser> userManager;
        EDContext context;
        public AdminController(UserManager<IdentityUser> userManager, EDContext context) 
            => (this.userManager, this.context) = (userManager,context);

        //генерация пароля
        public static string generatePassword()
        {
            string pass = "";
            var r = new Random();
            while (pass.Length < 8)
            {
                char c = (char)r.Next(33, 125);
                if (char.IsLetterOrDigit(c))
                    pass += c;
            }
            AddStudentModel createStudentModel = new AddStudentModel();
            createStudentModel.studentPassword = pass;
            return createStudentModel.studentPassword;
        }

        //представление админа
        public IActionResult Admin()
        {
            return View();
        }

        //добавление студента
        public async Task<IActionResult> AddStudent(AddStudentModel createStudent)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityStudentUser = new IdentityUser { UserName = createStudent.studentLogin, PasswordHash=createStudent.studentPassword };
                Users studentUser = new Users {userSurname = createStudent.studentSurname, userName = createStudent.studentName, userLastname = createStudent.studentLastname, userId=identityStudentUser.Id };
                Student student = new Student {studentUser=studentUser.idUser, studentRole = "student", studentGroup = createStudent.studentGroup};
                var user = await userManager.CreateAsync(identityStudentUser, createStudent.studentPassword);
                if (user.Succeeded)
                {
                    return RedirectToAction("AddStudent");
                }
                else
                {
                    foreach (var error in user.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return PartialView("~/Views/Admin/_addStudent.cshtml", createStudent);
        }

        //добавление препода
        public IActionResult AddTeacher()
        {
            return PartialView("~/Views/Admin/_addTeacher.cshtml");
        }

        //добавление предмета
        public IActionResult AddSubject(AddSubjectModel addSubject)
        {
            var usersLINQ = from us in context.users
                            join tr in context.teachers on us.idUser equals tr.teacherUser
                            join aspuser in context.Users on us.userId equals aspuser.Id
                            where tr.teacherRole == "teacher"
                            select new Users
                            {
                                userLastname = us.userLastname,
                                userName = us.userName,
                                userSurname = us.userSurname
                            };
            var teachersLINQ = from tr in context.teachers
                               join us in context.users on tr.teacherUser equals us.idUser
                               join aspuser in context.Users on us.userId equals aspuser.Id
                               where tr.teacherRole == "teacher"
                               select new Teacher
                               {
                                   teacherId = tr.teacherId
                               };
            var groups = context.groups.ToList();
            var users = usersLINQ.ToList();
            var teachers = teachersLINQ.ToList();
            addSubject = new AddSubjectModel { Groups = groups, Users = users, Teachers = teachers };
            ViewBag.teacher = new SelectList(context.teachers, "teacherId", "teacherRole");
            return PartialView("~/Views/Admin/_addSubject.cshtml", addSubject);
        }
        public IActionResult CreateSubject(AddSubjectModel addSubject)
        {
            Subject subject = new Subject { subjectName = addSubject.subjectName };
            context.subjects.Add(subject);
            context.SaveChanges();
            subjectTaught subjectTaught = new subjectTaught { teacherId = addSubject.teacherId, groupId = addSubject.groupId, subjectId = subject.subjectId };
            context.subjectTaughts.Add(subjectTaught);
            context.SaveChanges();
            return RedirectToAction("Admin","Admin");
        }

        //таблица студентов
        public IActionResult ShowStudents()
        {
            var aspUserStudentGroup = from us in context.users
                                      join st in context.students on us.idUser equals st.studentUser
                                      join gr in context.groups on st.studentGroup equals gr.groupId
                                      join aspuser in context.Users on us.userId equals aspuser.Id
                                      where st.studentRole == "student"
                                      select new AspUserStudentGroup
                                      {
                                          studentId = st.studentId,
                                          studentLogin=aspuser.UserName,
                                          studentSurname=us.userSurname,
                                          studentName=us.userSurname,
                                          studentLastname=us.userLastname,
                                          groupName=gr.groupName
                                      };
            return PartialView("~/Views/Admin/_tableStudent.cshtml", aspUserStudentGroup);
        }
        
        //таблица преподов
        public IActionResult ShowTeachers()
        {
            var teachersTable = from tr in context.teachers
                                join us in context.users on tr.teacherUser equals us.idUser
                                join aspuser in context.Users on us.userId equals aspuser.Id
                                where tr.teacherRole=="teacher"
                                select new TableTeacherModel
                                {
                                    teacherId = tr.teacherId,
                                    teacherLastname = us.userLastname,
                                    teacherName = us.userName,
                                    teacherSurname = us.userSurname,
                                    teacherLogin = aspuser.UserName,
                                    subjectName = string.Join(", ", (from sub in context.subjects
                                                                     join us in context.users on tr.teacherUser equals us.idUser
                                                                     join aspuser in context.Users on us.userId equals aspuser.Id
                                                                     join subTaught in context.subjectTaughts on sub.subjectId equals subTaught.subjectId
                                                                     where subTaught.teacherId == tr.teacherId
                                                                     select sub.subjectName.Trim()).ToArray())
                                };
            return PartialView("~/Views/Admin/_tableTeacher.cshtml",teachersTable);
        }

        //таблица предметов
        public IActionResult ShowSubjects()
        {
            var teacherGroupSubject = (from tr in context.teachers
                                       join subTaught in context.subjectTaughts on tr.teacherId equals subTaught.teacherId
                                       join sub in context.subjects on subTaught.subjectId equals sub.subjectId
                                       join us in context.users on tr.teacherUser equals us.idUser
                                       join gr in context.groups on subTaught.groupId equals gr.groupId
                                       join aspusers in context.Users on us.userId equals aspusers.Id
                                       where tr.teacherRole == "teacher"
                                       select new TeacherGroupSubjectModel
                                       {
                                           tsubjectId = subTaught.tsubjectId,
                                           teacherSurname = us.userSurname,
                                           teacherName = us.userName,
                                           teacherLastname = us.userLastname,
                                           subjectName = sub.subjectName,
                                           groups = gr.groupName
                                       }).ToList();
            return PartialView("~/Views/Admin/_tableSubject.cshtml", teacherGroupSubject);
        }
    }
}
  