using Assets.Scripts;
using Assets.Scripts.Pawns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Felix : MonoBehaviour
{
    
    public GameObject player;
    Animator m_Animator;
    public float speed;
    private float distance;
    private bool isClose;
    private bool isFlipped;
    private Vector2 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        isClose = true;
    }

    // Update is called once per frame
    void Update()
    {
        player = Repository.FirstOrDefault<GameObject>(Player.ID);
        distance = Vector2.Distance(transform.position, player.transform.position);
        //Debug.Log(m_Animator.GetCurrentAnimatorStateInfo());
        if (distance <= 0.75)
        {
            isClose = true;
            
        }
        else
        {
            isClose = false;
            
        }

        if (previousPosition.Equals(gameObject.transform.position))
        {
            m_Animator.SetBool("isIdle", true);
        } else
        {
            m_Animator.SetBool("isIdle", false);
            previousPosition = gameObject.transform.position;
        }

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

        if (!isClose)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
    }
}
