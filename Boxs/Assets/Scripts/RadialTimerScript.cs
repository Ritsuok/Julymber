﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RadialTimerScript : MonoBehaviour {

	public Image CircleGauge; //ゲージの画像
	public float stageTimeLimit; //制限時間

	//private int SLOWMOTIONTIME = 1;//ゲームオーバーの際のスローモーション時間

	//山口さんのカウントダウンが終了するまでゲージを動かさないためのboolian
	public static bool gameStart = true;

		void Start ()
		{
			//ゲージの最大値を制限時間と同期させる
			CircleGauge.fillAmount = stageTimeLimit;
		}

		void Update ()
		{
		//制限時間と同期したタイミングでゲージを減少させる
		if (CircleGauge.fillAmount > 0 && gameStart == true) {
			CircleGauge.fillAmount -= 1/stageTimeLimit * Time.deltaTime;
		}

		else if(CircleGauge.fillAmount == 0) {
			//タイムが０になったらゲームオーバー画面に遷移
			Debug.Log ("GameOver");
/*			for (int i = 1; i <= 100; i++) {
				Time.timeScale = 1 / i;
				System.Threading.Thread.Sleep(100);
			}
			Time.timeScale = 1;
*/
			Application.LoadLevel("GameOver");
		}
	}
}