using System.Collections.Immutable;

namespace Homework10._3
{
    internal class Part5 : PartBase
    {
        public override void AddPart(ImmutableList<string>? strings)
        {
            if (strings == null)
            {
                return;
            }

            Poem = strings.AddRange([
                        "Вот пес без хвоста,",
                        "Который за шиворот треплет кота,",
                        "Который пугает и ловит синицу,",
                        "Которая часто ворует пшеницу,",
                        "Которая в темном чулане хранится",
                        "В доме,",
                        "Который построил Джек."]);
        }
    }
}
