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
            public double Health { get; private set; }
            public double MaxHealth { get; private set; }
            public double Damage { get; private set; }
            public string Name { get; private set; }

            public bool IsAlive => Health > 0;

            public void ReceiveDamage(double damage) 
            { 
                for(double i = Health; i > 0; i--)
                {
                    if (Health <= 0)
                    {
                      
                    }
                }
            }
            public void DealDamage(Mob mob) { ... }
        }

        
        class Player : Mob
        {
            public void Shield()
            { 
            
            }
        }

        
        class Zombie : Mob
        {

        }

        
        class Enderman : Mob
        {
            public void Stealth()
            {

            }
        }


    }
}
