using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    class Zombie : Character
    {
        public Zombie(Level Level, int Xposition, int Yposition) : base(Level, Xposition, Yposition, ConsoleColor.Green)
        {
            Sprite = '¶';
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
                Level.Characters.Remove(this);
        }

        protected override void ExecuteBehaviour()
        {
            Player p = Level.Player;
            if (Pathfinding.IsNextTo(this, p))
            {
                int damage = new Random().Next(2, 5);
                p.TakeDamage(damage);
                InGameMenu.Log("Took " + damage + " dmg from a zombie");
                if (p.Health <= 0)
                    InGameMenu.Log("Died");
            }
            else
                Move(Pathfinding.NextStep(Xpos, Ypos, p.Xpos, p.Ypos));
        }

        #region Fields

        private int _health = 10;

        #endregion
    }
}
