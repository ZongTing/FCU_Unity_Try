using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
	private GameController gc;
	public Pole locate;
	public int Size;
	//public float disktargetY;

	void Start()
	{
		//disktargetY = this.transform.position.y;
		gc = GameObject.Find ("GameController").GetComponent<GameController> (); 
	}

	void OnMouseOver()
	{
		if (Input.GetKeyUp(KeyCode.Mouse0)) 
		{	
			gc.SelectDisk(this);
		}
	}
}
