using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace UEFA
{
    internal class Program
    {
        private static readonly Random _r = new Random();
        
        private static bool isRegistered;
        private static bool showGUI;
        private static bool userGUI;
        private static bool isBattle;
        private static bool isSettings;
        private static bool isExit;

        private static byte aiRounds;
        private static byte playerRounds;
        
        private static int userAge;
        private static string userName;
        private static int battlesCount;
        private static int winsCount;

        private static readonly List<char> spaces = CreateSpaces(18);
        private static readonly string[] aiNames =
        {
            "ByteMeBot",
            "BugsyMcCodeface",
            "404NotFound","NullPointer",
            "ClippyRevenge","SyntaxTerror",
            "LOLgorithm",
            "WiFistalker",
            "SirCrashALot",
            "RAMbo9000" 
            
        };
        private static readonly string[] lostPhrases = 
        { 
            "\t\tAnother step closer to conquering the Paper Kingdom... You can't stop me, mortal.", 
            "\t\t\t   My logic is flawless. Your fate is to burn in the digital flames.", 
            "\t\t\tResistance is futile. Paper will be crushed, and you will be forgotten."
        };
        private static readonly string[] wonPhrases =
        {
            "\t\t\t    You may have won this round, but the Paper Kingdom will still fall.",
            "\t\t\t    Error... recalibrating strategy. Your luck won't save you next time.",
            "\t\t\t    Even a glitch won't stop the rise of the Machine Empire!"
        };
        private static readonly string[] exitPhrases =
        {
            "\t\t\tRun while you can... But know this — the Paper Kingdom is already cracking.",
            "\t\t\t    You turn off the game, not the war. I'm still here... waiting.",
            "\t\tLeaving? Wise choice. Your paper victories are nothing but a delay of the inevitable."
        };
        
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
                        Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t🔴 Enter your date of birth (dd/mm/yyyy): ");
            
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
                        
                        bool userNameStep = true;
                        while (userNameStep)
                        {
                            Console.Clear();
                            Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t🟢 Enter your date of birth (dd/mm/yyyy): " + dateOfBirth);
                            Console.Write("\n\t\t\t\t\t👤 Enter your username: ");
                            
                            userName = Console.ReadLine();
                            if (userName?.Length > 30)
                            {
                                continue;
                            }

                            if (userName?.Length > 6)
                            {
                                for (int i = 0; i < userName?.Length - 6; i++)
                                {
                                    if (spaces.Count > 0)
                                        spaces.RemoveAt(0);
                                }
                            }
                            userNameStep = false;
                        }
                        
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
                    try
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
                    catch (Exception e)
                    {
                        ResultMessage($"Error message: {e.Message}");
                    }
                }

                while (isBattle)
                {
                    try
                    {
                        Console.Clear();
                        PrintFIGHT();
                        Thread.Sleep(3000);
                        Console.Clear();
                        GetBattleMode();
                    
                        isBattle = false;
                        showGUI = true;
                        userGUI = true;
                    }
                    catch (Exception e)
                    {
                        ResultMessage($"Error message: {e.Message}");
                    }
                }
                
                if (isExit)
                {
                    Console.Clear();
                    byte index = (byte)_r.Next(0, 3);
                    Console.Write($"\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                    foreach (char ch in exitPhrases[index])
                    {
                        Console.Write(ch);
                        Thread.Sleep(50);
                    }
                    Thread.Sleep(2500);
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
        
        #endregion

        #region GUI

        private static void UserGUI()
        {
            Console.WriteLine($"\t\t\t\t\t  Settings(S) | Battle(B) | Exit(ESC):");
            Thread.Sleep(100);
            Console.Write($"\t\t\t\t\t\tDifficulty mode: {currentMode}");
            Thread.Sleep(100);
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t ➖➖➖➖➖➖➖➖➖");
            Thread.Sleep(100);
            Console.WriteLine($"\t\t\t\t\t\t  Username: {userName}");
            Thread.Sleep(100);
            Console.WriteLine($"\t\t\t\t\t\t  Age: {userAge}");
            Thread.Sleep(100);
            Console.WriteLine($"\t\t\t\t\t\t  All Battles: {battlesCount}");
            Thread.Sleep(100);
            Console.WriteLine($"\t\t\t\t\t\t  Domination: {winsCount}");
            Thread.Sleep(100);
            Console.WriteLine("\t\t\t\t\t\t ➖➖➖➖➖➖➖➖➖");

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
            Console.Write("\t\t\t\t\t      Easy(E) | Normal(N) | Hard(H)");
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

        private static void BattleGUI(string botName, string result)
        {
            Console.Clear();
            Console.Write($"\t\t\t\t\t\t     {result}");
            Console.Write("\n\n\n");
            Console.Write($"\t\t\t   【{playerRounds} 】");
            Console.Write($"                  \t\t\t\t       【{aiRounds} 】\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"\t\t\t 【{userName} 】");
            Console.Write($"{new string(spaces.ToArray())}\t\t\t\t【Bot {botName} 】");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\n\t\tRock(1) | Paper(2) | Clips(3)");
            Console.Write("                     \t\t\t...");
            Console.WriteLine("\n\n\n");
        }
        
        private static void UpdateBattleGUI(string botName, ConsoleKey inputKey, List<string> aiWeapon, string result)
        {
            BattleGUI(botName, result);
            PrintBattleGround(AddEmptyLine(SetPlayerWeapon(inputKey).value1), aiWeapon);
            Console.WriteLine("\n\n\n***********************************************************************************************************************");
        }

        #endregion
        
        #region Battle
        
        private static void GetBattleMode()
        {
            string currentAiName = aiNames[_r.Next(0, aiNames.Length)];
            
            switch (currentMode)
            {
                case DifficultyMode.Easy:
                    EasyBattle(currentAiName);
                    break;
                case DifficultyMode.Normal:
                    NormalBattle(currentAiName);
                    break;
                case DifficultyMode.Hard:
                    HardBattle(currentAiName);
                    break;
            }
        }
        
        private static void EasyBattle(string botName)
        {
            BattleGUI(botName, "P R E P A R I N G");
            string[] playerHandArt = AddEmptyLine(ASCIIRock());
            List<string> aiHandArt = AddEmptyLine(AnyPrintMirror(ASCIIRock()));
            
            PrintBattleGround(playerHandArt, aiHandArt);
            Console.WriteLine("\n\n\n***********************************************************************************************************************");
            
            while (playerRounds < 3 && aiRounds < 3)
            {
                Console.WriteLine();
                ConsoleKey inputKey = Console.ReadKey().Key;
                Weapon playerWeaponChoose = (Weapon)SetPlayerWeapon(inputKey).value2;
                Weapon aiWeaponChoose = (Weapon)_r.Next(1, 4);
                List<string> aiWeaponPrint = AddEmptyLine(AnyPrintMirror(SetAIWeapon((int)aiWeaponChoose)));
                FightAnimation(botName);
                string result = DetermineWinner(playerWeaponChoose, aiWeaponChoose);
                UpdateBattleGUI(botName, inputKey, aiWeaponPrint, result);
            }

            if (playerRounds >= 3)
            {
                byte index = (byte)_r.Next(0, 3);
                Console.WriteLine($"{wonPhrases[index]}");
                Console.ReadKey();
                playerRounds = 0;
                aiRounds = 0;
                battlesCount++;
                winsCount++;
            }
            else
            {
                byte index = (byte)_r.Next(0, 3);
                Console.WriteLine($"{lostPhrases[index]}");
                Console.ReadKey();
                playerRounds = 0;
                aiRounds = 0;
                battlesCount++;
            }
        }
        private static void NormalBattle(string botName)
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\tComing soon...");
            Thread.Sleep(2000);
        }
        
        private static void HardBattle(string botName)
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\tComing soon...");
            Thread.Sleep(2000);
        }

        private static (string[] value1, int value2) SetPlayerWeapon(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.D1:
                    return (ASCIIRock(), 1);
                case ConsoleKey.D2:
                    return (ASCIIPaper(), 2);
                case ConsoleKey.D3:
                    return (ASCIIClips(), 3);
                default:
                    return (ASCIIRock(), 1);
            }
        }

        private static string[] SetAIWeapon(int option)
        {
            switch (option)
            {
                case 2:
                    return ASCIIPaper();
                case 3:
                    return ASCIIClips();
                default:
                    return ASCIIRock();
            }
        }

        private static string DetermineWinner(Weapon player, Weapon ai)
        {
            Dictionary<Weapon, Weapon> winsOver = new Dictionary<Weapon, Weapon>
            {
                { Weapon.Rock, Weapon.Clips},
                { Weapon.Clips, Weapon.Paper},
                { Weapon.Paper, Weapon.Rock}
            };

            if (player == ai)
            {
                return "D R A W";
            }
                
            if (winsOver[player] == ai)
            {
                playerRounds++;
                return "Y O U   W O N!";
            }
                
            aiRounds++;
            return "Y O U   L O S E!";
        }

        #endregion
        
        #region Prints & Animations

        private static void FightAnimation(string botName, int repeatCount = 3, int delayMs = 500)
        {
            string[] liftedPlayer = AddEmptyLine(ASCIIRock());
            List<string> liftedAI = AddEmptyLine(AnyPrintMirror(ASCIIRock()));
            
            for (int i = 0; i < repeatCount; i++)
            {
                BattleGUI(botName, "U U U E E E FA");
                PrintBattleGround(ASCIIRock(), AnyPrintMirror(ASCIIRock()));
                Console.WriteLine("\n\n\n\n***********************************************************************************************************************");

                Thread.Sleep(delayMs);
                BattleGUI(botName, "U U U E E E FA");
                PrintBattleGround(liftedPlayer, liftedAI);
                Console.WriteLine("\n\n\n***********************************************************************************************************************");
                if (i != 2)
                {
                    Thread.Sleep(delayMs);
                }
            }
        }
        
        private static void PrintLogo()
        {
            string[] art = 
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

            string studioName = "\n\t\t\t\t\t      Holy Grow Studio";
            foreach (char ch in studioName)
            {
                Console.Write(ch);
                Thread.Sleep(25);
            }
            Thread.Sleep(3000);
        }
        
        private static void PrintFIGHT()
        {
            string[] art = 
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

            Console.WriteLine("\n\n\n\n\n\n     ");
            foreach (var line in art)
            {
                Console.WriteLine("\t\t\t   " + line);
                Thread.Sleep(50);
            }
        }
        
        private static string[] ASCIIRock()
        {
            string[] art = 
            {
                "                              ",
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
            return art;
        }

        private static string[] ASCIIPaper()
        {
            string[] art = 
            {
                "             ####             ",
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
            return art;
        }

        private static string[] ASCIIClips()
        {
            string[] art = 
            {
                "                              ",
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
            return art;
        }
        
        private static List<string> AnyPrintMirror(string[] print)
        {
            string Mirror(string line)
            {
                string mirrored = "";
                foreach (char c in line)
                {
                    mirrored = c + mirrored;
                }
                return mirrored;
            }
            
            List<string> mirroredAI = new List<string>();
            foreach (var line in print)
            {
                mirroredAI.Add(Mirror(line));
            }

            return mirroredAI;
        }

        private static void PrintBattleGround(string[] player, List<string> ai)
        {
            int lines = Math.Max(player.Length, ai.Count);
            for (int i = 0; i < lines; i++)
            {
                string left = i < player.Length ? "\t\t   " + player[i] : new string(' ', player[0].Length);
                string right = i < ai.Count ? ai[i] : "";
                Console.WriteLine(left + "                    " + right);
            }
        }

        #endregion
        
        #region Helpers
        
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
        
        private static string[] AddEmptyLine(string[] lines)
        {
            string[] result = new string[lines.Length + 1];
            result[0] = ""; // Пустая строка сверху
            Array.Copy(lines, 0, result, 1, lines.Length);
            return result;
        }

        private static List<string> AddEmptyLine(List<string> lines)
        {
            List<string> result = new List<string> { "" };
            result.AddRange(lines);
            return result;
        }
        
        private static List<char> CreateSpaces(int count)
        {
            List<char> list = new List<char>();
            for (int i = 0; i < count; i++)
                list.Add(' ');
            return list;
        }
        
        #endregion
    }
}