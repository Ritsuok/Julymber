﻿using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {
	const int NONE =0;
	const int BLOCK =1;
	const int GOAL =2;
	
	//********************************************* 0620 yamaguchi start
	const int RIGHT = 3;
	const int LEFT = 4;
	
	const int LOWBLOCK = 5;
	//********************************************* 0620 yamaguchi finish
	
	const int SPLING = 6;
	
	public float speed;
	
	public int frontFlg = NONE;
	public int downFlg = BLOCK;
	public int upFlg = NONE;
	public int floorFlg = BLOCK;
	
	Animator anim;
	bool isGoAhead;
	
	string direction;
	
	void Awake()
	{
		downFlg = BLOCK;
		
		direction = "North";
		
		anim = GetComponent<Animator> ();
		anim.SetBool ("isMove", true);
		
		isGoAhead = true;
	}
	
	// Use this for initialization
	void Start () {
		//		fClimbPlayer ();

		fNextMove ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	
	//********************************************* 0620 yamaguchi start
	public void fNextMove()
	{
		print ("fNextMove player.position = " + transform.position.x + " , " + transform.position.y + " , " + transform.position.z);
		print ("floorFlg = " + floorFlg + " downFlg = " + downFlg);
		
		if (floorFlg == GOAL) {
			print ("fGoalPlayer");
			StartCoroutine ("fGoalPlayer");
		}
		
		//********************************************* 0620 yamaguchi start
		else if (floorFlg == RIGHT) {
			print ("ん");
			print ("fTurnRightPlayer");
			StartCoroutine ("fTurnRightPlayer");
			
			//********************************************* 0620 yamaguchi start
		} else if (floorFlg == LEFT) {
			print ("fTurnLeftPlayer");
			StartCoroutine ("fTurnLeftPlayer");
		}
		//********************************************* 0620 yamaguchi finish
		
		else if (frontFlg == BLOCK && upFlg == BLOCK) {
			print ("fTrouble");
			fTroublePlayer ();
		}
		//********************************************* 0620 yamaguchi finish
		
		else if (frontFlg == BLOCK) {
			print ("fClimbPlayer");
			StartCoroutine ("fClimbPlayer");
		}
/*		//********************************************* 0620 yamaguchi finish
		else if (floorFlg == NONE) {
			print ("fFallPlayer");
			StartCoroutine("fFallPlayer");
		}
*/
		else if (downFlg == NONE) {
			print ("fDownPlayer");
			StartCoroutine ("fDownPlayer");
		}
/*		else if (floorFlg == SPLING) {

			print ("fSpling1Player");
			StartCoroutine ("fSpling1Player");
		}
*/
		else if (frontFlg== NONE)
		{
			print ("fWalkPlayer");
			StartCoroutine ("fWalkPlayer");
		}
		
	}
	
	
	//********************************************* 0620 yamaguchi finish
	//Walk Player
	//*******************************************************************
	
	IEnumerator fWalkPlayer()
	{
		//GetComponent<Rigidbody> ().useGravity = true;
		//GetComponent<CapsuleCollider> ().enabled = true;
		print ("fWalkPlayer" + transform.position.z);
		
		for (int i = 0; i < (int)(1.0f / speed); i++)
		{
			transform.Translate (0, 0, speed);
			yield return new WaitForSeconds (0.01F);
			
		}
		
		//残りの移動
		transform.Translate (0, 0, 1.0f - (int)(1.0f / speed) * speed);
		//GetComponent<Rigidbody> ().useGravity = false;
		//GetComponent<CapsuleCollider> ().enabled = false;
		
		//		print ("fWalkPlayer");
		print ("fWalkPlayer2" + transform.position.z);
		fNextMove ();
		
	}
	//********************************************* 0620 yamaguchi start
	//RightTurn Player
	//*******************************************************************
	
	IEnumerator fTurnRightPlayer()
	{
		transform.Rotate (0, 90, 0);
		
		floorFlg = BLOCK;
		print ("fTurnRightPlayer , " + floorFlg);
		yield return new WaitForSeconds (0.1F);
		
		
		fNextMove ();
	}
	
	//********************************************* 0620 yamaguchi start
	//LeftTurn Player
	//*******************************************************************
	
	IEnumerator fTurnLeftPlayer()
	{
		
		transform.Rotate (0, -90, 0);
		
		floorFlg= BLOCK;
		
		yield return new WaitForSeconds (0.1F);
		
		fNextMove ();
	}
	
	//********************************************* 0620 yamaguchi start
	//Down Player
	//*******************************************************************
	
	IEnumerator fDownPlayer()
	{
		anim.SetTrigger ("isJumpTrigger");
		
		//		transform.Translate (0, -1, 1);
		//		print ((int)((1 / speed) * (2.0f/3)));
		float dist = 1F;
		
		float speed3 = 0.04f;

				print ("横ジャンプ" + speed3 + " , " + (int)(1.0f / speed3));
		
		//for (int i = 0; i < (int)(dist / speed); i++)
		for (int i = 0; i < 20; i++)
		{
			
			transform.Translate (0, 0, speed3);
			yield return new WaitForSeconds (0.01F);
		}
		//		transform.Translate (0, 0, 1.0f - 25.0f*(int)(dist / speed3));
		
		//yield return new WaitForSeconds (5F);
		
		print ((int)(dist / speed));
		print (1.0f - (int)(dist / speed)*speed);
		
		
		float speed2 = 0.05F;
		
		
		print ("落下" + speed2 + " , " + (int)(1.0f / speed2));
		for (int i = 0; i < (int)(1.0f / speed2); i++) {
			
			transform.Translate (0, - speed2, speed3/5.0f);
			yield return new WaitForSeconds (0.01F);
		}

		/*		
		print ("横ジャンプ" + speed3 + " , " + (int)(1.0f / speed3));
		
		//for (int i = 0; i < (int)(dist / speed); i++)
		for (int i = 0; i < (int)(1.0f / speed3); i++)
		{
			
			transform.Translate (0, 0, speed3);
			yield return new WaitForSeconds (0.01F);
		}
		//		transform.Translate (0, 0, 1.0f - 25.0f*(int)(dist / speed3));
		
		//yield return new WaitForSeconds (5F);
		
		print ((int)(dist / speed));
		print (1.0f - (int)(dist / speed)*speed);
		
		
		float speed2 = 0.06F;
		
		
		print ("落下" + speed2 + " , " + (int)(1.0f / speed2));
		for (int i = 0; i < (int)(1.0f / speed2); i++) {
			
			transform.Translate (0, - speed2, 0);
			yield return new WaitForSeconds (0.01F);
		}
		
*/		
		yield return new WaitForSeconds (0.5F);
		
		anim.SetTrigger ("isMoveTrigger");
		
		print (transform.position.z);
		fNextMove ();
	}
	
	//********************************************* 0620 yamaguchi start
	//Climb Player
	//*******************************************************************
	
	IEnumerator fClimbPlayer()
	{
		print (transform.position.x + " , " + transform.position.y + " , " + transform.position.z);
		
		
		
		anim.SetTrigger ("isMoveTrigger");
		
		//int count = 10;
		float dist = 0.2F;
		
		float sumDist = 0;
		print ("speed = " + speed + " , dist = " + dist);
		for (int i = 0; i < (int)(dist / speed); i++)
		{
			
			transform.Translate (0, 0, speed);
			sumDist += speed;
			yield return new WaitForSeconds (0.01F);
		}
		transform.Translate (0, 0,  ( (dist / speed) - (int)( dist / speed)) * speed );
		print ("speed = " + speed + " , dist = " + dist + " , sumDist = " + sumDist);
		sumDist += ((dist / speed) - (int)(dist / speed)) * speed;
		print (((dist / speed) - (int)(dist / speed)) * speed);
		
		anim.SetTrigger ("isClimbTrigger");
		yield return new WaitForSeconds (0.5F);
		
		float speed2 = 0.1F;
		
		
		
		for (int i = 0; i < (int)1 / speed2; i++) {
			
			transform.Translate (0, speed2, 0);
			yield return new WaitForSeconds (0.01F);
		}
		
		anim.SetTrigger ("isMoveTrigger");
		
		
		//		print ("count - dist " + (1 - (count * dist)));
		for (int i = 0; i < (int)((1- dist) / speed); i++) {
			
			
			transform.Translate (0, 0, speed);
			sumDist += speed;
			yield return new WaitForSeconds (0.01F);
			
		}
		
		
		transform.Translate (0, 0, ((1 - dist) - ((int)((1 - dist) / speed)) * speed));
		
		print ("***speed = " + speed + " , dist = " + dist + " , sumDist = " + sumDist);
		sumDist += ((1 - dist) - ((int)((1 - dist) / speed)) * speed) * speed;
		print (((1 - dist) - ((int)((1 - dist) / speed)) * speed) * speed);
		print (((1 - dist) - ((int)((1 - dist) / speed)) * speed));
		print ((1 - dist) + " , - " +  ((int)((1 - dist) / speed)) * speed);
		
		//		transform.Translate (0, 0, Mathf.RoundToInt (transform.position.z) - transform.position.z);
		print(Mathf.RoundToInt(transform.position.z));
		
		fNextMove ();
	}
	
	//********************************************* 0620 yamaguchi start
	//Trouble Player
	//*******************************************************************
	
	void fTroublePlayer()
	{
		
		anim.SetBool ("isTrouble", true);
	}
	
	//********************************************* 0620 yamaguchi start
	//Goal Player
	//*******************************************************************
	IEnumerator fGoalPlayer()
	{
		
		//anim.SetBool ("isMove", false);
		anim.SetTrigger ("isWinTrigger");
		yield return new WaitForSeconds (0.01F);
		
	}
	
	//******************************************************************************
	//
	//******************************************************************************
	IEnumerator fSpling1Player(){
		
		yield return new WaitForSeconds(0.01f);
		
		
		anim.SetTrigger ("isJumpTrigger");
		
		int count = (int)(1.0f / 0.02f)-2;
		for (int i = 0; i < count; i++) {
			yield return new WaitForSeconds(0.01f);
			transform.Translate(0,0,2.0f/count);
		}
		
		yield return new WaitForSeconds(0.01f);
		
		//		floorFlg = BLOCK;
		//		anim.SetTrigger ("isMoveTrigger");
		
		fNextMove ();
	}
	
	IEnumerator fFallPlayer(){
		float t = 0f;
		float dt = 0.15f;
		while (t<1.0f) {
			transform.Translate(0,-dt,0);
			t+=dt;
			yield return new WaitForSeconds (0.01f);
		}
		
		floorFlg = BLOCK;
		
		yield return new WaitForSeconds (1.5f);
		anim.SetTrigger ("isMoveTrigger");
		fNextMove ();
	}
	
}
