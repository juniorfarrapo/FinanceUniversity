using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanceUniversity.Models
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Teacher Code")]
        public int TeacherID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Teacher")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Required]
        public float Salary { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}