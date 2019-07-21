using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnTrigger : MonoBehaviour
{
    public GameObject[] enemies;
    public float[] Xs;
    public float[] Ys;
    bool isTriggered = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggered)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].transform.position = new Vector2(Xs[i], Ys[i]);
                Instantiate(enemies[i]);
            }
            isTriggered = true;
        }
    }
}
