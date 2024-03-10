using System;
using System.Collections.Generic;

namespace DTO.Model
{
    public partial class ParticipantServiceDto
    {
        public int ParticipantId { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Score { get; set; }
        public int TimeTaken { get; set; }
    }
}
