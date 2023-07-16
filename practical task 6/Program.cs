using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_task_6
{
    internal class Program
    {
        static void Сompletion(StreamWriter sw)
        {
            Console.WriteLine();
            using (sw)
            {
                char key = '1';
                do
                {
                    string completion = string.Empty;
                    Console.Write($"id Сотрудника: ");
                    completion += $"{Console.ReadLine()}\t";
                    DateTime date = DateTime.Now;
                    Console.WriteLine($"Датa и время добавления записи: {date}");
                    completion += $"{date}\t";
                    Console.Write($"Ф. И. О.: ");
                    completion += $"{Console.ReadLine()}\t";
                    Console.Write($"Возраст: ");
                    completion += $"{Console.ReadLine()}\t";
                    Console.Write($"Рост: ");
                    completion += $"{Console.ReadLine()}\t";
                    Console.Write($"Дата рождения: ");
                    completion += $"{Console.ReadLine()}\t";
                    Console.Write($"Место рождения: ");
                    completion += $"{Console.ReadLine()}\t";
                    sw.WriteLine(completion);
                    Console.WriteLine("Продожить 1 - да/2 - нет");
                    key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key) == '1');
            }

        }
        static void Print(StreamReader sr)
        {
            Console.WriteLine();
            using (sr)
            {
                string line;
                Console.WriteLine($"{"id Сотрудника"}{" Время и дата",15} {"Ф. И. О.",13} {"Возраст",27}" +
                $" {"Рост",5} {"Дата рождения",14} {"Место рождения",15}");
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('\t');
                    Console.WriteLine($"{data[0]}{data[1],31} {data[2],28}{data[3],4} {data[4],9} {data[5],12} {data[6],11}");
                }
            }
        }

        static void Main(string[] args)
        {
            //Справочник «Сотрудники».
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Введите '1' что бы дополнить данные.");
                Console.WriteLine("Введите '2' что бы вывести данные на экран.");
                Console.WriteLine("Введите '3' что бы закрыть программу");
                string key = Console.ReadLine();
                if (key == "1")
                {
                    using (StreamWriter sw = new StreamWriter("Сотрудники.csv", true, Encoding.Unicode))
                    {
                        Сompletion(sw);
                    }
                }
                if (key == "2")
                {
                    if (File.Exists(@"C:\Users\Александр\Desktop\Skillbox проекты\practical task 6\practical task 6\bin\Debug\Сотрудники.csv"))
                    {
                        using (StreamReader sr = new StreamReader("Сотрудники.csv", Encoding.Unicode))
                        {
                            Print(sr);
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Не найдено ни одного сотрудника");
                    }
                }
                if (key == "3")
                {
                    break;
                }
                if ((key != "1" && key != "2") && (key != "3"))
                {
                    Console.WriteLine();
                    Console.WriteLine("Что то пошло не так! Убедитесь что вы нажали 1,2 или 3!!!");
                }
            }
        }
    }
}
