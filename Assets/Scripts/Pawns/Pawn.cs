using Assets.Scripts.Queues;
using Assets.Scripts.Weapons;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Pawns
{
    public class Pawn : Storable
    {
        public string Name;
        public float maxHealth;
        public float currentHealth;
        private float Damage;
        public float MovementSpeed;
        public float Armor;
        public bool IsHostile;
        public float toHit;
        public float meleeDamageDiceCount;
        public float meleeMaxDieValue;
        public float meleeFlatDamage;
        public GameObject hitTextObject;
        public GameObject missTextObject;
        public bool canMelee;
        public float hitRate;
        public float nextHit;

        public void TakeDamage(float amount)
        {
            var newHealth = currentHealth - amount;

            if (newHealth <= 0)
            {
                Repository.RemoveEnemy(Id);
               // DeathQueue.Enqueue(Id);
            }

            currentHealth = newHealth;
        }

        public string CheckForHit(float toHit)
        {
            float hitRoll = UnityEngine.Random.Range(1, 20);
            if (hitRoll == 20)
            {
                return "crit";
            }
            else if (hitRoll + toHit > Armor)
            {
                return "y";
            }
            else
            {
                return "n";
            }
        }

        public void SetName(string name)
        {
            Name = name; 
        }

        public void SetDamage(float amount)
        {
            Damage = amount;
        }
    }
}
