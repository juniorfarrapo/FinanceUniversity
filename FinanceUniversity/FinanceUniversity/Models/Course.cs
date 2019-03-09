using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanceUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Course Code")]
        public int CourseID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Course")]
        public string Title { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}