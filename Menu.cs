using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SolitaryDungeon
{
    static class Menu
    {
        // carpit
        public static void ShowIntro()
        {
            Game.IsPaused = true;
            DrawMenu();
            DrawIntro();
            Console.Beep(1760, 240);
            Console.Beep(2093, 320);
            Console.Beep(1760, 240);
            Console.Beep(2093, 320);
            Console.Beep(2794, 450);
            Console.Beep(2637, 450);
            Thread.Sleep(600);
            ClearMenu();
            ClearInputBuffer();
            Game.IsPaused = false;
        }

        public static void ShowWin()
        {
            Game.IsPaused = true;
            Thread.Sleep(1000);
            Console.Clear();
            DrawMenu();
            DrawWin();
            Console.ReadKey(true);
        }

        public static void ShowGameOver()
        {
            Game.IsPaused = true;
            Thread.Sleep(1000);
            Console.Clear();
            DrawMenu();
            DrawGameOver();
            Console.ReadKey(true);
        }

        private static void DrawMenu()
        {
            Console.SetCursorPosition(4, 3);
            Console.Write('┌');
            for (int i = 0; i < Console.WindowWidth - 10; ++i)
                Console.Write('─');
            Console.Write('┐');
            for (int i = 4; i < Console.WindowHeight - 4; ++i)
            {
                Console.SetCursorPosition(4, i);
                Console.Write('│');
                for (int j = 0; j < Console.WindowWidth - 10; ++j)
                    Console.Write(' ');
                Console.Write('│');
            }
            Console.SetCursorPosition(4, Console.WindowHeight - 4);
            Console.Write('└');
            for (int i = 0; i < Console.WindowWidth - 10; ++i)
                Console.Write('─');
            Console.Write('┘');
        }

        private static void ClearMenu()
        {
            Camera.Render();
            InGameMenu.Update();
        }

        private static void ClearInputBuffer()
        {
            while (Console.KeyAvailable)
                    Console.ReadKey(true);
        }

        private static void DrawIntro()
        {
            int row = 6;
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"          _____           _           _");
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"         / ____|         | |         | |");
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"        | (___     ___   | |  _   _  | |_    __ _   _ __   _   _");
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"         \___ \   / _ \  | | | | | | | __|  / _` | | '__| | | | |");
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"         ____) | | (_) | | | | |_| | | |_  | (_| | | |    | |_| |");
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"        |_____/   \___/  |_|  \__, |  \__|  \__,_| |_|     \__, |");
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"                               __/ |                        __/ |");
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"                              |___/                        |___/ ");
            ++row;
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"                             _____");
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"                            |  __ \");
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"                            | |  | |  _   _   _ __     __ _    ___    ___    _ __");
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"                            | |  | | | | | | | '_ \   / _` |  / _ \  / _ \  | '_ \");
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"                            | |__| | | |_| | | | | | | (_| | |  __/ | (_) | | | | |");
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"                            |_____/   \__,_| |_| |_|  \__, |  \___|  \___/  |_| |_|");
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"                                                       __/ |");
            Console.SetCursorPosition(5, ++row);
            Console.Write(@"                                                      |___/");
        }

        private static void DrawGameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int row = 11;
            Console.SetCursorPosition(20, ++row);
            Console.Write(@"   _____                         ____                   _");
            Console.SetCursorPosition(20, ++row);
            Console.Write(@"  / ____|                       / __ \                 | |");
            Console.SetCursorPosition(20, ++row);
            Console.Write(@" | |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __  | |");
            Console.SetCursorPosition(20, ++row);
            Console.Write(@" | | |_ |/ _` | '_ ` _ \ / _ \ | |  | \ \ / / _ \ '__| | |");
            Console.SetCursorPosition(20, ++row);
            Console.Write(@" | |__| | (_| | | | | | |  __/ | |__| |\ V /  __/ |    |_|");
            Console.SetCursorPosition(20, ++row);
            Console.Write(@"  \_____|\__,_|_| |_| |_|\___|  \____/  \_/ \___|_|    (_)");
            Console.SetCursorPosition(39, row + 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Press any key to exit");
        }

        public static void DrawWin()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int row = 11;
            Console.SetCursorPosition(20, ++row);
            Console.Write(@"        __     __          __          __");
            Console.SetCursorPosition(20, ++row);
            Console.Write(@"        \ \   / /          \ \        / /");
            Console.SetCursorPosition(20, ++row);
            Console.Write(@"         \ \_/ /__  _   _   \ \  /\  / /__  _ __");
            Console.SetCursorPosition(20, ++row);
            Console.Write(@"          \   / _ \| | | |   \ \/  \/ / _ \| '_ \");
            Console.SetCursorPosition(20, ++row);
            Console.Write(@"           | | (_) | |_| |    \  /\  / (_) | | | |");
            Console.SetCursorPosition(20, ++row);
            Console.Write(@"           |_|\___/ \__,_|     \/  \/ \___/|_| |_|");
            Console.SetCursorPosition(39, row + 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Press any key to exit");
        }
    }
}
