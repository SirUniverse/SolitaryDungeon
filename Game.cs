using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    static class Game
    {
        #region Properties

        public static Level CurrentLevel
        {
            get { return _currentLevel; }
            set { _currentLevel = value; }
        }

        public static bool IsAlive
        {
            get { return _isAlive; }
            set
            {
                _isAlive = value;
                if (!_isAlive)
                    _isPaused = true;
            }
        }

        public static bool IsPaused
        {
            get { return _isPaused; }
            set { _isPaused = value; }
        }

        public static bool IsWon
        {
            get { return _isWon; }
            set { _isWon = value; }
        }

        #endregion

        public static void Initialize()
        {
            Console.Title = "Solidary Dungeon";
            IsAlive = true;
            IsPaused = false;
            IsWon = false;
            Console.CursorVisible = false;
            Console.WindowHeight = 31;
            Console.BufferHeight = 31;
            Console.WindowWidth = 100;
            Console.BufferWidth = 100;
            Camera.RenderHeight = Console.WindowHeight;
            Camera.RenderWidth = 71;
            InGameMenu.Height = Console.WindowHeight;
            InGameMenu.Width = Console.WindowWidth - Camera.RenderWidth;
        }

        #region Fields

        private static Level _currentLevel;
        private static bool _isAlive, _isPaused, _isWon;

        #endregion
    }
}
