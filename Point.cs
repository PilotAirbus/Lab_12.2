namespace Lab12
{
    public class Point<T> where T : ICloneable
    {
        public T? Data { get; set; } //само значение элемента
        public Point<T>? Next { get; set; } //ссылка на предыдущий элемент списка
        public Point<T>? Prev { get; set; } //ссылка на следующий элемент списка

        //конструктор без параметров
        public Point()
        {
            Data = default(T);
            Next = null;
            Prev = null;
        }

        //конструктор с параметром для заполнения поля Data
        public Point(T info)
        {
            Data = info;
            Next = null;
            Prev = null;
        }

        public override string ToString()
        {
            return Data?.ToString() ?? "null"; //если в Data будет храниться что-то отличное от null,
                                               //то будет возвращена возвращена строка с этим объектом, иначе будет возвращено null
        }
    }
}
