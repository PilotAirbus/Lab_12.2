namespace Lab12
{
    public class Table<T>
    {
        int defaultLength = 10;
        public TablePoint<T>[]? set;

        public int Count => set.Length; // размер таблицы, но не количество элементов

        public bool IsReadOnly => false;

        public Table()
        {
            set = new TablePoint<T>[defaultLength];
        }

        public void Add(T item)
        {
            if (item == null)
                throw new Exception("Ссылка для добавления пустая");

            int index = Math.Abs(item.GetHashCode()) % Count;

            if (set[index] == null)
            {
                set[index] = new TablePoint<T>(item);
            }

            else // идем по цепочке
            {
                TablePoint<T> current = set[index];
                while (current.Next != null)
                {
                    if (current.Data.Equals(item))
                        return;
                    current = current.Next;
                }
                if (!current.Data.Equals(item))
                    current.Next = new TablePoint<T>(item);
            }
        }
    
        public bool Contains(T item)
        {
            int index = Math.Abs(item.GetHashCode()) % Count;

            if (set[index] == null) // нет цепочки
                return false;

            TablePoint<T> current = set[index];
            if (current.Data.Equals(item)) // есть такой элемент
                return true;

            while (current != null) // идем по цепочке
            {
                if (current.Data.Equals(item)) // есть такой элемент
                    return true;
                current = current.Next;
            }

            return false; // дошли до конца цепочки
        }

        public bool Remove(T item)
        {
            if (!Contains(item))
                return false;

            int index = Math.Abs(item.GetHashCode()) % Count;
            TablePoint<T> current = set[index];

            if (current.Data.Equals(item)) // Удаляем первый элемент в цепочке
            {
                set[index] = current.Next;
                return true;
            }

                
            {
                if (current.Next.Data.Equals(item))
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }

            return false; // Элемент не найден (теоретически недостижимо из-за Contains)
        }

        public void Clear() 
        {
            set = null;
        }

        public void Print()
    {
        if (set == null)
        {
            throw new InvalidOperationException("Таблица не создана");
        }
        
        for (int i = 0; i < set.Length; i++)
        {
            Console.Write($"{i}: ");
            TablePoint<T> current = set[i];
            while (current != null)
            {
                Console.Write($"{current.Data} ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

    }
}
