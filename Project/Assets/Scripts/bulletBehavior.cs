using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 10f;
    public Rigidbody2D rb;
    int damage = 10;

    public float rayCastCheckDistance;
    public LayerMask whatIsEnemy;
    public Transform rayCasting1;
    private RaycastHit2D rayCastCheckHit;

    float lastShotTime;

    void Start()
    {
        rb.velocity = transform.right * speed;
        lastShotTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rayCastCheckHit = Physics2D.Raycast(rayCasting1.position, rayCasting1.right, rayCastCheckDistance, whatIsEnemy);

        if (collision.transform.name == "Zero" || Time.time - lastShotTime > 6)
        {
            Debug.Log(collision.name);
            Destroy(gameObject);
        }
        zeroBehavior zero = collision.GetComponent<zeroBehavior>();
        if (zero != null)
        {
            zero.takeDamage(damage);
        }
    }
}
