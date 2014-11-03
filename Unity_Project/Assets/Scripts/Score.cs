using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public GUIText scoreText;
	public int ballValue;
	public GameController gameController;

	private int score;
	// Use this for initialization
	void Start () 
	{
		score = 0;
		UpdateScore ();
	}
	void Update()
	{
		UpdateScore ();
	}

	void OnTriggerEnter2D()
	{
		audio.Play ();
		score += ballValue;
		gameController.life ++;
	}
/*
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Bomb")
		{
			score -= ballValue * 2;
		}
	}
*/
	// Update is called once per frame
	void UpdateScore () {
		scoreText.text = "Score: \n" + score;
	}
}
