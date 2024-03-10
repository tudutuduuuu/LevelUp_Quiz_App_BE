using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
    public partial class Participant
    {
		public int ParticipantId { get; set; }
		public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Score { get; set; }
        public int TimeTaken { get; set; }
    }
}
