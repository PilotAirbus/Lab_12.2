using ToolLibrary;

namespace Lab12
{
    internal class Program
    {

        public static int GetNumber(string message, int leftBorder = 0, int rightBorder = 0)
        {
            string inputData;
            int number;
            bool isConverted = false;

            if (leftBorder == 0 && rightBorder == 0)
            {
                do
                {
                    Console.Write(message);
                    inputData = Console.ReadLine();
                    isConverted = int.TryParse(inputData, out number);

                    if (!isConverted) { Console.WriteLine("Ошибка ввода"); }

                } while (!isConverted);
            }

            else
            {
                do
                {
                    Console.Write(message);
                    inputData = Console.ReadLine();
                    isConverted = int.TryParse(inputData, out number);

                    if (!isConverted) { Console.WriteLine("Ошибка ввода"); }
                    if (number < leftBorder || number > rightBorder) { Console.WriteLine("Неверное значение"); }

                } while (!isConverted || number < leftBorder || number > rightBorder);
            }

            return number;
        }

        #region 1 часть

        #region Функции для меню

        /// <summary>
        /// Заполнение списка
        /// </summary>
        /// <param name="tools">Список</param>
        /// <param name="number">количество добавляемых элементов</param>
        /// <returns></returns>
        static void CreateList(List<Tool> tools, int number, Random rand)
        {
            tools.Clear();

            Point<Tool> head = new Point<Tool>(new Tool());

            tools.AddToBegin(head); //Задание головы списка

            //Заполнение списка
            for (int i = 1; i < number; i++)
            {
                int choice = rand.Next(1, 5);

                switch (choice)
                {
                    case 1:
                        {
                            Tool tool = new Tool();
                            tool.IRandomInit();

                            Point<Tool> element = new Point<Tool>(tool);
                            tools.Add(element);

                            break;
                        }

                    case 2:
                        {
                            ElTool tool = new ElTool();
                            tool.IRandomInit();

                            Point<Tool> element = new Point<Tool>(tool);
                            element.Data = (ElTool)element.Data;

                            tools.Add(element);
                            break;
                        }

                    case 3:
                        {
                            MeasTool tool = new MeasTool();
                            tool.IRandomInit();

                            Point<Tool> element = new Point<Tool>(tool);
                            element.Data = (MeasTool)element.Data;

                            tools.Add(element);
                            break;
                        }

                    case 4:
                        {
                            HandTool tool = new HandTool();
                            tool.IRandomInit();

                            Point<Tool> element = new Point<Tool>(tool);
                            element.Data = (HandTool)element.Data;

                            tools.Add(element);
                            break;
                        }
                }
            }
        }

        #endregion

        #region Меню

        static int FirstMenu()
        {
            Console.WriteLine("Выберете действие:");
            Console.WriteLine("    1)Создать список");
            Console.WriteLine("    2)Добавить элемент");
            Console.WriteLine("    3)Найти элемент");
            Console.WriteLine("    4)Удалить элемент");
            Console.WriteLine("    5)Очистить список");
            Console.WriteLine("    6)Распечатать список");
            Console.WriteLine("    7)Клонировать список");
            Console.WriteLine("    8)Завершить работу");

            return GetNumber("Выбранное действие: ", 1, 8);
        }

        static void WorkingFunction(ref List<Tool> tools)
        {
            //меню для выбора элемента
            static int ToolMenu()
            {
                Console.WriteLine("Выберете тип элемента: ");
                Console.WriteLine("    1)Tool");
                Console.WriteLine("    2)ElTool");
                Console.WriteLine("    3)HandTool");
                Console.WriteLine("    4)MeasTool");

                return GetNumber("Выбранный тип: ", 1, 4);
            }

            //выбор способа задания элемента
            static int TypeMenu()
            {
                Console.WriteLine("Выберете способ задания элемента: ");
                Console.WriteLine("    1)С клавиатуры");
                Console.WriteLine("    2)ДСЧ");

                return GetNumber("Выбранный способ: ", 1, 2);
            }

            int number = 0;
            Random rand = new Random();

            while (number != 8)
            {
                Console.Clear();
                number = FirstMenu();

                switch (number)
                {
                    case 1: //Создание
                        {
                            Console.WriteLine();
                            CreateList(tools, GetNumber("Введите количество добавляемых элементов: "), rand);
                            Console.Clear();
                            break;
                        }

                    case 2: //Добавление
                        {
                            if (tools.begin != null)
                            {

                                Console.WriteLine();

                                int choice = ToolMenu();
                                Console.WriteLine();

                                int type = TypeMenu();
                                Console.WriteLine();

                                int index = GetNumber("Введите номер элемента для добавления: ", 1, tools.Count + 1);

                                switch (type)
                                {
                                    case 1: //вручную
                                        {
                                            switch (choice)
                                            {
                                                case 1: //Tool
                                                    {
                                                        Tool tool = new Tool();
                                                        tool.IInit();

                                                        Point<Tool> element = new Point<Tool>(tool);
                                                        tools.AddToIndex(element, index - 1);

                                                        break;
                                                    }

                                                case 2: //ElTool
                                                    {
                                                        ElTool tool = new ElTool();
                                                        tool.IInit();

                                                        Point<Tool> element = new Point<Tool>(tool);
                                                        element.Data = (ElTool)element.Data;
                                                        tools.AddToIndex(element, index - 1);
                                                        break;
                                                    }

                                                case 3: //HandTool
                                                    {
                                                        HandTool tool = new HandTool();
                                                        tool.IInit();

                                                        Point<Tool> element = new Point<Tool>(tool);
                                                        element.Data = (HandTool)element.Data;
                                                        tools.AddToIndex(element, index - 1);
                                                        break;
                                                    }

                                                case 4: //MeasTool
                                                    {
                                                        MeasTool tool = new MeasTool();
                                                        tool.IInit();

                                                        Point<Tool> element = new Point<Tool>(tool);
                                                        element.Data = (MeasTool)element.Data;
                                                        tools.AddToIndex(element, index - 1);
                                                        break;

                                                    }
                                            }

                                            break;
                                        }

                                    case 2: //ДСЧ
                                        {
                                            switch (choice)
                                            {
                                                case 1: //Tool
                                                    {
                                                        Tool tool = new Tool();
                                                        tool.IRandomInit();

                                                        Point<Tool> element = new Point<Tool>(tool);
                                                        tools.AddToIndex(element, index - 1);

                                                        break;
                                                    }

                                                case 2: //ElTool
                                                    {
                                                        ElTool tool = new ElTool();
                                                        tool.IRandomInit();

                                                        Point<Tool> element = new Point<Tool>(tool);
                                                        element.Data = (ElTool)element.Data;
                                                        tools.AddToIndex(element, index - 1);
                                                        break;
                                                    }

                                                case 3: //HandTool
                                                    {
                                                        HandTool tool = new HandTool();
                                                        tool.IRandomInit();

                                                        Point<Tool> element = new Point<Tool>(tool);
                                                        element.Data = (HandTool)element.Data;
                                                        tools.AddToIndex(element, index - 1);
                                                        break;
                                                    }

                                                case 4: //MeasTool
                                                    {
                                                        MeasTool tool = new MeasTool();
                                                        tool.IRandomInit();

                                                        Point<Tool> element = new Point<Tool>(tool);
                                                        element.Data = (MeasTool)element.Data;
                                                        tools.AddToIndex(element, index - 1);
                                                        break;

                                                    }
                                            }

                                            break;
                                        }
                                }

                            }

                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Для начала создайте список");
                            }

                            Console.ReadLine();
                            Console.Clear();

                            break;
                        }

                    case 3: //Поиск
                        {
                            if (tools.begin != null)
                            {
                                Console.WriteLine();

                                int choice = ToolMenu();
                                Console.WriteLine();

                                switch (choice)
                                {

                                    case 1: //Tool
                                        {
                                            Tool tool = new Tool();
                                            tool.IInit();

                                            Point<Tool> element = new Point<Tool>(tool);
                                            Console.WriteLine();

                                            if (tools.Contains(tool)) { Console.WriteLine("Элемент найден"); }
                                            else { Console.WriteLine("Элемент не найден"); }

                                            break;
                                        }

                                    case 2: //ElTool
                                        {
                                            ElTool tool = new ElTool();
                                            tool.IInit();

                                            Point<Tool> element = new Point<Tool>(tool);
                                            element.Data = (ElTool)element.Data;
                                            Console.WriteLine();

                                            if (tools.Contains(tool)) { Console.WriteLine("Элемент найден"); }
                                            else { Console.WriteLine("Элемент не найден"); }

                                            break;
                                        }

                                    case 3: //HandTool
                                        {
                                            HandTool tool = new HandTool();
                                            tool.IInit();

                                            Point<Tool> element = new Point<Tool>(tool);
                                            element.Data = (HandTool)element.Data;
                                            Console.WriteLine();

                                            if (tools.Contains(tool)) { Console.WriteLine("Элемент найден"); }
                                            else { Console.WriteLine("Элемент не найден"); }
                                            break;
                                        }

                                    case 4: //MeasTool
                                        {
                                            MeasTool tool = new MeasTool();
                                            tool.IInit();

                                            Point<Tool> element = new Point<Tool>(tool);
                                            element.Data = (MeasTool)element.Data;
                                            Console.WriteLine();

                                            if (tools.Contains(tool)) { Console.WriteLine("Элемент найден"); }
                                            else { Console.WriteLine("Элемент не найден"); }
                                            break;

                                        }
                                }
                            }

                            else { Console.WriteLine("Для начала создайте список"); }

                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                    case 4: //Удаление
                        {
                            if (tools.begin != null)
                            {
                                Console.WriteLine();

                                int index = GetNumber("Введите номер элемента для удаления: ", 1, tools.Count);

                                if (tools.RemoveByIndex(index - 1)) { Console.WriteLine("Элемент удален"); }
                                else { Console.WriteLine("Элемент не найден"); }
                            }

                            else { Console.WriteLine("Для начала создайте список"); }

                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                    case 5: //Очистка
                        {
                            if (tools.begin != null)
                            {
                                tools.Clear();
                                Console.WriteLine();
                                Console.WriteLine("Список очищен");
                            }
                            else { Console.WriteLine("Для начала создайте список"); }

                            Console.ReadLine();
                            Console.Clear();

                            break;
                        }

                    case 6: //Печать
                        {
                            Console.WriteLine();
                            tools.PrintList();

                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                    case 7: //клонирование
                        {
                            Console.WriteLine();

                            if (tools.begin != null)
                            {

                                List<Tool> newList = (List<Tool>)tools.Clone();

                                Console.WriteLine("Изначальный массив: ");
                                tools.PrintList();
                                Console.WriteLine();

                                Console.WriteLine("Клонированный массив: ");
                                newList.PrintList();

                                Console.ReadLine();
                                Console.Clear();

                                newList.begin.Data.Name = "Стаместка";

                                Console.WriteLine("Изначальный массив: ");
                                tools.PrintList();
                                Console.WriteLine();

                                Console.WriteLine("Клонированный массив после изменения: ");
                                newList.PrintList();

                                newList.begin.Data.IRandomInit();

                            }
                            else { Console.WriteLine("Для начала создайте список"); }

                            Console.ReadLine();
                            Console.Clear();

                            break;
                        }
                }

            }
            Console.WriteLine();
            Console.WriteLine("Завершение работы");
        }

        #endregion

        #endregion

        #region 2 часть

        static int FirstTableMenu()
        {
            Console.WriteLine("Выберете действие:");
            Console.WriteLine("    1)Создать хеш-таблицу");
            Console.WriteLine("    2)Добавить элемент");
            Console.WriteLine("    3)Найти элемент");
            Console.WriteLine("    4)Удалить элемент");
            Console.WriteLine("    5)Очистить хеш-таблицу");
            Console.WriteLine("    6)Распечатать хеш-таблицу");
            Console.WriteLine("    7)Завершить работу");

            return GetNumber("Выбранное действие: ", 1, 7);
        }

        static void WorkingFunction(ref Table<Tool> tools)
        {
            //выбор способа задания элемента
            static int TypeMenu()
            {
                Console.WriteLine("Выберете способ задания элемента: ");
                Console.WriteLine("    1)С клавиатуры");
                Console.WriteLine("    2)ДСЧ");

                return GetNumber("Выбранный способ: ", 1, 2);
            }

            int number = 0;
            Random rand = new Random();


            while (number != 7)
            {
                //Console.Clear();
                number = FirstTableMenu();

                switch (number)
                {
                    case 1: //Создание
                        {
                            Console.WriteLine("Таблица создана");

                            tools = new Table<Tool>();
                            break;
                        }

                    case 2: //Добавление
                        {
                            if (tools != null)
                            {

                                Console.WriteLine();

                                int type = TypeMenu();
                                Console.WriteLine();

                                switch (type)
                                {
                                    case 1: //вручную
                                        {
                                            Tool tool = new Tool();
                                            tool.IInit();

                                            tools.Add(tool);

                                            break;
                                        }

                                    case 2: //ДСЧ
                                        {
                                            Tool tool = new Tool();
                                            tool.IRandomInit();

                                            tools.Add(tool);
                                            Console.WriteLine(tool);
                                            break;
                                        }
                                }

                            }

                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Для начала создайте хеш-таблицу");
                            }

                            Console.ReadLine();
                            Console.Clear();

                            break;
                        }

                    case 3: //Поиск
                        {
                            if (tools != null)
                            {
                                Console.WriteLine();

                                Tool tool = new Tool();
                                tool.IInit();

                                Console.WriteLine();

                                if (tools.Contains(tool)) { Console.WriteLine("Элемент найден"); }
                                else { Console.WriteLine("Элемент не найден"); }

                                break;
                            }

                            else { Console.WriteLine("Для начала создайте хеш-таблицу"); }

                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                    case 4: //Удаление
                        {
                            if (tools != null)
                            {
                                Console.WriteLine();


                                Tool tool = new Tool();
                                tool.IInit();

                                Console.WriteLine();

                                if (tools.Remove(tool)) { Console.WriteLine("Элемент удален"); }
                                else { Console.WriteLine("Элемент не найден"); }

                                break;
                            }

                            else { Console.WriteLine("Для начала создайте хеш-таблицу"); }

                            Console.Clear();
                            break;
                        }

                    case 5: //Очистка
                        {
                            if (tools != null)
                            {
                                tools.Clear();
                                Console.WriteLine();
                                Console.WriteLine("Хеш-таблица очищена");
                            }

                            else { Console.WriteLine("Для начала создайте хеш-таблицу"); }

                            Console.ReadLine();
                            Console.Clear();

                            break;
                        }

                    case 6: //Печать
                        {
                            try
                            {
                                Console.WriteLine();
                                if (tools == null)
                                {
                                    Console.WriteLine("Таблица не создана");
                                    break;
                                }
                                tools.Print();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                Console.ReadLine();
                                Console.Clear();
                            }
                            break;
                        }

                }

            }
            Console.WriteLine();
            Console.WriteLine("Завершение работы");
        }

        #endregion

        static void Main(string[] args)
        {
            //List<Tool> tools = new List<Tool>();
            //WorkingFunction(ref tools);

            Table<Tool> tools = null;
            WorkingFunction(ref  tools);
        }
    }
}
