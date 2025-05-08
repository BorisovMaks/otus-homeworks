using System.Collections.Immutable;

namespace Homework10._3
{
    internal class Part3 : PartBase
    {
        public override void AddPart(ImmutableList<string>? strings)
        {
            if (strings == null)
            {
                return;
            }

            Poem = strings.AddRange([
                        "А это веселая птица-синица",
                        "Которая часто ворует пшеницу,",
                        "Которая в темном чулане хранится",
                        "В доме,",
                        "Который построил Джек."]);
        }
    }
}
