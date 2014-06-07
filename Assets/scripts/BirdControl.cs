using UnityEngine;
using System.Collections;

public class BirdControl : MonoBehaviour {

	public int rotateRate = 10;
	public float upSpeed = 10;

	private bool dead = false;
	private bool landed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!dead)
		{
			if (Input.GetButtonDown("Fire1"))
			{
				transform.rigidbody2D.velocity = new Vector2(0, upSpeed);
				Debug.Log("fire");
			}
		}

		if (!landed)
		{
			float v = transform.rigidbody2D.velocity.y;
			
			float rotate = Mathf.Min(Mathf.Max(-90, v * rotateRate + 60), 30);
			
			transform.rotation = Quaternion.Euler(0f, 0f, rotate);
		}
		else
		{
			transform.rigidbody2D.rotation = -90;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "land" || other.name == "pipe_up" || other.name == "pipe_down")
		{
			GameObject[] objs = GameObject.FindGameObjectsWithTag("movable");
			foreach(GameObject g in objs)
			{
				g.BroadcastMessage("GameOver");
			}

			transform.GetComponent<Animator>().enabled = false;

			if (other.name == "land")
			{
				transform.rigidbody2D.gravityScale = 0;
				transform.rigidbody2D.velocity = new Vector2(0, 0);

				landed = true;
			}
		}


	}
	
	public void GameOver()
	{
		dead = true;
	}
}
