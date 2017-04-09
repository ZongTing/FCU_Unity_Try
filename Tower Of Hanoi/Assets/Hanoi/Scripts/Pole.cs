using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
	private GameController gc;
	public float poletargetX;
	public Stack<Disk> Deck = new Stack<Disk>();

	void Start()
	{
		poletargetX = this.transform.position.x;
		gc = GameObject.Find ("GameController").GetComponent<GameController> ();
	}

	void OnMouseOver()
	{
		if (Input.GetKeyUp(KeyCode.Mouse0)) 
		{
			gc.SelectPole (this);
		}
	}
}