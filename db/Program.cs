using System;
using System.Data.SQLite;

namespace UniversitySchedulingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string dbPath = "Data Source=university_scheduling_system.db";

            using (SQLiteConnection connection = new SQLiteConnection(dbPath))
            {
                connection.Open();

                // Display Courses Table
                Console.WriteLine("Courses Table:");
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Courses", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Course: {reader["Course"]}, Time: {reader["TimeToStart"]}, " +
                                              $"Duration: {reader["DurationInLectureHours"]}, Lecturer: {reader["Lecturer"]}, " +
                                              $"Students: {reader["All_Students"]}");
                        }
                    }
                }

                Console.WriteLine();

                // Display ClassroomCapacity Table
                Console.WriteLine("ClassroomCapacity Table:");
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM ClassroomCapacity", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Classroom: {reader["Classroom"]}, Capacity: {reader["Capacity"]}");
                        }
                    }
                }

                connection.Close();
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
