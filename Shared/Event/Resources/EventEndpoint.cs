using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Event.Resources
{
    public class EventEndpoint
    {
        public static class Event
        {

            public const string Create = "/" + nameof(Event) + "/" + nameof(Create);
            public const string Update = "/" + nameof(Event) + "/" + nameof(Update);
            public const string Delete = "/" + nameof(Event) + "/" + nameof(Delete);
            public const string GetEvents = "/" + nameof(Event) + "/" + nameof(GetEvents);
            public const string GetEvent = "/" + nameof(Event) + "/" + nameof(GetEvent);
        }

        public static class EventSpeaker
        {
            public const string Create = "/" + nameof(EventSpeaker) + "/" + nameof(Create);
            public const string Update = "/" + nameof(EventSpeaker) + "/" + nameof(Update);
            public const string Delete = "/" + nameof(EventSpeaker) + "/" + nameof(Delete);
            public const string GetSpeakers = "/" + nameof(EventSpeaker) + "/" + nameof(GetSpeakers);
            public const string GetSpeakersByEvent = "/" + nameof(EventSpeaker) + "/" + nameof(GetSpeakersByEvent);
            public const string GetSpeaker = "/" + nameof(EventSpeaker) + "/" + nameof(GetSpeaker);
        }
    }
}
