
using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace tictactoe
{
    class Programm
    {
        static void Main(string[] args)
        {
            List<string> field = new List<string>();
            string a = " ";
            for (int j = 0; j < 9; j++) field.Add(a);

            void Print() // печататет поле
            {
                Console.WriteLine("*************");
                Console.WriteLine("*" + "   " + "*" + "   " + "*" + "   " + "*");
                Console.WriteLine("*  " + field[0] + "*  " + field[1] + "*  " + field[2] + "*");
                Console.WriteLine("*" + "   " + "*" + "   " + "*" + "   " + "*");
                Console.WriteLine("*************");
                Console.WriteLine("*" + "   " + "*" + "   " + "*" + "   " + "*");
                Console.WriteLine("*  " + field[3] + "*  " + field[4] + "*  " + field[5] + "*");
                Console.WriteLine("*" + "   " + "*" + "   " + "*" + "   " + "*");
                Console.WriteLine("*************");
                Console.WriteLine("*" + "   " + "*" + "   " + "*" + "   " + "*");
                Console.WriteLine("*  " + field[6] + "*  " + field[7] + "*  " + field[8] + "*");
                Console.WriteLine("*" + "   " + "*" + "   " + "*" + "   " + "*");
                Console.WriteLine("*************");
            }

            int IsVin(string A, string B, string C, string D, string E, string F, string J, string I, string K) // победа или ничья
            {
                if ((A == B && B == C && A == "X") || (D == E && E == F && F == "X") || (J == I && I == K && K == "X") || (A == D && D == J && J == "X") || (E == B && B == I && I == "X") || (F == K && K == C && K == "X") || (A == E && E == K && A == "X") || (E == J && J == C && J == "X"))
                { return 1; }
                if ((A == B && B == C && A == "O") || (D == E && E == F && F == "O") || (J == I && I == K && K == "O") || (A == D && D == J && J == "O") || (E == B && B == I && I == "O") || (F == K && K == C && K == "O") || (A == E && E == K && A == "O") || (E == J && J == C && J == "O"))
                { return 2; }
                if (A != " " && B != " " && C != " " && D != " " && E != " " && F != " " && J != " " && I != " " && K != " ")
                { return 3; }
                else { return 0; }
            }

            bool Checking(int move) // проверяет, свободна ли выбранная клетка
            {
                if (move == 11) { if (field[0] == " ") { return true; } else { return false; } }
                if (move == 12) { if (field[1] == " ") { return true; } else { return false; } }
                if (move == 13) { if (field[2] == " ") { return true; } else { return false; } }
                if (move == 21) { if (field[3] == " ") { return true; } else { return false; } }
                if (move == 22) { if (field[4] == " ") { return true; } else { return false; } }
                if (move == 23) { if (field[5] == " ") { return true; } else { return false; } }
                if (move == 31) { if (field[6] == " ") { return true; } else { return false; } }
                if (move == 32) { if (field[7] == " ") { return true; } else { return false; } }
                if (move == 33) { if (field[8] == " ") { return true; } else { return false; } }
                else { return false; }
            }

            bool AnotherChecking() // проверяет, можно ли походить так, чтобы победить или не дать победить сопернику
            {
                if (((field[0] == field[1] && field[0] != " ") || (field[4] == field[6] && field[6] != " ") || (field[5] == field[8] && field[5] != " ")) && field[2] == " ") { return true; }
                if (((field[3] == field[4] && field[3] != " ") || (field[2] == field[8] && field[2] != " ")) && field[5] == " ") { return true; }
                if (((field[6] == field[7] && field[7] != " ") || (field[2] == field[5] && field[5] != " ") || (field[0] == field[4] && field[0] != " ")) && field[8] == " ") { return true; }
                if (((field[0] == field[2] && field[0] != " ") || (field[4] == field[7] && field[4] != " ")) && field[1] == " ") { return true; }
                if (((field[3] == field[5] && field[5] != " ") || (field[1] == field[7] && field[7] != " ") || (field[0] == field[8] && field[0] != " ") || field[2] == field[6] && field[2] != " ") && field[4] == " ") { return true; }
                if (((field[4] == field[1] && field[4] != " ") || (field[8] == field[6] && field[8] != " ")) && field[7] == " ") { return true; }
                if (((field[2] == field[1] && field[2] != " ") || (field[3] == field[6] && field[3] != " ") || (field[4] == field[8] && field[4] != " ")) && field[0] == " ") { return true; }
                if (((field[0] == field[6] && field[0] != " ") || (field[4] == field[5] && field[5] != " ")) && field[3] == " ") { return true; }
                if (((field[7] == field[8] && field[7] != " ") || (field[0] == field[3] && field[0] != " ") || (field[2] == field[4] && field[4] != " ")) && field[6] == " ") { return true; }
                else { return false; }
            }

            void TheMindAI(string A) // компьютер ходит так, чтобы победить или не дать победить сопернику
            {
                if (((field[0] == field[1] && field[0] != " ") || (field[4] == field[6] && field[6] != " ") || (field[5] == field[8] && field[5] != " ")) && field[2] == " ") { field[2] = A; }
                else if (((field[3] == field[4] && field[3] != " ") || (field[2] == field[8] && field[2] != " ")) && field[5] == " ") { field[5] = A; }
                else if (((field[6] == field[7] && field[7] != " ") || (field[2] == field[5] && field[5] != " ") || (field[0] == field[4] && field[0] != " ")) && field[8] == " ") { field[8] = A; }
                else if (((field[0] == field[2] && field[0] != " ") || (field[4] == field[7] && field[4] != " ")) && field[1] == " ") { field[1] = A; }
                else if (((field[3] == field[5] && field[5] != " ") || (field[1] == field[7] && field[7] != " ") || (field[0] == field[8] && field[0] != " ") || field[2] == field[6] && field[2] != " ") && field[4] == " ") { field[4] = A; }
                else if (((field[4] == field[1] && field[4] != " ") || (field[8] == field[6] && field[8] != " ")) && field[7] == " ") { field[7] = A; }
                else if (((field[2] == field[1] && field[2] != " ") || (field[3] == field[6] && field[3] != " ") || (field[4] == field[8] && field[4] != " ")) && field[0] == " ") { field[0] = A; }
                else if (((field[0] == field[6] && field[0] != " ") || (field[4] == field[5] && field[5] != " ")) && field[3] == " ") { field[3] = A; }
                else if (((field[7] == field[8] && field[7] != " ") || (field[0] == field[3] && field[0] != " ") || (field[2] == field[4] && field[4] != " ")) && field[6] == " ") { field[6] = A; }
            }

            bool TheMove(int move, string A) // ход
            {
                if (move == 11) { if (Checking(move) == true) { field[0] = A; return true; } else { return false; } }
                if (move == 12) { if (Checking(move) == true) { field[1] = A; return true; } else { return false; } }
                if (move == 13) { if (Checking(move) == true) { field[2] = A; return true; } else { return false; } }
                if (move == 21) { if (Checking(move) == true) { field[3] = A; return true; } else { return false; } }
                if (move == 22) { if (Checking(move) == true) { field[4] = A; return true; } else { return false; } }
                if (move == 23) { if (Checking(move) == true) { field[5] = A; return true; } else { return false; } }
                if (move == 31) { if (Checking(move) == true) { field[6] = A; return true; } else { return false; } }
                if (move == 32) { if (Checking(move) == true) { field[7] = A; return true; } else { return false; } }
                if (move == 33) { if (Checking(move) == true) { field[8] = A; return true; } else { return false; } }
                else { return false; }
            }

            Console.WriteLine("Введите режим: игрок-игрок или игрок-компьютер");
            string mode = Console.ReadLine();
            // режим "игрок-игрок"
            if (mode == "игрок-игрок")
            {
                Print(); // выводит пока пустое поле
                for (int x = 0; x < 100000; x++)
                {

                    // Ход игрока А
                    Console.WriteLine("Ход игрока А");
                    Console.Write("Введите строку ");
                    string rowa = Console.ReadLine();
                    Console.Write("Введите столбец ");
                    string columna = Console.ReadLine();
                    int movea = Convert.ToInt32(rowa + columna);
                    if (TheMove(movea, "X") == false) { Console.WriteLine("Уже занято. Начните заново"); break; } else { TheMove(movea, "X"); }
                    //игрок вводит номер строки и столбца, и если там пусто, то появляется крестик. Если же это место занято, игра заканчивается
                    if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 1) { Console.Clear(); Print(); Console.WriteLine("Победил игрок А"); break; }
                    if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 2) { Console.Clear(); Print(); Console.WriteLine("Победил игрок B"); break; }
                    if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 3) { Console.Clear(); Print(); Console.WriteLine("Ничья!"); break; }
                    Console.Clear();
                    Print();


                    //Ход игрока В
                    Console.WriteLine("Ход игрока B");
                    Console.Write("Введите строку ");
                    string rowb = Console.ReadLine();
                    Console.Write("Введите столбец ");
                    string columnb = Console.ReadLine();
                    int moveb = Convert.ToInt32(rowb + columnb);
                    if (TheMove(moveb, "O") == false) { Console.WriteLine("Уже занято. Начните заново"); break; } else { TheMove(moveb, "O"); };
                    //игрок вводит номер строки и столбца, и если там пусто, то появляется крестик. Если же это место занято, игра заканчивается
                    if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 1) { Console.Clear(); Print(); Console.WriteLine("Победил игрок А"); break; }
                    if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 2) { Console.Clear(); Print(); Console.WriteLine("Победил игрок B"); break; }
                    if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 3) { Console.Clear(); Print(); Console.WriteLine("Ничья!"); break; }
                    Console.Clear();
                    Print();
                }
            }


            // режим "игрок-компьютер"
            if (mode == "игрок-компьютер")
            {
                Console.WriteLine("Выберете за кого вы играете: Х или О (Русская раскладка, заглавная буква) ");
                string mode1 = Console.ReadLine();

                //Если игрок ходит первым (играет за Х)
                if (mode1 == "Х")
                {
                    Print();
                    for (int x = 0; x < 100000; x++)
                    {
                        Console.Write("Введите строку ");
                        string rowx = Console.ReadLine();
                        Console.Write("Введите столбец ");
                        string columnx = Console.ReadLine();
                        int move = Convert.ToInt32(rowx + columnx);
                        if (TheMove(move, "X") == false) { Console.WriteLine("Уже занято. Начните заново"); break; } else { TheMove(move, "X"); }
                        if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 1) { Console.Clear(); Print(); Console.WriteLine("Победил Игрок!"); break; }
                        if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 2) { Console.Clear(); Print(); Console.WriteLine("Победил Компьютер!"); break; }
                        if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 3) { Console.Clear(); Print(); Console.WriteLine("Ничья!"); break; }
                        Console.Clear();
                        Print();

                        bool flag = AnotherChecking();
                        if (flag == true) { TheMindAI("O"); flag = false; }
                        else if (flag == false)
                        {
                            while (flag == false)
                            {
                                Random r = new Random();
                                int[] array = { 11, 12, 13, 21, 22, 23, 31, 32, 33 };
                                int res = r.Next(array.Length);
                                int moveai = array[res];
                                flag = TheMove(moveai, "O");
                            }
                            flag = false;
                        }
                        if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 1) { Console.Clear(); Print(); Console.WriteLine("Победил Игрок!"); break; }
                        if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 2) { Console.Clear(); Print(); Console.WriteLine("Победил Компьютер!"); break; }
                        if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 3) { Console.Clear(); Print(); Console.WriteLine("Ничья!"); break; }
                        Console.Clear();
                        Print();
                    }
                }


                // Игрок ходит вторым (играет за "О")
                if (mode1 == "О")
                {
                    Print();
                    for (int x = 0; x < 100000; x++)
                    {
                        bool flag = AnotherChecking();
                        if (flag == true) { TheMindAI("Х"); flag = false; }
                        else if (flag == false)
                        {
                            while (flag == false)
                            {
                                Random r = new Random();
                                int[] array = { 11, 12, 13, 21, 22, 23, 31, 32, 33 };
                                int res = r.Next(array.Length);
                                int moveai = array[res];
                                flag = TheMove(moveai, "Х");
                            }
                            flag = false;
                        }
                        if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 1) { Console.Clear(); Print(); Console.WriteLine("Победил Компьютер!"); break; }
                        if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 2) { Console.Clear(); Print(); Console.WriteLine("Победил Игрок!"); break; }
                        if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 3) { Console.Clear(); Print(); Console.WriteLine("Ничья!"); break; }
                        Console.Clear();
                        Print();


                        Console.Write("Введите строку ");
                        string rowo = Console.ReadLine();
                        Console.Write("Введите столбец ");
                        string columno = Console.ReadLine();
                        int move = Convert.ToInt32(rowo + columno);
                        if (TheMove(move, "O") == false) { Console.WriteLine("Уже занято. Начните заново"); break; } else { TheMove(move, "X"); }
                        if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 1) { Console.Clear(); Print(); Console.WriteLine("Победил Игрок!"); break; }
                        if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 2) { Console.Clear(); Print(); Console.WriteLine("Победил Компьютер!"); break; }
                        if (IsVin(field[0], field[1], field[2], field[3], field[4], field[5], field[6], field[7], field[8]) == 3) { Console.Clear(); Print(); Console.WriteLine("Ничья!"); break; }
                        Console.Clear();
                        Print();
                    }
                }
            }
        }
    }
}



