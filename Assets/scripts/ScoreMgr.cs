using UnityEngine;
using System.Collections;

public class ScoreMgr : MonoBehaviour {

	public GameObject[] scorePrefabs;
	public float digitOffset;

	private GameObject[] nowShowScores = new GameObject[5];
    private int nowScore = 0;

    void Start()
    {
        nowScore = 0;
        SetScore(nowScore);
    }

    public void AddScore()
    {
        nowScore ++;
        SetScore(nowScore);
    }

    public void SetScore(int score)
	{
		int tmpScore = score;
		int []digits = new int[5];
		int index = 0;

		do {
			digits[index] = tmpScore % 10;
			tmpScore = tmpScore / 10;
			index ++;
		} while (tmpScore != 0);

		int scoreSize = 1;
		for (int i=0; i< 5; i++) 
		{
			if (digits[i] != 0)
			{
				scoreSize = i + 1;
			}	
		}
		scoreSize = scoreSize == 0 ? 1 : scoreSize;

        float nowOffset = (scoreSize - 1) * digitOffset / 2;
		for (int i = 0; i < scoreSize; i++)
		{
            if(nowShowScores[i] != null)
            {
                Destroy(nowShowScores[i]);
            }

            float nowX = transform.position.x + nowOffset;

            Vector2 pos = new Vector2(nowX, transform.position.y);

            nowShowScores[i] = Instantiate(scorePrefabs[digits[i]], pos, transform.rotation) as GameObject;
            nowOffset -= digitOffset;
		}
	}
}
