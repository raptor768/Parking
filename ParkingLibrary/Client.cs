using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLibrary
{
    internal class Client
    {
        static public void AddClient()
        {
            string? fullname = null, passport;
            List<string> temp = SqlDb.Take("Client", "passport");

            Console.WriteLine("Список ТС: ");
            SqlDb.View("Transport");
            Console.WriteLine("\n");

            while (true)
            {
                if (fullname is null || fullname == "")
                {
                    Console.Write("Введите ФИО клиента: ");
                    fullname = Console.ReadLine();
                    continue;
                }

                Console.Write("Введите паспортные данные: ");
                passport = Console.ReadLine();
                if (passport.Length != 11)
                {
                    Console.WriteLine("Неверный формат! Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return;
                    continue;
                }
                if (passport[4] != ' ')
                {
                    Console.WriteLine("Неверный формат! Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return;
                    continue;
                }

                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (i != 3)
                            Convert.ToInt32(passport[i]);
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат! Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }

                if (temp.Contains(passport))
                {
                    Console.WriteLine("Клиент с такими паспортными данными уже присутствует в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    passport = "";
                    if (Console.ReadLine() == "...")
                        return;
                    continue;
                }

                break;
            }
            Console.WriteLine("Клиент добавлен в базу данных\n");
            SqlDb.Add(fullname, passport);
        }
    }
}

