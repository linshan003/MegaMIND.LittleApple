using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour 
{
	public GameController gameController;

	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy (other.gameObject);
		if (other.gameObject.tag == "Bomb")
						return;
		else
		{
			//gameController.life --;
		}
	}

}
