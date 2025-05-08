using System.Collections.Immutable;

namespace Homework10._3
{
    internal class Part2 : PartBase
    {
        public override void AddPart(ImmutableList<string>? strings)
        {
            if (strings == null)
            {
                return;
            }

            Poem = strings.AddRange(["А это пшеница,",
                    "Которая в темном чулане хранится",
                    "В доме,",
                    "Который построил Джек."]);
        }
    }
}
