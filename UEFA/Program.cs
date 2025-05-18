using System;

namespace UEFA
{
    internal class Program
    {
        private static bool isRegistered;
        private static bool showGUI;
        private static bool userGUI;
        private static bool isBattle;
        private static bool isSettings;
        private static bool isExit;
        
        private static int userAge;
        private static string userName;
        private static int battlesCount = 0;
        private static int winsCount = 0;
        public static void Main(string[] args)
        {
            while (!isExit)
            {
                while (!isRegistered)
                {
                    try
                    {
                        Console.WriteLine("U.E.F.A |Underground Elite Fist Arena| ---> PEGI 12");
                        Console.Write("Enter your date of birth (dd/mm/yyyy): ");
            
                        string dateOfBirth = Console.ReadLine();
                        if (dateOfBirth?.Length != 10)
                        {
                            ResultMessage("Invalid date format");
                            continue;
                        }

                        CalculateAge(dateOfBirth);
                        if (userAge < 12)
                        {
                            return;
                        }

                        userName = Console.ReadLine();
                        isRegistered = true;
                        showGUI = true;
                        userGUI = true;
                        break;
                    }
                    catch (Exception e)
                    {
                        ResultMessage($"Error message: {e.Message}");
                    }
                }

                while (showGUI)
                {
                    while (userGUI)
                    {
                        UserGUI();
                    }

                    while (isSettings)
                    {
                        
                    }
                }
            }
        }
        
        private static void CalculateAge(string dob)
        {
            int day = int.Parse(dob.Substring(0, 2));
            int month = int.Parse(dob.Substring(3, 2));
            int year = int.Parse(dob.Substring(6, 4));
            
            DateTime birthDate = new DateTime(year, month, day);
            DateTime today = DateTime.Today;
            userAge = today.Year - birthDate.Year;

            if (birthDate.Month < today.Month || (birthDate.Month == today.Month && birthDate.Day < today.Day))
            {
                userAge--;
            }
        }

        private static void UserGUI()
        {
            Console.WriteLine($"Username: {userName}");
            Console.WriteLine($"Age: {userName}");
            Console.WriteLine($"All Battles: {battlesCount}");
            Console.WriteLine($"Domination: {winsCount}");

            Console.Write($"Settings(S) | Battle(B) | Exit(Any other key):");
            ConsoleKey inputKey = Console.ReadKey().Key;
            switch (inputKey)
            {
                case ConsoleKey.S:
                    isSettings = true;
                    userGUI = false;
                    break;
                case ConsoleKey.B:
                    isBattle = true;
                    userGUI = false;
                    break;
                default:
                    isExit = true;
                    userGUI = false;
                    break;
            }
        }

        private static void SettingsGUI()
        {
            Console.WriteLine("Easy(E) | Normal(N) | Hard(H)");
            ConsoleKey inputKey = Console.ReadKey().Key;
            switch (inputKey)
            {
                case ConsoleKey.E:
                    
                    break;
                case ConsoleKey.N:
                    
                    break;
                case ConsoleKey.H:
                    
                    break;
                default:
                    break;
            }
        }

        private static void ResultMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}