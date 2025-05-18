using System;
using System.Threading;

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
        
        private static DifficultyMode currentMode = DifficultyMode.Easy;
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

                        Console.Clear();
                        Console.WriteLine("U.E.F.A |Underground Elite Fist Arena| ---> PEGI 12");
                        Console.Write("Enter your username: ");
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
                        Console.Clear();
                        UserGUI();
                    }

                    while (isSettings)
                    {
                        Console.Clear();
                        SettingsGUI();
                    }
                }

                while (isBattle)
                {
                    Console.Clear();
                    Prints();
                    Console.ReadKey();
                    isBattle = false;
                    showGUI = true;
                    userGUI = true;
                }
            }
        }
        

        #region GUI

        private static void UserGUI()
        {
            Console.WriteLine($"Username: {userName}");
            Console.WriteLine($"Age: {userAge}");
            Console.WriteLine($"All Battles: {battlesCount}");
            Console.WriteLine($"Domination: {winsCount}");

            Console.WriteLine($"Difficulty mode: {currentMode}");

            Console.WriteLine($"Settings(S) | Battle(B) | Exit(ESC):");
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
                    showGUI = false;
                    break;
                case ConsoleKey.Escape:
                    isExit = true;
                    userGUI = false;
                    showGUI = false;
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
                    currentMode = DifficultyMode.Easy;
                    isSettings = false;
                    userGUI = true;
                    break;
                case ConsoleKey.N:
                    currentMode = DifficultyMode.Normal;
                    isSettings = false;
                    userGUI = true;
                    break;
                case ConsoleKey.H:
                    currentMode = DifficultyMode.Hard;
                    isSettings = false;
                    userGUI = true;
                    break;
            }
        }

        #endregion
        
        #region Battle

        private static void GetBattleMode(DifficultyMode mode)
        {
            switch (mode)
            {
                case DifficultyMode.Easy:
                    break;
                case DifficultyMode.Normal:
                    break;
                case DifficultyMode.Hard:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        private static void EasyBattle()
        {
            
        }

        private static void NormalBattle()
        {
            
        }

        private static void HardBattle()
        {
            
        }
        
        private static void Prints()
        {
            string[] art = new string[]
            {
                "                          #######                         ",
                "                       ####     ###                       ",
                "                     ###        ###                       ",
                "                  ####         ##                         ",
                "           ########          ###                          ",
                "      ######               ###                            ",
                "    ###                #####                              ",
                "   ##               #################################     ",
                "  ##                                                ##    ",
                " ##                                                 ##    ",
                "##                             ######################     ",
                "#                              #########################  ",
                "#                                                      ## ",
                "#                                                      ## ",
                "#                              #########################  ",
                "#                              ########################## ",
                "#                                                       ##",
                "##                                                      ##",
                " ##                            ########################## ",
                "  ###                          #####################      ",
                "    ####                                           ##     ",
                "       #####                                       ##     ",
                "           #########################################      "
            };

            foreach (var line in art)
            {
                Console.WriteLine(line);
                Thread.Sleep(100);
            }
            
            string[] art2 = new string[]
            {
                "                  ###########                ",
                "           ########          ##              ",
                "      ######                   ##            ",
                "    ###                         ##           ",
                "   ##               #####       ########     ",
                "  ##                    #        #     ##    ",
                " ##                     #       #      ##    ",
                "##                       ##    #########     ",
                "#                         #################  ",
                "#                        ##               ## ",
                "#                        ##               ## ",
                "#                         #################  ",
                "#                        ################### ",
                "#                       ##                 ##",
                "##                      ##                 ##",
                " ##                      ################### ",
                "  ###                       ###########      ",
                "    ####                   ##         ##     ",
                "       #####               ##         ##     ",
                "           ############################       "
            };

            foreach (var line in art2)
            {
                Console.WriteLine(line);
                Thread.Sleep(100);
            }
            
            string[] art3 = new string[]
            {
                "                                                           ",
                "                                                           ",
                "                                                           ",
                "                  ###########                              ",
                "           ########          ###                           ",
                "      ######                   ##                          ",
                "    ###                         ##                         ",
                "   ##               #####        ####################      ",
                "  ##                    #        #                  ##     ",
                " ##                     #       #                   ##     ",
                "##                       ##    ######################      ",
                "#                         ##############################   ",
                "#                                                      ##  ",
                "#                                                      ##  ",
                "#                         ##############################   ",
                "#                        ###################               ",
                "#                       ##                 ##              ",
                "##                      ##                 ##              ",
                " ##                      ###################               ",
                "  ###                       ###########                    ",
                "    ####                   ##         ##                   ",
                "       #####               ##         ##                   ",
                "           ############################                    "
            };

            foreach (var line in art3)
            {
                Console.WriteLine(line);
                Thread.Sleep(100);
            }
        }
        
        #endregion
        
        private static void CalculateAge(string dob)
        {
            int day = int.Parse(dob.Substring(0, 2));
            int month = int.Parse(dob.Substring(3, 2));
            int year = int.Parse(dob.Substring(6, 4));
            
            DateTime birthDate = new DateTime(year, month, day);
            DateTime today = DateTime.Today;
            userAge = today.Year - birthDate.Year;

            if (today.Month < birthDate.Month || (birthDate.Month == today.Month && today.Day < birthDate.Day))
            {
                userAge--;
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