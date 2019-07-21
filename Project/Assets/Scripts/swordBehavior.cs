using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordBehavior : MonoBehaviour
{
    string enemyLayer;
    public GameObject zero;
    int dmg1 = 20, dmg2 = 30, dmg3 = 50;

    // Start is called before the first frame update
    void Start()
    {
        //zero = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        enemyLayer = LayerMask.LayerToName(collision.gameObject.layer);
        if (enemyLayer == "Enemy")
        {
            Debug.Log("hit");
            enemyBehavior enemy = collision.GetComponent<enemyBehavior>();
            if (enemy != null)
            {
                if (!zero.GetComponent<Animator>().GetBool("isGrounded"))
                    enemy.takeDamage(dmg1);
                else
                {
                    switch (zero.GetComponent<Animator>().GetInteger("noOfClicks"))
                    {
                        case 1:
                            enemy.takeDamage(dmg1);
                            break;
                        case 2:
                            enemy.takeDamage(dmg2);
                            break;
                        case 3:
                            enemy.takeDamage(dmg3);
                            break;

                    }
                }
            }
        }
    }


}

