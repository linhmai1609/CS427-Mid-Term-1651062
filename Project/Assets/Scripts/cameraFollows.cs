using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollows : MonoBehaviour
{
    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    public bool bounds;

    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        //if (player.transform.position.x <= minX)
        //{
        //    transform.position = new Vector2(minX, player.transform.position.y);
        //}
        //if (player.transform.position.x >= maxX)
        //{
        //    transform.position = new Vector2(maxX, player.transform.position.y);
        //}
        //if (player.transform.position.y <= minY)
        //{
        //    transform.position = new Vector2(player.transform.position.x, minY);
        //}
        //if (player.transform.position.x >= maxY)
        //{
        //    transform.position = new Vector2(player.transform.position.x, maxY);
        //}
    }
}
