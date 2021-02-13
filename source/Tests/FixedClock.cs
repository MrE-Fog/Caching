using System;
using Octopus.Time;

namespace Tests
{
    public class FixedClock : IClock
    {
        DateTimeOffset now;

        public FixedClock(DateTimeOffset now) => this.now = now;

        public void Set(DateTimeOffset value) => now = value;

        public void WindForward(TimeSpan time) => now = now.Add(time);

        public DateTimeOffset GetUtcTime() => Clone().now.ToUniversalTime();

        public DateTimeOffset GetLocalTime() => Clone().now.ToLocalTime();

        FixedClock Clone() => (FixedClock)MemberwiseClone();
    }
}