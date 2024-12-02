using Assets.Scripts.Pawns;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Projectile : MonoBehaviour
    {
        Rigidbody2D rb;
        private Vector2 shotDirection;

        [SerializeField]
        private float speed;

        [SerializeField]
        private float damage;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            shotDirection = transform.up;
            rb.velocity = speed * transform.up;
            
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.name.Equals("Leeten"))
            {
                Debug.Log(collision.gameObject.name + " hit!");
                Destroy(gameObject);
                EnemyStatue enemy = collision.gameObject.GetComponent<EnemyStatue>();
                enemy.TakeDamage(damage);
                if (enemy.Health <= 0)
                    Destroy(collision.gameObject);
                Debug.Log("Enemy has " + enemy.Health + " health left.");
            }
            

            
        }
    }
}
