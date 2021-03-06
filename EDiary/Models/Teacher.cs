using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EDiary.Models
{
    public class Teacher
    {
        [Key]
        public int teacherId { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(30)]
        [Required]
        public string teacherSurname { get; set; }

        [Display(Name = "Имя")]
        [StringLength(30)]
        [Required]
        public string teacherName { get; set; }

        [Display(Name = "Отчество")]
        [StringLength(30)]
        public string teacherLastname { get; set; }

        [Display(Name = "Аватарка")]
        public byte[] teacherPic { get; set; }

        [Display(Name = "Эмодзи-статус")]
        public int? teacherStatus { get; set; }

        [Required]
        public string teacherUser { get; set; }

        [ForeignKey("teacherUser")]
        public IdentityUser user { get; set; }

        [ForeignKey("teacherStatus")]
        public EmojiStatus status { get; set; }
    }
}
