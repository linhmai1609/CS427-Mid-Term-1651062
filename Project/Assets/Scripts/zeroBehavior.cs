using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeroBehavior : player
{
    // Start is called before the first frame update  
    Vector2 zeroPosition;

    public AudioClip[] audioClip;
    AudioSource audioSource;

    //solving attack combo
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 0.25f;

    public GameObject deathEffect;

    new void Start()
    {
        base.Start();
        audioSource = gameObject.GetComponent<AudioSource>();
        zeroPosition = transform.position;     
    }

    // Update is called once per frame
    new void Update()
    {
        if (animator.GetBool("isEntryFinished"))
        {
            base.Update();
            
            if (Input.GetKeyDown(KeyCode.C))
            {
                //OnClick();               
                if (controller.m_Grounded)
                {
                    animator.SetFloat("Speed", 0);
                    preventMoving = true;
                    if (animator.GetFloat("Speed") <= 0.01)
                    {
                        lastClickedTime = Time.time;
                        //print(lastClickedTime);
                        animator.SetInteger("noOfClicks", ++noOfClicks);
                        if (noOfClicks == 1)
                        {
                            animator.SetBool("isSlashing1", true);
                        }
                        noOfClicks = Mathf.Clamp(noOfClicks, 0, 2);
                    }
                }
                else
                    animator.SetBool("isAirSlashing", true);

            }
            if (Time.time - lastClickedTime > maxComboDelay)
            {
                noOfClicks = 0;
                animator.SetInteger("noOfClicks", noOfClicks);
            }
            //if (noOfClicks == 3)
            //{
            //    noOfClicks = 0;
            //    animator.SetInteger("noOfClicks", noOfClicks);
        }
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public new void OnLanding()
    {
        base.OnLanding();
    }    

    public void stopAirSlashing()
    {
        animator.SetBool("isAirSlashing", false);
    }

    public void stopSlashing()
    {
        noOfClicks = 0;
        animator.SetInteger("noOfClicks", 0);
    }

    public void startStage()
    {
        animator.SetBool("isEntryFinished", true);
    }

    public void takeDamage(int damage)
    {
        Debug.Log(health);
        health -= damage;
        if (health <= 0)
        {
            decease();
        }
    }

    private void decease()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void playAudio(int entry)
    {
        audioSource.clip = audioClip[entry];
        audioSource.Play();
    }


    //void OnClick()
    //{
    //    //Record time of last button click
    //    lastClickedTime = Time.time;
    //    ++noOfClicks;
    //    animator.SetInteger("noOfClicks", noOfClicks);
    //    if (noOfClicks == 1)
    //    {
    //        animator.SetBool("isSlashing1", true);
    //    }
    //    //limit/clamp no of clicks between 0 and 3 because you have combo for 3 clicks
    //    noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
    //}

    //IEnumerator slashTimer()
    //{
    //    switch (slashCount)
    //    {
    //        case 0:
    //            yield return new WaitForSeconds(0.5f);
    //            break;
    //        case 1:
    //            yield return new WaitForSeconds(0.5f);
    //            break;
    //        case 2:
    //            yield return new WaitForSeconds(0.5f);
    //            break;
    //    }
    //    if (Input.GetKey(KeyCode.C) && slashCount == 0)
    //    {
    //        animator.SetInteger("slashCounter", ++slashCount);
    //        StartCoroutine(slashTimer());
    //    }
    //    else if (Input.GetKey(KeyCode.C) && slashCount == 1)
    //    {
    //        animator.SetInteger("slashCounter", ++slashCount);
    //        StartCoroutine(slashTimer());
    //    }
    //    else if (Input.GetKey(KeyCode.C) && slashCount == 2)
    //    {
    //        animator.SetInteger("slashCounter", ++slashCount);
    //        StartCoroutine(slashTimer());
    //    }
    //    else if (Input.GetKey(KeyCode.C) && slashCount == 3)
    //    {
    //        yield return new WaitForSeconds(0.5f);
    //        StartCoroutine(slashTimer());
    //    }
    //    else
    //    {
    //        animator.SetBool("isSlashing", false);
    //        animator.SetInteger("slashCounter", 0);
    //        slashCount = 0;
    //    }
    //}


}


