using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Pawns
{
    public class Enemy : Pawn
    {
        [SerializeField]
        public GameObject player;
        private float distance;

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
    }
}
