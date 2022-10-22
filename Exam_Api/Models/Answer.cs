using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Exam_Api.Models
{
    public partial class Answer
    {
        public Answer()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Answer1 { get; set; } = null!;
        
        public virtual ICollection<Question>? Questions { get; set; }
    }
}
