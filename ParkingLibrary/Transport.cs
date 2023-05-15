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
            string? mark = null,model = null, sertificate = null, year = null,color = null, number = null;

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

                if (model is null || model == "")
                {
                    Console.Write("Введите модель ТС: ");
                    model = Console.ReadLine();
                    continue;
                }

                if (sertificate is null || sertificate == "")
                {
                    Console.Write("Ведите номер свидетельства о регистрации ТС: ");
                    sertificate = Console.ReadLine();
                    continue;
                }

                if (year is null || year == "") 
                {
                    Console.Write("Введите год выпуска ТС: ");
                    year = Console.ReadLine();
                    continue;
                }

                if (color is null || color == "") 
                {
                    Console.Write("Введите цвет ТС: ");
                    color = Console.ReadLine();
                    continue;
                }

                if (number is null || number == "") 
                {
                    Console.Write("Введите госномер ТС: ");
                    number = Console.ReadLine();
                    continue;
                }
            }         
        }
    }
}

