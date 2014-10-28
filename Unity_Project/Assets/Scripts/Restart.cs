using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour
{
	public Texture2D idle;
	public Texture2D OnActivate;

	public void OnMouseDown()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	public void OnMouseOver()
	{
		GetComponent<GUITexture> ().texture = OnActivate;
	}
	public void OnMouseExit()
	{
		GetComponent<GUITexture> ().texture = idle;
	}
}
