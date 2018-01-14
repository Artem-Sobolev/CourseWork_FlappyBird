using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {

    public GameObject back;
    public float delayTime;
    private float respawnTimer;
    public static int index = 1;
    
    void Update()
    {
        if (GameManager.gameStart && !GameManager.gameOver)
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer > delayTime)
            {
                var newObject = Instantiate(back, transform.position,
                        transform.rotation);
                newObject.transform.localScale = new Vector3(newObject.transform.localScale.x * index, newObject.transform.localScale.y, newObject.transform.localScale.z);
                index *= -1;
                respawnTimer = 0.0f;
            }
        }
    }
}
