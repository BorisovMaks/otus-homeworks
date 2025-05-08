using System.Collections.Immutable;

namespace Homework10._3
{
    internal class Part4 : PartBase
    {
        public override void AddPart(ImmutableList<string>? strings)
        {
            if (strings == null)
            {
                return;
            }

            Poem = strings.AddRange([
                        "Вот кот,",
                        "Который пугает и ловит синицу,",
                        "Которая часто ворует пшеницу,",
                        "Которая в темном чулане хранится",
                        "В доме,",
                        "Который построил Джек."]);
        }
    }
}
