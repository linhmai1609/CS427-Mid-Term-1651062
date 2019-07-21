using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drillBehavior : instantKillBehavior
{
    public bool active = false;
    public float distance;
    float downwardSpeed = 0.5f;
    float upwardSpeed = 0.01f;
    Animator animator;
    Vector2 origin;
    Vector2 current;
    float cooldown = 0.1f;
    float oldTime;    

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        origin = current = transform.position;

        oldTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (origin.y - transform.position.y <= 0 && Time.time - oldTime >= cooldown)
            {
                animator.SetBool("isStartle", false);
                animator.SetBool("isGoingDown", true);

                StartCoroutine(jumpTimer());
            }
            if (origin.y - transform.position.y <= distance)
            {
                animator.SetBool("isGoingDown", false);
                animator.SetBool("isReturning", true);
                current.y += upwardSpeed;
                //Debug.Log(current);
            }
            if (origin.y - transform.position.y <= 0)
            {
                animator.SetBool("isReturning", false);
                animator.SetBool("isStartle", true);
            }
            transform.position = current;
        }
        else
            oldTime = Time.time;
    }

    IEnumerator jumpTimer()
    {
        yield return new WaitForSeconds(0.2f);
        current.y -= downwardSpeed;
    }  
}

