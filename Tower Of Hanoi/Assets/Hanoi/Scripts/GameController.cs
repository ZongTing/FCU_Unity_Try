using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public Disk selectedDisk;
	public Disk[] disks;//預設給三個Disks
	public Pole selectedPole;

	void Start()
	{
		//預設值 Push進三個Disk
		for(int i = disks.Length - 1; i >= 0; i--)
		{
			disks[i].locate.Deck.Push (disks [i]);
		}
	}

	void Update()
	{
//		Debug.Log (selectedDisk);
//		Debug.Log (selectedPole);
		Move ();
	}

	public void SelectDisk(Disk newDisk)
	{
		//判斷是否為最上面的Disk
		if(newDisk.locate.Deck.Peek () == newDisk)
		{
			selectedDisk = newDisk;
			//Debug.Log ("目前選取的Disk:" + selectedDisk);
		}
	}

	public void SelectPole(Pole newPole)
	{
		if (selectedDisk != null)
		{
			selectedPole = newPole;	
			//Debug.Log ("目前選取的Pole:" + selectedPole);
		}
//		Debug.Log ("最上面的Disk" + selectedPole.Deck.Peek());//顯示被選取的柱子最上面的Disk
//		Debug.Log ("裡面有" + selectedPole.Deck.Count + "個Disk");//顯示被選取的柱子上面有幾個Disk
	}

	private void Move()
	{
		if (selectedDisk != null && selectedPole != null)
		{
			if (selectedPole.Deck.Count == 0)
			{
				PushinPole ();
				selectedDisk.locate = selectedPole;
				selectedDisk = null;
				selectedPole = null;
			}
			else if(selectedDisk.Size < selectedPole.Deck.Peek ().Size)
			{
				PushinPole ();
				selectedDisk.locate = selectedPole;
				selectedDisk = null;
				selectedPole = null;
			}
			else if(selectedDisk.Size > selectedPole.Deck.Peek ().Size)
			{
				Debug.Log ("不可以這樣放");
			}
		}

	}
		
	public void PushinPole()
	{
		selectedDisk.locate.Deck.Pop (); //將被選取Disk的柱子上的最上面一個Disk給移除
		selectedDisk.transform.position = new Vector3 (selectedPole.poletargetX, 5, 0);
		selectedPole.Deck.Push (selectedDisk);//將被選取的Disk Push進被選取的Pole
	}

}