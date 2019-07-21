using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    public Animator animator;

    public int health;
    public GameObject bulletPrefab;
    public GameObject enemyDeathEffect;
    private bool invulnerable = false;

    public Transform firePoint;
    public Transform rayCasting1;
    private RaycastHit2D rayCastCheckHit;
    float lastShotTime;
    float shootCooldown = 3f;
    public float rayCastCheckDistance;
    public LayerMask whatIsEnemy;

    protected int damageIntact;

    protected void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        lastShotTime = Time.time;
    }

    // Update is called once per frame
    protected void Update()
    {
        rayCastCheckHit = Physics2D.Raycast(rayCasting1.position, rayCasting1.right, rayCastCheckDistance, whatIsEnemy);

        if (rayCastCheckHit)
        {
            if (rayCastCheckHit.transform.name == "Zero")
            {
                if (Time.time - lastShotTime >= shootCooldown)
                {
                    animator.SetBool("enemySpotted", true);
                    lastShotTime = Time.time;
                    shoot();
                }
                else
                {
                    animator.SetBool("enemySpotted", false);
                }
            }

        }
    }

    protected void FixedUpdate()
    {
        

    }

    protected void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Debug.Log("shooting");
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if(health <=0)
        {
            decease();
        }
    }

    private void decease()
    {
        Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
