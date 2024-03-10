using System;
using System.Collections.Generic;

namespace Entity.Models
{
    public partial class Question
    {
        public int QnId { get; set; }
        public string QnInWords { get; set; } = null!;
        public string? ImageName { get; set; }
        public string Option1 { get; set; } = null!;
        public string Option2 { get; set; } = null!;
        public string Option3 { get; set; } = null!;
        public string Option4 { get; set; } = null!;
        public int Answer { get; set; }
    }
}
