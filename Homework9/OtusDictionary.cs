namespace Homework9
{
    internal class OtusDictionary
    {
        private KeyValue[] _data;
        private readonly int _capacity = 32;
        public OtusDictionary()
        {
            _data = new KeyValue[_capacity];
        }

        public void Add(int key, string? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Значение аргумента value не может быть null", nameof(key));
            }
            int index = GetIndex(key);

            if (_data[index] != null)
            {
                if (_data[index].Key == key)
                {
                    throw new ArgumentException($"Нельзя добавить ключ {key}, элемент с таким ключом уже существует ", nameof(key));
                }
                Grow();
                Add(key, value);
                return;
            }
            _data[index] = new KeyValue(key, value);
        }

        public string? Get(int key)
        {
            var index = GetIndex(key);
            if (_data[index].Key != key)
            {
                var ex = new KeyNotFoundException($"Ключ {key} не найден в коллекции");
                Console.WriteLine($"Получение несуществующего значения элемента коллекции {key}", ex);
                return null;
            }
            return _data[index].Key == key ? _data[index].Value : null;
        }

        public int GetIndex(int key)
        {
            return Math.Abs(key % _data.Length);
        }

        private void Grow()
        {
            var currentData = _data;
            _data = new KeyValue[currentData.Length * 2];

            foreach (var item in currentData)
            {
                if (item != null)
                {
                    int newIndex = GetIndex(item.Key);
                    _data[newIndex] = item;
                }
            }
        }

        public string? this[int index]
        {
            get => Get(index);
            set => Add(index, value);
        }

        private class KeyValue
        {
            public int Key { get; }
            public string Value { get; }
            public KeyValue(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
