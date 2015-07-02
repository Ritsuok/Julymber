using UnityEngine;
using System.Collections;

public class StartBtn : MonoBehaviour {
	private GameObject playerObj;
	private PlayerControll playercontroll;

	private GameObject retryBtn;
	
	// Use this for initialization
	void Start () {
		gameObject.SetActive (true);
		playerObj = GameObject.Find("Boxs2nd1");
		playercontroll = playerObj.GetComponent<PlayerControll>();

		retryBtn = GameObject.Find ("ButtonRetry");
		retryBtn.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void fLetsStart(){
		gameObject.SetActive (false);
		retryBtn.SetActive (true);
		playercontroll.fNextMove();
	}
	public void fStartBtnOn(){
		gameObject.SetActive (true);
		retryBtn.SetActive (false);
	}
	public void fStartBtnOff(){
		gameObject.SetActive (false);
		retryBtn.SetActive (true);
	}
}