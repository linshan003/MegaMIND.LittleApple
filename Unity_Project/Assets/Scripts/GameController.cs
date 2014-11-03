using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public Camera cam;
	public GameObject[] balls;
	public float time;
	public GUIText Timer;
	public GameObject startButton;
	public GameObject splashScreen;
	public GameObject gameOverText;
	public GameObject restart;
	public HatController hatController;
	public int life ;
	//public AudioClip littleApple;

	private float maxWidth;
	private bool playing;

	void Start()
	{
		if(cam == null)
		{
			cam = Camera.main;
		}
		playing = false; 
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);

		float ballWidth = balls[0].renderer.bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;

		UpdateText ();
	}

	void Update()
	{
		if(life <= 0)
		{
			playing = false;
		}
		hatController.ToggleControl (playing);
		//UpdateText ();
	}
	void FixedUpdate()
	{
		if(playing)
		{
			time += Time.deltaTime;
			
			if(time < 0) 
				time = 0;

		}
		UpdateText ();

	} 

	public void  StartGame()
	{
		splashScreen.SetActive (false);
		startButton.SetActive (false);
		StartCoroutine (Spawn ());
		hatController.ToggleControl (true);
	}
	IEnumerator Spawn()
	{
		yield return new WaitForSeconds (2.0f);
		playing = true;
		audio.Play ();
		while(playing)
		{
			GameObject ball = balls[Random.Range(0,balls.Length)];
			Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth, maxWidth),transform.position.y, 0.0f); 

			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (ball, spawnPosition, spawnRotation);

			yield return new WaitForSeconds(4.0f/(time/3 + 2.0f));
		}
		//yield return new WaitForSeconds (2.0f);
		audio.Stop ();
		gameOverText.SetActive (true);
		//yield return new WaitForSeconds (2.0f);
		restart.SetActive (true);

	}
	void UpdateText()
	{
		Timer.text = "Time: \n" +  Mathf.FloorToInt(time); 
	}
}
