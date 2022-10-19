using System;
using System.Collections.Generic;

namespace Exam_Api.Models
{
    public partial class Question
    {
        public Question()
        {
            Exams = new HashSet<ExamTitle>();
        }

        public int Id { get; set; }
        public string Question1 { get; set; } = null!;
        public int AnswerId { get; set; }

        public virtual Answer Answer { get; set; } = null!;

        public virtual ICollection<ExamTitle> Exams { get; set; }
    }
}
