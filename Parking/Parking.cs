using DataBase;
using ParkingLibrary;

namespace Parking
{
    internal class Parking
    {
        static void Main(string[] args)
        {
            SqlDb.CreateTables();
            Menu.MainMenu();
        }
    }
}