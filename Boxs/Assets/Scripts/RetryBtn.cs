using UnityEngine;
using System.Collections;

public class RetryBtn : MonoBehaviour {
	private GameObject startBtn;
	private StartBtn startbtnScript;
	// Use this for initialization
	void Start () {

		
		startBtn = GameObject.Find ("ButtonStart");
		startbtnScript = startBtn.GetComponent<StartBtn> ();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void fLetsRetry(){
		startbtnScript.fStartBtnOn ();

	}
}