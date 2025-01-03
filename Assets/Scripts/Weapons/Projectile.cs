using Assets.Scripts.Pawns;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Projectile : MonoBehaviour
    {
        Rigidbody2D rb;
        public Vector2 shotDirection;

        [SerializeField]
        private float speed;

        private float damage;
        public float damageDiceCount;
        public float maxDieValue;
        public float flatDamage;
        private float toHit;
        public float maxFlightTime;
        private float currentFlightTime;
        public float collateralChance;

        public GameObject caster;
        public GameObject hitTextObject;
        public GameObject missTextObject;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            damage = (float) Math.Round(UnityEngine.Random.Range(damageDiceCount + flatDamage, (damageDiceCount * maxDieValue) + flatDamage));
            rb.velocity = speed * shotDirection;
            toHit = caster.GetComponent<Player>().toHit;
            currentFlightTime = 0;
        }

        void Update()
        {
            //make it shoot in a direction
            currentFlightTime += Time.deltaTime;

            if (currentFlightTime >= maxFlightTime)
                Destroy(gameObject);
        }

        public void Spawn(Vector2 shotDirection, float speed, float damage)
        {
            this.shotDirection = shotDirection;
            this.speed = speed;
            this.damage = damage;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.name.Equals(caster.name))
            {
                Pawn victim = collision.gameObject.GetComponent<Pawn>();
               
                string isHit = victim.CheckForHit(toHit);
                if (!isHit.Equals("n"))
                {
                    //if (collision.gameObject.name.StartsWith("EnemyGolem"))
                    //    collision.gameObject.GetComponent<EnemyGolem>().AnimateOnHit();

                    GameObject hitTextObjectTemp = Instantiate(hitTextObject, gameObject.transform.position, Quaternion.identity);
                    string hitText = "";

                    if (isHit.Equals("crit"))
                    {
                        damage += damage;
                        hitText += "Critical! ";
                        
                    }
                    hitText += damage + "!";

                    hitTextObjectTemp.GetComponent<TextMeshPro>().SetText(hitText);
                    hitTextObjectTemp.GetComponent<TextTimer>().thisText = hitTextObjectTemp;

                   
                    victim.TakeDamage(damage);
                    if (victim.currentHealth <= 0)
                        Destroy(collision.gameObject);

                    if (!(UnityEngine.Random.Range(0, 100) <= collateralChance))
                        Destroy(gameObject);
                    

                } else
                {
                    GameObject missTextObjectTemp = Instantiate(missTextObject, gameObject.transform.position, Quaternion.identity);
                    missTextObjectTemp.GetComponent<TextTimer>().thisText = missTextObjectTemp;
                }
            }
        }
    }
}
