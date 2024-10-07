using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Projectile : MonoBehaviour
    {
        private Vector2 shotDirection;
        private float speed;
        private float damage;
        void Start()
        {

        }

        void Update()
        {
            //make it shoot in a direction
        }

        public void Spawn(Vector2 shotDirection, float speed, float damage)
        {
            this.shotDirection = shotDirection;
            this.speed = speed;
            this.damage = damage;
        }
    }
}
