using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour
{
    public GameObject pipes;
    public float delayTime;
    private float respawnTimer;

    void Update()
    {
        if (GameManager.gameStart && !GameManager.gameOver)
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer > delayTime)
            {
                var newObject = Instantiate(pipes, transform.position,
                        transform.rotation);
                respawnTimer = 0.0f;
            }
        }
    }
}
