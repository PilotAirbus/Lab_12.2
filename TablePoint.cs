namespace Lab12
{
    public class TablePoint<T>
    {
        public T? Data { get; set; }
        public TablePoint<T>? Next { get; set; }

        public TablePoint()
        {
            Data = default(T);
            Next = null;
        }

        public TablePoint(T info)
        {
            Data = info;
            Next = null;
        }

        public override string ToString()
        {
            if (Data != null)

                return Data.ToString();

            else
                return "null";
        }

        public override int GetHashCode()
        {
            return Data?.GetHashCode() ?? 0; // оператор объединения с нулевым значением
        }
    }

}
