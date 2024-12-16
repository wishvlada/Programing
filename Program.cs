
namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            void Start ()
            {
                Console.WriteLine(" ");
                Console.WriteLine("Выберете, что вы хотите сделать: ");
                Console.WriteLine("1. Посмотреть все дела");
                Console.WriteLine("2. Посмотреть запланированные дела");
                Console.WriteLine("3. Посмотреть выполненные дела");
                Console.WriteLine("4. Изменить статус дела");
                Console.WriteLine("5. Добавить дело");
                Console.WriteLine("6. Удалить дело");
                Console.WriteLine("7. Редактировать дело");
                Console.WriteLine("0. Выйти");
            }
            
            List<string> todos = new List<string>();
            List<string> todoscompleted = new List<string>();
            List<DateTime> time = new List<DateTime>();


            int option;
            do
            {  
                Start();
                Console.Write("Что вы хотите сделать? Введите номер: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        PrintAll();
                        break;
                    case 2:
                        Console.Clear();
                        PrintInProcess();
                        break;
                    case 3:
                        Console.Clear();
                        PrintCompleted();
                        break;
                    case 4:
                        Console.Clear();
                        ChangeStatus();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        AddToDo();
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        RemoveToDo();
                        Console.Clear();
                        break;
                    case 7:
                        Console.Clear();
                        ReadLine();
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Попробуйте еще раз");
                        Console.Clear();
                        break;
                }
            } while (option != 0);
            
            
            void PrintAll()
            {
                if (todos.Count == 0)
                { Console.WriteLine("У вас нет запланированных дел! Можете отдыхать!"); }
                PrintCompleted();
                PrintInProcess();

            }

            void PrintCompleted()
            {
                Console.WriteLine("Выполненные дела: ");
                if(todoscompleted.Count == 0)
                { Console.WriteLine("У вас нет выполненных дел! За работу!"); }
                for (int i = 0; i < todoscompleted.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{todoscompleted[i]} {time[i]}");
                }
                Console.WriteLine("---------------------------");
            }

            void PrintInProcess()
            {
                Console.WriteLine("Дела в процессе: ");
                if (todos.Count == 0)
                { Console.WriteLine("У вас нет запланированных дел! Можете отдыхать!"); }
                else
                {
                    for (int i = 0; i < todos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{todos[i]} {time[i]}");
                    }
                }
                Console.WriteLine("---------------------------");
            }


            void AddToDo()
            {
                Console.WriteLine("---------------------------");
                Console.Write("Запишите дело, которое хотите добавить: ");
                string newtodo = Console.ReadLine();
                todos.Add(newtodo);
                time.Add(DateTime.Now);
                Console.WriteLine("Дело успешно добавлено!");
            }

            void RemoveToDo()
            {
                Console.WriteLine("Выберете какое дело вы хотите удалить: завершенное(1) или незавершенное(2)");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        PrintCompleted();
                        Console.Write("Введите номер дела, которое хотите удалить: ");
                        var index1 = Console.ReadLine();
                            do
                            if (int.TryParse(index1, out int i) && i > 0 && i <= todoscompleted.Count)
                            {
                            Console.WriteLine($"Вы удалили дело: {todoscompleted[i - 1]}");
                            todos.RemoveAt(i - 1);
                            break;
                            }
                            while (true);
                    break;

                    case 2:
                        PrintInProcess();
                        Console.Write("Введите номер дела, которое хотите удалить: ");
                        var index2 = Console.ReadLine();
                        do
                            if (int.TryParse(index2, out int i) && i > 0 && i <= todos.Count)
                            {
                                Console.WriteLine($"Вы удалили дело: {todos[i - 1]}");
                                todos.RemoveAt(i - 1);
                                break;
                            }
                        while (true);
                    break;
                }    
            }
            
            void ChangeStatus()
            {
                PrintInProcess();
                Console.WriteLine("Какое дело вы выполнили?");
                var index = Console.ReadLine();
                do
                    if (int.TryParse(index, out int i) && i > 0 && i <= todos.Count)
                    {
                        Console.WriteLine($"Вы выполнили дело: {todos[i - 1]}");
                        todoscompleted.Add(todos[i - 1]);
                        todos.RemoveAt(i - 1);
                        PrintAll();
                        break;
                    }
                while (true);
            }
            void ReadLine()
            {
                PrintInProcess();
                Console.WriteLine("Какое дело вы хотите изменить?");
                var index = Console.ReadLine();
                if (int.TryParse(index, out int i) && i > 0 && i <= todos.Count)
                {
                    int pos = Console.CursorLeft;
                    Console.Write(todos[i - 1]);
                    ConsoleKeyInfo info;
                    List<char> chars = new List<char>();

                    while (true)
                    {
                        info = Console.ReadKey(true);
                        if (info.Key == ConsoleKey.Backspace && Console.CursorLeft > pos)
                        {
                            if (chars.Count != 0) chars.RemoveAt(chars.Count - 1);
                            Console.CursorLeft -= 1;
                            Console.Write(' ');
                            Console.CursorLeft -= 1;

                        }
                        else if (info.Key == ConsoleKey.Enter) { Console.Write(Environment.NewLine); break; }
                        else if (char.IsLetterOrDigit(info.KeyChar))
                        {
                            Console.Write(info.KeyChar);
                            chars.Add(info.KeyChar);
                        }
                    }
                    string charing = new string (chars.ToArray());
                    todos.RemoveAt(i - 1);
                    time.RemoveAt(i - 1);
                    todos.Add(charing);
                    time.Add(DateTime.Now);
                }
            }
        }
    }
}