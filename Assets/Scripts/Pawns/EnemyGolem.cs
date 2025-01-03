using Assets.Scripts.Pawns;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyGolem : Enemy
{
    private bool isFlipped;

    // Start is called before the first frame update
    void Start()
    {
        name = "Golem" + Id;
        nextHit = Time.time;
        m_Animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerChase();
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
                m_Animator.SetTrigger("Attack" + Random.Range(1, 2));
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
}
