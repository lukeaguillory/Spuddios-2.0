using Assets.Scripts.Weapons;
using Cainos.PixelArtTopDown_Basic;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Pawns
{
    public class Enemy : Pawn
    {
        [SerializeField]
        public GameObject player;
        private float distance;
        public Animator m_Animator;

        // Start is called before the first frame update
        void Start()
        {

        }

        

        // Update is called once per frame
        public void PlayerChase()
        {
            player = Repository.FirstOrDefault<GameObject>(Player.ID);
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, MovementSpeed * Time.deltaTime);
        }

        public bool CheckIfTimeToMelee()
        {
            if (Time.time > nextHit && this.GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>()) && canMelee)
            {
                nextHit = Time.time + hitRate;
                return true;
            } else
            {
                return false;
            }
        }

        public float RollForDamage()
        {
            return (float) Math.Round(UnityEngine.Random.Range(meleeDamageDiceCount + meleeFlatDamage, 
                (meleeDamageDiceCount * meleeMaxDieValue) + meleeFlatDamage));
        }
    }
}
