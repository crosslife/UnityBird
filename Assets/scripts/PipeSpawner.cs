using UnityEngine;
using System.Collections;

public class PipeSpawner : MonoBehaviour {

	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject pipe;	
	public float[] heights;
	
	
	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .		
	}

    public void StartSpawning()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }
	
	
	void Spawn ()
	{
		int heightIndex = Random.Range(0, heights.Length);
		Vector2 pos = new Vector2(transform.position.x, heights[heightIndex]);

		Instantiate(pipe, pos, transform.rotation);
	}

	public void GameOver()
	{
		CancelInvoke("Spawn");
	}
}
