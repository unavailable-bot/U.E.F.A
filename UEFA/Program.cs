using System;
using System.Text;
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
            InitStyle();
            
            ShowIntro();
            
            while (!isExit)
            {
                while (!isRegistered)
                {
                    try
                    {
                        Console.Clear();
                        Console.CursorVisible = true;
                        Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t🔴Enter your date of birth (dd/mm/yyyy): ");
            
                        string dateOfBirth = Console.ReadLine();
                        if (dateOfBirth?.Length != 10)
                        {
                            continue;
                        }

                        CalculateAge(dateOfBirth);
                        if (userAge < 12)
                        {
                            return;
                        }
                        Console.Clear();
                        Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t🟢Enter your date of birth (dd/mm/yyyy): " + dateOfBirth);
                        Console.Write("\n\t\t\t\t\t👤Enter your username: ");
                        userName = Console.ReadLine();
                        isRegistered = true;
                        showGUI = true;
                        userGUI = true;
                        Console.CursorVisible = false;
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
                    PrintFIGHT();
                    Thread.Sleep(3000);
                    Console.Clear();
                    PrintPaper();
                    PrintRock();
                    PrintClips();
                    Console.ReadKey();
                    isBattle = false;
                    showGUI = true;
                    userGUI = true;
                }
            }
        }
        
        #region Style

        private static void InitStyle()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "UEFA";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Clear();
        }

        private static void ShowIntro()
        {
            PrintLogo();
            
            Console.Clear();
            Thread.Sleep(500);
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t ➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖");
            Thread.Sleep(150);
            Console.WriteLine("\t\t\t\t\tU.E.F.A | Underground Elite Fist Arena");
            Thread.Sleep(150);
            Console.WriteLine("\t\t\t\t ➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖➖");
            Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\tPEGI 12");
            Thread.Sleep(2500);
        }

        private static void PrintLogo()
        {
            string[] art = new string[]
            {
                "HHHH  HHHH    GGGGGGGG ",
                " HH    HH    GGGGGGGGGG",
                " HH    HH    GGG    GGG",
                " HH    HH    GG      GG",
                " HHH  HHH    GG        ",
                " HHHHHHHH    GG        ",
                " HHH  HHH    GG   GGGGG",
                " HH    HH    GG   GG GG",
                " HH    HH    GGG     GG",
                " HH    HH    GGGGGGGGGG",
                "HHHH  HHHH    GGGGGGGG "
            };
            
            Console.WriteLine("\n\n\n\n\n\n");
            foreach (var line in art)
            {
                Console.WriteLine("\t\t\t\t\t   " + line);
                Thread.Sleep(50);
            }
            Thread.Sleep(1000);

            string studioName = "\n\t\t\t\t\t    Holy Grow Production";
            foreach (char ch in studioName)
            {
                Console.Write(ch);
                Thread.Sleep(25);
            }
            Thread.Sleep(3000);
        }
        
        #endregion

        #region GUI

        private static void UserGUI()
        {
            Console.Write($"Username: {userName}");
            Thread.Sleep(300);
            Console.Write($"\t\t\tAge: {userAge}");
            Thread.Sleep(300);
            Console.Write($"\t\t\t\t\t\tAll Battles: {battlesCount}");
            Thread.Sleep(300);
            Console.WriteLine($"\n\t\t\t\t\t\t\t\t\t\t\tDomination: {winsCount}");
            Thread.Sleep(300);

            Console.WriteLine($"\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\tDifficulty mode: {currentMode}");
            Thread.Sleep(300);
            Console.Write($"\t\t\t\t  Settings(S) | Battle(B) | Exit(ESC):");
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
            Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\tEasy(E) | Normal(N) | Hard(H)");
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

        private static void PrintFIGHT()
        {
            string[] art = new string[]
            {
                "FFFFFFFFFFFFF   FFFFFF    FFFFFFFF    FFFF  FFFF   FFFFFFFFFF",
                " FFFFFFFFFFF     FFFF    FFFFFFFFFF    FF    FF     FFFFFFFF ",
                " FF               FF     FFF    FFF    FF    FF        FF    ",
                " FFFFFFFFF        FF     FF      FF    FF    FF        FF    ",
                " FFFFFFFF         FF     FF            FFF  FFF        FF    ",
                " FF               FF     FF            FFFFFFFF        FF    ",
                " FF               FF     FF   FFFFF    FFF  FFF        FF    ",
                " FF               FF     FF   FF FF    FF    FF        FF    ",
                " FF               FF     FFF     FF    FF    FF        FF    ",
                " FF              FFFF    FFFFFFFFFF    FF    FF        FF    ",
                "FFFF            FFFFFF    FFFFFFFF    FFFF  FFFF      FFFF   "
            };

            Console.WriteLine("\n\n\n\n\n\n");
            foreach (var line in art)
            {
                Console.WriteLine("\t\t\t   " + line);
                Thread.Sleep(50);
            }
        }

        private static void PrintPaper()
        {
            string[] art = new string[]
            {
                "\n\n\n             ####             ",
                "          ##    ##            ",
                "    ######     #              ",
                "  ##        ##############    ",
                " ##                       #   ",
                "#             ##############  ",
                "#                           # ",
                "#               ############  ",
                "#                           # ",
                " #              ############  ",
                "  #                       #   ",
                "    ######################    "
            };

            foreach (var line in art)
            {
                Console.WriteLine(line);
                Thread.Sleep(50);
            }
        }

        private static void PrintRock()
        {
            string[] art = new string[]
            {
                "\n\n\n                              ",
                "        #######               ",
                "    ####       #              ",
                "  ##       #   ######         ",
                " ##         #  #     #        ",
                "#            #########        ",
                "#            #        #       ",
                "#             ########        ",
                "#            #        #       ",
                " #            ########        ",
                "  #            #    #         ",
                "    ################          "
            };

            foreach (var line in art)
            {
                Console.WriteLine(line);
                Thread.Sleep(50);
            }
        }

        private static void PrintClips()
        {
            string[] art = new string[]
            {
                "\n\n\n                              ",
                "        #######               ",
                "    ####       #              ",
                "  ##       #   ###########    ",
                " ##         #  #          #   ",
                "#            ## ############  ",
                "#                           # ",
                "#             ############## ",
                "#            #        #      ",
                " #            ########       ",
                "  #            #    #        ",
                "    ################         "
            };

            foreach (var line in art)
            {
                Console.WriteLine(line);
                Thread.Sleep(50);
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
        }
    }
}