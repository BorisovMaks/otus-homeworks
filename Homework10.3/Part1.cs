using System.Collections.Immutable;

namespace Homework10._3
{
    internal class Part1 : PartBase
    {
        public Part1()
        {
            
        }

        public override void AddPart(ImmutableList<string>? strings)
        {
            if (strings == null)
            {
                return;
            }

            Poem = strings.AddRange(["Вот дом,", "Который построил Джек."]);
        }
    }
}
