using UnityEngine;
using System.Collections;

public class tap : MonoBehaviour {
    
	void Start () {
		GetComponent<Renderer>().enabled = true;
	}
	
	void Update () {
		if (GameManager.gameStart)
						GetComponent<Renderer>().enabled = false;
	
	}
}
