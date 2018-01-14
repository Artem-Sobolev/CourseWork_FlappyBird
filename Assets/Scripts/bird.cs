using UnityEngine;
using System.Collections;

public class bird : MonoBehaviour
{
    public float upForce;
    public float rotz;
    public float some;
    public float downVel;
    private Vector3 birdPos;
    public AudioClip hit;
    public AudioClip wing;
    public AudioClip point;

    void Start()
    {
        rotz = 0;
        birdPos = transform.position;
    }

    void Update()
    {
        if (!GameManager.gameStart)
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        else
            GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        var pos = new Vector3(birdPos.x, transform.position.y, transform.position.z);
        transform.position = pos;
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !GameManager.gameOver && GameManager.gameStart)
        {
            AudioSource.PlayClipAtPoint(wing, Camera.main.transform.position);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, upForce);
        }
        if (GetComponent<Rigidbody2D>().velocity.y < upForce - some && transform.rotation.y > -90 && GameManager.gameStart)
        {
            rotz = Mathf.Lerp(rotz, -90f, Time.deltaTime);
            var rot = Quaternion.Euler(0, 0, rotz);
            transform.rotation = rot;
        }
        else
        {
            if (!GameManager.gameOver && GameManager.gameStart)
            {
                rotz = Mathf.Lerp(rotz, 25f, Time.deltaTime * 6);
                var rot = Quaternion.Euler(0, 0, rotz);
                transform.rotation = rot;
            }
        }

        if (!GameManager.gameStart)
        {
            Vector3 temp = new Vector3(transform.position.x, 0.9118328f, transform.position.z);
            transform.position = temp;
        }

        if (transform.position.y < -2.72)
        {
            Vector3 temp = new Vector3(transform.position.x, -2.72f, transform.position.z);
            var tempRot = Quaternion.Euler(0, 0, -90f);
            transform.position = temp;
            transform.rotation = tempRot;
        }

        if(transform.position.y > 4.3)
        {
            transform.position = new Vector3(transform.position.x, 4.3f, transform.position.z);
        }

        if (GetComponent<Rigidbody2D>().velocity.y < downVel)
        {
            Vector3 tempVel = new Vector3(0f, downVel, 0f);
            GetComponent<Rigidbody2D>().velocity = tempVel;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "scoreMaker")
        {
            AudioSource.PlayClipAtPoint(point, Camera.main.transform.position);
            GameManager.score += 1;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag != "Background")
        {
            gameObject.GetComponent<Collider2D>().isTrigger = false;
            AudioSource.PlayClipAtPoint(hit, Camera.main.transform.position);

            int[] records = new int[5];
            records[0] = PlayerPrefs.GetInt("highscore");
            records[1] = PlayerPrefs.GetInt("second");
            records[2] = PlayerPrefs.GetInt("third");
            records[3] = PlayerPrefs.GetInt("fourth");
            records[4] = PlayerPrefs.GetInt("fifth");

            if (GameManager.score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", GameManager.score);
                guiManager.medal = true;
            }

            if ((GameManager.score != records[0]) && (GameManager.score != records[1]) && (GameManager.score != records[2]) && (GameManager.score != records[3]) && (GameManager.score != records[4]) & (GameManager.score > records[4]))
            {
                for (int i = 0; i < records.Length; i++)
                {
                    if (records[i] < GameManager.score)
                    {
                        for (int j = records.Length - 1; j > i; j--)
                        {
                            records[j] = records[j - 1];
                        }
                        records[i] = GameManager.score;
                        break;
                    }
                }
                PlayerPrefs.SetInt("highscore", records[0]);
                PlayerPrefs.SetInt("second", records[1]);
                PlayerPrefs.SetInt("third", records[2]);
                PlayerPrefs.SetInt("fourth", records[3]);
                PlayerPrefs.SetInt("fifth", records[4]);
            }

            GameManager.gameOver = true;
            background.index = 1;
        }
    }
}
