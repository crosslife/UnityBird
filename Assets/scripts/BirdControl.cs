using UnityEngine;
using System.Collections;

public class BirdControl : MonoBehaviour {

	public int rotateRate = 10;
	public float upSpeed = 10;
    public GameObject scoreMgr;

	private bool dead = false;
	private bool landed = false;

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!dead)
		{
			if (Input.GetButtonDown("Fire1"))
			{
				transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, upSpeed);
			}
		}

		if (!landed)
		{
			float v = transform.GetComponent<Rigidbody2D>().velocity.y;
			
			float rotate = Mathf.Min(Mathf.Max(-90, v * rotateRate + 60), 30);
			
			transform.rotation = Quaternion.Euler(0f, 0f, rotate);
		}
		else
		{
			transform.GetComponent<Rigidbody2D>().rotation = -90;
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

			//transform.GetComponent<Animator>().enabled = false;
			anim.SetTrigger("die");

			if (other.name == "land")
			{
				transform.GetComponent<Rigidbody2D>().gravityScale = 0;
				transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

				landed = true;
			}
		}

        if (other.name == "pass_trigger")
        {
            scoreMgr.GetComponent<ScoreMgr>().AddScore();
        }


	}
	
	public void GameOver()
	{
		dead = true;
	}
}
