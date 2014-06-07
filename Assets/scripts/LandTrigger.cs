using UnityEngine;
using System.Collections;

public class LandTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameOver()
	{
		transform.GetComponent<Animator>().enabled = false;
	}
}
