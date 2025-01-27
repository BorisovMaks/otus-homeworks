using System.Text;

namespace Homework4
{
    internal class Stack
    {
        public int Size => CalculateSize();

        private int CalculateSize()
        {
            if (_stackItem == null)
            {
                return default;
            }

            var item = _stackItem;
            int counter = 0;
            while(item != null)
            {
                counter++;
                item = item.PreviousItem;
            }

            return counter;
        }

        private StackItem? _stackItem;

        public string? Top
        {
            get
            {
                if (_stackItem != null)
                {
                    return _stackItem.CurrentValue;
                }
                else 
                {
                    return null;
                } 
            }
        }

        public Stack(params string[] items)
        {
            for (int i = 0; i < items.Length; i++) 
            {
                if (i == 0)
                {
                    _stackItem = new StackItem(items[i], null);
                }
                else
                {
                    _stackItem = new StackItem(items[i], _stackItem);
                }
            }
        }

        public void PrintStackList()
        {
            StringBuilder stringBuilder = new();

            var item = _stackItem;

            while (item != null)
            {
                stringBuilder.Append(string.Format("'{0}', ", item.CurrentValue));
                item = item.PreviousItem;
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        /// <summary>
        /// Добавляет элемент в стек
        /// </summary>
        /// <param name="input"></param>
        public void Add(string? input)
        {
            if (_stackItem != null)
            {
                var newStackItem = new StackItem(input, _stackItem);
                newStackItem.PreviousItem = _stackItem;
                _stackItem = newStackItem;
            }
            else
            {
                _stackItem = new StackItem(input, null);
            }
        }

        /// <summary>
        /// Объединяет неограниченное количество Stack
        /// </summary>
        /// <param name="stacks">Принимает неограниченное количество параметров типа Stack</param>
        /// <returns>Новый стек с элементами каждого стека в порядке параметров, но сами элементы записаны в обратном порядке</returns>
        public static Stack Concat(params Stack[] stacks)
        {
            var output = new Stack();            

            for (int i = 0; i < stacks.Length; i++)
            {
                var itemsToAdd = stacks[i].GetStackItems();                

                for (int j = 0; j < itemsToAdd.Count; j++)
                {
                    output.Add(itemsToAdd[j].CurrentValue);
                }                
            }

            return output;
        }

        /// <summary>
        /// Извлекает верхний элемент и удаляет его из стека
        /// </summary>
        /// <returns></returns>
        /// <exception cref="TryPopStackException"></exception>
        public string? Pop()
        {
            if (_stackItem != null)
            {
                var outPut = _stackItem.CurrentValue;
                _stackItem = _stackItem.PreviousItem;
                return outPut;
            }
            else
            {
                throw new TryPopStackException("Стек пустой");
            }
        }

        /// <summary>
        /// Все элементы из s2 добавляются в s1 в обратном порядке
        /// </summary>
        /// <param name="s1">Stack1</param>
        /// <param name="s2">Stack2</param>
        /// <returns>Новый объединенный Stack</returns>
        public static Stack Merge(Stack s1, Stack s2)
        {
            var items1 = s1.GetStackItems();
            var items2 = s2.GetStackItems();

            var stack = new Stack(IEnumerableExtension.ReverseItems(items1.Select(x => x.CurrentValue)).ToArray());
            var coll = items2.Select(x => x.CurrentValue);

            foreach (var item in coll)
            {
                stack.Add(item);
            }

            return stack;
        }

        private List<StackItem> GetStackItems()
        {
            List<StackItem> items = new();
            var item = _stackItem;
            while (item != null)
            {
                items.Add(item);
                item = item.PreviousItem;
            }

            return items;
        } 

        private class StackItem 
        {
            public string? CurrentValue { get; set; } = null;
            public StackItem? PreviousItem { get; set; } = null;

            public StackItem(string? value, StackItem? previousItem)
            {
                CurrentValue = value;
                PreviousItem = previousItem;
            }
        }
    }
}
