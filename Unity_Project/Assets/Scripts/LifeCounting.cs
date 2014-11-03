using UnityEngine;
using System.Collections;

public class LifeCounting : MonoBehaviour 
{
	public GUIText lifeText;
	public GameController gameController;

/*	void Update()
	{
		UpdateLife ();
	}
*/
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Bomb")
		{
			gameController.life = 0;
		}
	}


	void UpdateLife()
	{
		lifeText.text = "Life : \n" + gameController.life;
	}
}
