using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLibrary
{
    public class Menu
    {
        static string? temp;
        public static void MainMenu()
        {
            Console.WriteLine("Приветствуем вас в меню АвтоСтоп.");
            while (true)
            {
                Console.WriteLine("1. Добавить нового клиента\n" +
                "2. Добавить новое ТС к уже зарегистрированному клиенту\n" +
                "3. Редактировать данные места автостоянки\n" +
                "4. Поиск арендуемого места\n" +
                "5. Поиск ТС\n" +
                "6. Поиск клиента\n" +
                "7. Просмотр статистики по автостоянке\n" +
                "8. Удаление аренды места автостоянки\n");
                Console.Write("Выбор действия: ");
                temp = Console.ReadLine();
                switch (temp)
                {
                    case "1":
                        Console.Clear();
                        Client.AddClient();
                        break;
                    case "2":
                        Console.Clear();
                        Transport.AddTransport();
                        break;
                }

                if (temp != "")
                    Console.Read();
                Console.Clear();
            }
        }
    }
}