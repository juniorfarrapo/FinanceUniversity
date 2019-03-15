using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinanceUniversity.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int SubjectID { get; set; }
        public int StudentID { get; set; }

        [Range(0, 10)]
        [DisplayFormat(NullDisplayText = "No grade")]
        public float? Grade { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }

    }
}