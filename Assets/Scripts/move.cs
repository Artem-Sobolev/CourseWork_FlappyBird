using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    public float speed;
	
	void Update () {
		if(!GameManager.gameOver&&GameManager.gameStart)
			transform.Translate(-Time.deltaTime * speed, 0, 0);
	}
}
