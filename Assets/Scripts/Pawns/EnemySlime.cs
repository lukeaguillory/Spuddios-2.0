using Assets.Scripts.Pawns;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySlime : Enemy
{
    private bool isFlipped;

    // Start is called before the first frame update
    void Start()
    {
        name = "Slime" + Id;
        nextHit = Time.time;
        m_Animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerChase();
        FlipMob();

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

    public void AnimateOnHit()
    {
        m_Animator.SetTrigger("Hit");
    }

    void FlipMob()
    {
        if (player.transform.position.x < gameObject.transform.position.x && !isFlipped)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            isFlipped = true;
        }

        if (player.transform.position.x > gameObject.transform.position.x && isFlipped)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            isFlipped = false;
        }
    }
}
