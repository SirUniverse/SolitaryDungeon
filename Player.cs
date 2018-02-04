using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    class Player : Character
    {
        public Player(Level Level, int Xposition, int Yposition) : base(Level, Xposition, Yposition, ConsoleColor.White)
        {
            Sprite = '☻';
            //Menu.ShowIntro();
            Camera.Render();
            InGameMenu.Update();
        }

        #region Properties

        public int Health
        {
            get { return _health; }
        }

        #endregion

        // carpit
        public void TakeDamage(int DamageValue)
        {
            _health -= DamageValue;
            if (_health <= 0)
            {
                Game.IsAlive = false;
                Game.IsWon = false;
            }
        }

        protected override void ExecuteBehaviour()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        Sprite = '▲';
                        Move(Direction.Up);
                        goto default;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        Sprite = '▼';
                        Move(Direction.Down);
                        goto default;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        Sprite = '◄';
                        Move(Direction.Left);
                        goto default;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        Sprite = '►';
                        Move(Direction.Right);
                        goto default;
                    case ConsoleKey.E:
                        Level.Interact(Xorient, Yorient);
                        goto default;
                    case ConsoleKey.Spacebar:
                        // carpit
                        foreach (Character z in Level.Characters.ToArray())
                            if (z.GetType().Name == "Zombie" && z.Xpos == Xorient && z.Ypos == Yorient)
                            {
                                ((Zombie)z).TakeDamage(_damage);
                                if(((Zombie)z).Health > 0)
                                    InGameMenu.Log("Hit a zombie for 5 dmg");
                                else if (((Zombie)z).Health == 0)
                                {
                                    InGameMenu.Log("Killed a zombie");
                                    _health += 3;
                                    if (_health > 18)
                                        _health = 18;
                                }
                            }
                        if (Level.Characters.Count == 1)
                        {
                            InGameMenu.Log("Killed all zombies");
                            Game.IsAlive = false;
                            Game.IsWon = true;
                        }
                        goto default;
                    default:
                        Level.Update();
                        Camera.Render();
                        InGameMenu.Update();
                        break;
                } 
            }
        }

        #region Fields

        private int _health = 18;
        private int _damage = 5;

        #endregion
    }
}