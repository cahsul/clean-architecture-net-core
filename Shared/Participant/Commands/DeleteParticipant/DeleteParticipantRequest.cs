using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Shared.Participant.Commands.DeleteParticipant
{
    public class DeleteParticipantRequest
    {
        public Guid Id { get; set; }
    }
}
