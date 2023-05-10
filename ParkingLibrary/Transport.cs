using System;
using DataBase;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLibrary
{
    internal class Transport
    {
        static public void AddTransport()
        {
            string? mark = null;

            Console.WriteLine("Список клиентов: ");
            SqlDb.View("Client");
            Console.WriteLine("\n");
            while (true)
            {
                if (mark is null || mark == "")
                {
                    Console.Write("Введите марку ТС: ");
                    mark = Console.ReadLine();
                    continue;
                }
                break;
            }
            Console.WriteLine("ТС добавлено в базу данных\n");
            SqlDb.Add(mark);
        }
    }
}

