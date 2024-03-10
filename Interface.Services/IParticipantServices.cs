﻿using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Services
{
	public interface IParticipantServices
	{
		IEnumerable<ParticipantServiceDto> GetAll();
	}
}
