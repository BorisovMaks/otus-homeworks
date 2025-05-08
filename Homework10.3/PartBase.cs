using System.Collections.Immutable;

namespace Homework10._3
{
    public abstract class PartBase
    {
        public ImmutableList<string>? Poem { get; set; }

        public abstract void AddPart(ImmutableList<string>? strings);
    }
}