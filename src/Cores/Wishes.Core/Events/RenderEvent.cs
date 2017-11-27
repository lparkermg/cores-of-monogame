using System;
using System.Collections.Generic;
using System.Text;

namespace Wishes.Core.Events
{
    public class RenderEvent
    {
        public RenderData Data { get; }
        public DateTime EventDateTime { get; }

        public RenderEvent(RenderData data, DateTime eventDateTime)
        {
            Data = data;
            EventDateTime = eventDateTime;
        }

        public bool IsValid()
        {
            if (Data == null)
                return false;

            return Data.IsValid();
        }
    }
}
