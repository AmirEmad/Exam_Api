using System;
using System.Collections.Generic;

namespace Exam_Api.Models
{
    public partial class ExamTitle
    {
        public ExamTitle()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Question> Questions { get; set; }
    }
}
