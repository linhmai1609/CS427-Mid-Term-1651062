using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    AudioSource audioSource;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doneExplode()
    {
        Destroy(gameObject);
    }

    //public void playAudio()
    //{
    //    audioSource.Play();
    //}
}
