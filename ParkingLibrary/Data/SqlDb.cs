using System.Data.SQLite;
using static System.Net.Mime.MediaTypeNames;
using ParkingLibrary.Data;

namespace DataBase
{
    public class SqlDb

    {
        public static SQLiteConnection connection = new SQLiteConnection();
        public static SQLiteCommand command = new SQLiteCommand();
        public static SQLiteException exception = new SQLiteException();

        //Подключение к файлу базы данных
        static public bool Connect()
        {
            try
            {
                connection = new SQLiteConnection("Data Source = ParkingLite.db;Version=3; FailIfMissing=False");
                connection.Open();
                return true;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка доступа к базе данных. Исключение: {ex.Message}");
                return false;
            }
        }
        //Создание таблиц
        static public void CreateTables()
        {
            if (Connect())
            {
                command = new SQLiteCommand(connection)
                {
                    CommandText = "CREATE TABLE IF NOT EXISTS [Client] ([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, [fullname] TEXT, [passport] TEXT);"
                };
                command.ExecuteNonQuery();
                command = new SQLiteCommand(connection)
                {
                    CommandText = "CREATE TABLE IF NOT EXISTS [Transport]([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, [mark] TEXT, [model] TEXT, [sertificate] TEXT, [year] TEXT, [color] TEXT, [number] TEXT);"
                };
                command.ExecuteNonQuery();
            }
        }
        //Внести нового клиента
        public static void Add(string fullname, string passport)
        {
            if (Connect())
            {
                command.CommandText = $"INSERT INTO Client (fullname, passport) VALUES (\"{fullname}\",\"{passport}\")";
                command.ExecuteNonQuery();
            }
        }
        //Добавление нового транспорта
        internal static void Add (Car car) 
        {
            if (Connect())
            {
                command.CommandText = $"INSERT INTO Transport (mark, model, sertificate, year, color, number) VALUES (\"{car.mark}\",\"{car.model}\",\"{car.sertificate}\",\"{car.year}\",\"{car.color}\",\"{car.number}\")";
                command.ExecuteNonQuery();
            }
        }
        //Получение данных из всего столбца таблицы
        public static List<string> Take(string nameTable, string row)
        {
            List<string> result = new List<string>();
            if (Connect())
            {
                SQLiteConnection connection = new SQLiteConnection("Data Source = ParkingLite.db");
                connection.Open();
                SQLiteCommand command = new SQLiteCommand($"SELECT {row} FROM {nameTable}", connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        result.Add(Convert.ToString(reader.GetString(0)));
                    }
                    catch
                    {
                        result.Add(Convert.ToString(reader.GetInt32(0)));
                    }

                }
                reader.Close();
                return result;
            }
            return result;
        }
        //Вывод всех данных из таблицы
        public static void View(string tableName)
        {
            if (Connect())
            {
                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM \"{tableName}\"", connection);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (tableName == "Client")
                        Console.WriteLine($"ID: {reader.GetValue(0)}\nФИО: {reader.GetValue(1)}\nПаспорт: {reader.GetValue(2)}");
                    if (tableName == "Transport")
                        Console.WriteLine($"ID: {reader.GetValue(0)}\nМарка ТС: {reader.GetValue(1)}\nМодель: {reader.GetValue(2)}");
                    Console.WriteLine("================================================");
                }
                reader.Close();
            }
        }
    }
}