using Assets.Scripts.Pawns;
using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Pawns
{
    public class EnemyStatue : Enemy
    {
        

        // Start is called before the first frame update
        void Start()
        {
            Id = System.Guid.NewGuid().ToString();
            name = "EnemyStatue" + Id;
        }

        // Update is called once per frame
        void Update()
        {
            PlayerChase();
        }
    }
}