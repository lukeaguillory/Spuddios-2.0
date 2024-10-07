using Assets.Scripts.Queues;

namespace Assets.Scripts.Pawns
{
    public abstract class Pawn : Storable
    {
        public string Name;
        public float Health;
        public float Damage;
        public float MovementSpeed;
        public float Armor;
        public bool IsHostile;

        public void TakeDamage(float amount)
        {
            var newHealth = Health - amount;

            if (newHealth < 0)
                DeathQueue.Enqueue(Id);

            Health = newHealth;
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
