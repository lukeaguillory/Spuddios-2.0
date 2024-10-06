using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Weapons
{
    public abstract class Weapon : Storable
    {
        public string Name { get; set; }
        public float AttackRate;
        public float AttackDamage;

        public void SetStats(string name, float rate, float damage)
        {
            Name = name;
            AttackRate = rate;
            AttackDamage = damage;
        }
    }
}
