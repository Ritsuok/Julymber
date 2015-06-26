using UnityEngine;
using System.Collections;

public class DropCubBtnKawashima : MonoBehaviour {
	private GameObject main;
	private MainKawashima mainkawashima;
	public bool isStraightNoMore = false;
	public bool isLeftNoMore = false;
	public bool isRightNoMore = false;
	// Use this for initialization
	void Start () {
		main =  GameObject.Find ("Main");
		mainkawashima = main.GetComponent<MainKawashima> ();


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void fStraightClicked(){
		print("isStraightNoMore =  + isStraightNoMore");
		if(isStraightNoMore) {
			return;
		}
		print ("start fStraightClicked");
		main.SendMessage ("fStraightUsed");
		mainkawashima.fDrop (0);
	}
	public void fLeftClicked(){
		print ("start fLeftClickedClicked");
		if(isLeftNoMore) {
			return;
		}
		main.SendMessage ("fLeftUsed");
		mainkawashima.fDrop (1);
	}
	public void fRightClicked(){
		print ("start fRightClicked");
		if(isRightNoMore) {
			return;
		}
		main.SendMessage ("fRightUsed");
		mainkawashima.fDrop (2);
	}
}