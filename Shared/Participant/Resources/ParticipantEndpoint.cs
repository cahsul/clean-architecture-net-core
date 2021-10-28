using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Participant.Resources
{
    public class ParticipantEndpoint
    {
        public static class Participant
        {
            public const string Create = "/" + nameof(Participant) + "/" + nameof(Create);
            public const string Update = "/" + nameof(Participant) + "/" + nameof(Update);
            public const string Delete = "/" + nameof(Participant) + "/" + nameof(Delete);
            public const string GetParticipants = "/" + nameof(Participant) + "/" + nameof(GetParticipants);
            public const string GetParticipant = "/" + nameof(Participant) + "/" + nameof(GetParticipant);
        }
    }
}
