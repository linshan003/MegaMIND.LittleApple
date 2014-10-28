using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour 
{

	public Texture2D idleTexture;
	public Texture2D ActiveTexture;

	private GameController gameController;

	void Awake()
	{
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
	}
	void OnMouseOver()
	{
		GetComponent<GUITexture> ().texture = ActiveTexture;
	}
	void OnMouseExit()
	{
		GetComponent<GUITexture> ().texture = idleTexture;
	}
	void OnMouseDown()
	{
		gameController.StartGame ();
	}
}
