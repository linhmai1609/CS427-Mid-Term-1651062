using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantKillBehavior : MonoBehaviour
{
    int damage = 120;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Zero")
        {
            //if (collision.otherCollider.usedByComposite)
            //{

            zeroBehavior zero = collision.collider.GetComponent<zeroBehavior>();
            if (zero != null)
            {
                zero.takeDamage(damage);
            }
            //}
        }
    }
}
