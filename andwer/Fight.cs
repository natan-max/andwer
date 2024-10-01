using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace andwer
{
    internal class Fight
    {
        class Mob
        {
            public double Health { get; protected set; }
            public double MaxHealth { get; protected set; }
            public double Damage { get; protected set; }
            public string Name { get; protected set; }

            public bool IsAlive => Health > 0;

            public virtual void ReceiveDamage(double damage)
            {
                Health -= damage;
                if (Health < 0)
                {
                    Health = 0;
                }
                Console.WriteLine($"{Name} отримав {damage} шкоди. Залишилось здоров'я: {Health}");
            }

            public virtual void DealDamage(Mob mob)
            {
                mob.ReceiveDamage(Damage);
            }
        }

        class Player : Mob
        {
            private int shieldTurns = 0;

            public Player(string name, double health, double damage)
            {
                Name = name;
                MaxHealth = health;
                Health = MaxHealth;
                Damage = damage;
            }

            public void Shield()
            {
                if (shieldTurns == 0)
                {
                    shieldTurns = 2;
                    Console.WriteLine($"{Name} активував щит на 2 ходи.");
                }
                else
                {
                    Console.WriteLine("Щит вже активовано.");
                }
            }

            public override void ReceiveDamage(double damage)
            {
                if (shieldTurns > 0)
                {
                    Console.WriteLine($"{Name} заблокував атаку щитом.");
                    shieldTurns--;
                }
                else
                {
                    base.ReceiveDamage(damage);
                }
            }
        }

        class Zombie : Mob
        {
            public Zombie(string name, double health, double damage)
            {
                Name = name;
                MaxHealth = health;
                Health = MaxHealth;
                Damage = damage;
            }
        }

        class Enderman : Mob
        {
            public Enderman(string name, double health, double damage)
            {
                Name = name;
                MaxHealth = health;
                Health = MaxHealth;
                Damage = damage;
            }

            public bool Stealth()
            {
                Random random = new Random();
                int stealth = random.Next(0, 11);
                if (stealth < 6)
                {
                    Console.WriteLine($"{Name} ухилився від атаки!");
                    return true;
                }
                return false;
            }

            public override void ReceiveDamage(double damage)
            {
                if (!Stealth())
                {
                    base.ReceiveDamage(damage);
                }
                else
                {
                    Console.WriteLine($"{Name} уникнув шкоди!");
                }
            }
        }

    }
}
