﻿
$(document).ready(function () {
    //добавить студента
    $('#addSt').click(function () {
        $("#partialDiv").load('/Admin/AddStudent');
    });

    //добавить преподавателя
    $('#addT').click(function () {
        $("#partialDiv").load('/Admin/AddTeacher');
    })
    //добавить предмет
    $('#addSb').click(function () {
        $("#partialDiv").load('/Admin/AddSubject');
    })
    //все студенты
    $('#allSt').click(function () {
        $("#partialDiv").load('/Admin/ShowStudents');
    })
    //все преподаватели
    $('#allT').click(function () {
        $("#partialDiv").load('/Admin/ShowTeachers');
    })
    //все предметы
    $('#allSb').click(function () {
        $("#partialDiv").load('/Admin/ShowSubjects');
    })

    //получение айди предмета преподавателя в списке его предметов
    $('#list li').click(function () {
        const subId = $(this).attr("data-id");
        $.ajax({
            type: "GET",
            //url: "/Marks/Jurnal?id=" + subId,
            data: { 'id': subId },
            cache: false,
            async: true,
            success: function (result) {
                window.location.href = "/Marks/Jurnal?id=" + subId;
            }
        });
    })

    //модальное окно добавления фото
    $('#openIconModal').click(function () {
        $('#iconModal').modal('show');
    });

    //модальное окно добавления предмета
    $('#addLessModal').click(function () {
        $('#lessModal').modal('show');
    });

    //обновление оценки в журнале
    $('td').bind('dblclick', function () {
        if (!$(this).has('input').length) {
            const input = $('<input/>', {
                'type': 'text',
                'value': $(this).html(),
                blur: function () {
                    const newValue = $(this).val();
                    const markID = $(this).attr('data-idsm');
                    $.ajax({
                        type: "PUT",
                        url: "/Marks/Jurnal/updateMark",
                        data: {
                            'id': markID,
                            'value': newValue
                        }, 
                        cache: false,
                        async: true,
                        success: function (result) {
                            alert(result.message)
                        },
                        error: function (error) {
                            alert(error);
                        }
                    });
                    $(this).replaceWith(newValue);
                }
            });
            $(this).empty();
            $(this).append(input);
        }
    });

});



