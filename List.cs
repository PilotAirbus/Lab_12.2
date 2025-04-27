using ToolLibrary;

namespace Lab12
{
    public class List<T> where T : ICloneable
    {
        #region Поля и свойства

        public ShowData data = new ShowData();
        public Lab12.Point<T> begin; //начальный элемент списка

        /// <summary>
        /// Подсчет количества элементов списка
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0; //счетчик для подсчета количества элементов

                if (begin == null)  //если список пуст, то его первый элемент будет равен null
                {
                    return 0;
                }

                Lab12.Point<T> current = begin;

                while (current != null)
                {
                    count++; //увеличение счетчика
                    current = current.Next; //попытка перехода к следующему элементу списка
                }

                return count; //возвращаем полученное количество элементов списка
            }
        }

        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public List()
        {
            begin = null; //создается пустой список
        }

        #endregion

        #region Методы

        #region Добавление элементов

        /// <summary>
        /// Добавление элемента в конец списка или объявление его головой
        /// </summary>
        /// <param name="item">Добавляемый элемент</param>
        public void AddToEnd(T item)
        {
            Lab12.Point<T> newElement = new Lab12.Point<T>(item);

            //если список пуст, то помещаем добавляемый элемент в головной
            if (begin == null)
            {
                begin = newElement;
            }

            else
            {
                Add(newElement);
            }
        }

        /// <summary>
        /// Добавление элемента в конец списка
        /// </summary>
        /// <param name="newElement">Добавляемый элемент</param>
        public void Add(Lab12.Point<T> newElement)
        {
            Lab12.Point<T> current = begin; //начинаем обход списка с головы

            //доходим до конца списка
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newElement; //добавляем ссылку с последнего элемента на новый
            newElement.Prev = current; //добавляем ссылку с нового элемента на последний

        }

        /// <summary>
        /// Добавление элемента в начало списка
        /// </summary>
        /// <param name="newElement">Добавляемый элемент</param>
        public void AddToBegin(Lab12.Point<T> newElement)
        {
            // Устанавливаем поле Next у нового элемента
            newElement.Next = begin;

            // Проверяем, является ли список пустым
            if (begin != null)
            {
                // Если список не пустой, устанавливаем поле Prev у старого первого элемента
                begin.Prev = newElement;
            }

            // Обновляем указатель begin, чтобы новый элемент стал первым
            begin = newElement;
        }

        /// <summary>
        /// Добавление элемента в список по заданному индексу
        /// </summary>
        /// <param name="newElement">Добавляемый элемент</param>
        /// <param name="addIndex">индекс для добавления</param>
        public void AddToIndex(Lab12.Point<T> newElement, int addIndex)
        {

            if (addIndex < 0 || addIndex > Count)
            {
                throw new Exception("Индекс должен быть не меньше 0 и не больше количества элементов списка");
            }

            if (addIndex == 0) { AddToBegin(newElement); } //Добавление элемента в начало списка

            else
            {
                if (addIndex == Count) { Add(newElement); } //Добавление элемента в конец списка

                else
                {

                    int index = 0; //текущий индекс элемента списка
                    Lab12.Point<T> current = begin; //текущий элемент списка

                    //Идем до указанного индекса
                    while (index + 1 != addIndex)
                    {
                        current = current.Next;
                        index++;
                    }

                    Lab12.Point<T> nextElement = current.Next; // Запоминаем следующий после добавления элемент

                    current.Next = newElement;
                    newElement.Next = nextElement;

                    nextElement.Prev = newElement;
                    newElement.Prev = current;

                }
            }

        }

        #endregion

        #region Поиск элемента в списке

        /// <summary>
        /// Проверка наличия элемента в списке
        /// </summary>
        /// <param name="item">Проверяемый элемент</param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            Lab12.Point<T> current = begin; //Начинаем обход списка с начала

            while (current != null && !current.Data.Equals(item))
            {
                current = current.Next;
            }

            return current != null;
        }

        #endregion

        #region Удаление элементов

        /// <summary>
        /// Удаление элемента списка по значению инф поля
        /// </summary>
        /// <param name="item">Удаляемый элемент</param>
        /// <returns></returns>
        public bool RemoveByIndex(int index)
        {
            // Если список пустой или индекс некорректный, возвращаем false
            if (begin == null || index < 0 || index >= Count)
            {
                return false;
            }

            // Удаление головного элемента
            if (index == 0)
            {
                begin = begin.Next; // Обновляем головной элемент
                if (begin != null)
                {
                    begin.Prev = null; // Обнуляем ссылку Prev у нового головного элемента
                }
                return true;
            }

            // Поиск элемента для удаления
            Point<T>? current = begin;
            int currentIndex = 0;

            while (current != null && currentIndex != index - 1)
            {
                current = current.Next;
                currentIndex++;
            }

            // Если элемент не найден, возвращаем false
            if (current == null || current.Next == null)
            {
                return false;
            }

            // Удаляем элемент
            Point<T> toRemove = current.Next; // Элемент для удаления
            current.Next = toRemove.Next; // Обновляем ссылку Next у предыдущего элемента

            if (toRemove.Next != null)
            {
                toRemove.Next.Prev = current; // Обновляем ссылку Prev у следующего элемента
            }

            return true;
        }

        #endregion

        #region Очистка

        /// <summary>
        /// Очистка списка
        /// </summary>
        public void Clear()
        {
            begin = null;
        }

        #endregion

        #region Печать списка

        public void PrintList()
        {
            if (begin == null)
            {
                data.Print($"Список пуст");
            }

            Point<T>? current = begin;
            int count = 1;

            while (current != null)
            {
                data.Print($"Элемент {count++}: {current.Data.ToString()}");
                current = current.Next;
            }
        }

        #endregion

        #region Клонирование

        public object Clone()
        {
            // Создаем новый список для клонирования
            List<T> newList = new List<T>();

            // Проверяем, является ли исходный список пустым
            if (begin == null)
            {
                return null; // Если список пустой, возвращаем null
            }

            // Создаем новый узел для первого элемента списка и добавляем его в новый список
            newList.begin = new Lab12.Point<T>((T)((ICloneable)begin.Data).Clone());

            // Устанавливаем указатель на второй элемент исходного списка
            Lab12.Point<T>? current = begin.Next;

            // Проходим по всем оставшимся элементам исходного списка
            while (current != null)
            {
                // Создаем новый узел с данными текущего элемента
                Lab12.Point<T> newNode = new Lab12.Point<T>((T)((ICloneable)current.Data).Clone());

                // Добавляем новый узел в конец нового списка
                newList.Add(newNode);

                // Переходим к следующему элементу исходного списка
                current = current.Next;
            }

            // Возвращаем клонированный список
            return newList;
        }

        #endregion

        #endregion
    }
}
