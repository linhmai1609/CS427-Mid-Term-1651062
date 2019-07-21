using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Behavior : enemyBehavior
{    
    public float wallCheckDistance;
    public LayerMask whatIsGround;
    
    private RaycastHit2D wallCheckHit;    
    bool flipped = false;

    float horizontalMove = 0f;
    protected float speed = 10f;
    public Transform rayCasting2;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();      
    }

    new void Update()
    {
        base.Update();
       
        if (flipped)
        {
            horizontalMove = -1f * speed;
        }
        else
        {
            horizontalMove = 1f * speed;
        }
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    private new void FixedUpdate()
    {
        base.FixedUpdate();
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);

        wallCheckHit = Physics2D.Raycast(rayCasting2.position, rayCasting2.right, wallCheckDistance, whatIsGround);

        if (wallCheckHit)
        {
            //Debug.Log(wallCheckHit.transform.name);
            //if (wallCheckHit.transform.name == "Grid" || wallCheckHit.transform.name == "Confiner")
            //{
                flipped = !flipped;
            //}
        }             
        
    }
    // Update is called once per frame
}
