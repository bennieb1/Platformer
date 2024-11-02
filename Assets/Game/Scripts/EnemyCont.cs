using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyCont : MonoBehaviour
{

    public float moveSpeed;
    public Transform lP1, rP2;
    private bool movingRight;
    public SpriteRenderer sr;

    private Rigidbody2D r2;

    public float movingTime, waitingTime;
    private float movingCount, waitingCount;

    private Animator anim;
    private void Start()
    {
        r2 = GetComponent<Rigidbody2D>();
        lP1.parent = null;
        rP2.parent = null;
        anim = GetComponent<Animator>();

        movingCount = movingTime;
    }

    private void Update()
    {

        if (movingCount > 0)
        {

            movingCount -= Time.deltaTime;

            if (movingRight)
            {

                r2.linearVelocity = new Vector2(moveSpeed, r2.linearVelocity.y);
                sr.flipX = true;

                if (transform.position.x > rP2.position.x)
                {

                    movingRight = false;

                }

            }
            else
            {

                r2.linearVelocity = new Vector2(-moveSpeed, r2.linearVelocity.y);
                sr.flipX = false;

                if (transform.position.x < lP1.position.x)
                {
                    movingRight = true;
                }
            }

            if (movingCount<=0)
            {
                waitingCount = Random.Range(waitingTime * .75f, waitingTime * 1.25f);
            }
            
            
            anim.SetBool("isMoving", true);
        }else if (waitingCount > 0)
        {

            waitingCount -= Time.deltaTime;
            r2.linearVelocity = new Vector2(0f, r2.linearVelocity.y);

            if (waitingCount<=0)
            {

                movingCount = Random.Range(movingTime * .75f, waitingTime * .75f);

            }
            anim.SetBool("isMoving", false);
        }
    }
}
