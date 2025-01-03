using Assets.Scripts.Pawns;
using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Assets.Scripts.Pawns
{
    public class EnemyStatue : Enemy
    {
        

        // Start is called before the first frame update
        void Start()
        {
            name = "Statue" + Id;
            nextHit = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            PlayerChase();
            if (CheckIfTimeToMelee())
            {
                Player leeten = player.GetComponent<Player>();
                string isHit = leeten.CheckForHit(toHit);
                if (!toHit.Equals("n"))
                {
                    float Damage = RollForDamage();
                    GameObject hitTextObjectTemp = Instantiate(hitTextObject, gameObject.transform.position, Quaternion.identity);
                    string hitText = "";

                    if (isHit.Equals("crit"))
                    {
                        Damage += Damage;
                        hitText += "Critical! ";

                    }
                    hitText += Damage + "!";

                    hitTextObjectTemp.GetComponent<TextMeshPro>().SetText(hitText);
                    hitTextObjectTemp.GetComponent<TextTimer>().thisText = hitTextObjectTemp;

                    leeten.TakeDamage(Damage);
                }
                else
                {
                    GameObject missTextObjectTemp = Instantiate(missTextObject, gameObject.transform.position, Quaternion.identity);
                    missTextObjectTemp.GetComponent<TextTimer>().thisText = missTextObjectTemp;
                }
            }
        }

    }
}