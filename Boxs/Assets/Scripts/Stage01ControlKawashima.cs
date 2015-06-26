using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stage01ControlKawashima : MonoBehaviour {


	public int cubeLeft;
	public int cubeStraight;
	public int cubeRight;

	private GameObject main;
	private MainKawashima mainkawashima;

	private Text straightTxt;
	private Text leftTxt;
	private Text rightTxt;

	private GameObject straightObj;
	private GameObject leftObj;
	private GameObject rightObj;

	private GameObject straightBtn;
	private GameObject leftBtn;
	private GameObject rightBtn;
	
	private DropCubBtnKawashima dropcubeS;
	private DropCubBtnKawashima dropcubeL;
	private DropCubBtnKawashima dropcubeR;
	// Use this for initialization
	void Start () {
		main =  GameObject.Find ("Main");
		mainkawashima = main.GetComponent<MainKawashima> ();


		straightObj = GameObject.Find ("NumberStraightText");
		straightTxt = straightObj.GetComponent<Text>();
		straightTxt.text = cubeStraight.ToString();
		straightBtn = GameObject.Find ("ButtonDropStraight");
		dropcubeS = straightBtn.GetComponent<DropCubBtnKawashima> ();

		leftObj = GameObject.Find ("NumberLeftText");
		leftTxt = leftObj.GetComponent<Text>();
		leftTxt.text = cubeLeft.ToString();
		leftBtn = GameObject.Find ("ButtonDropLeft");
		dropcubeL = leftBtn.GetComponent<DropCubBtnKawashima> ();


		rightObj = GameObject.Find ("NumberRightText");
		rightTxt = rightObj.GetComponent<Text>();
		rightTxt.text = cubeRight.ToString();
		rightBtn = GameObject.Find ("ButtonDropRight");
		dropcubeR = rightBtn.GetComponent<DropCubBtnKawashima> ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void fStraightUsed(){
		if (mainkawashima.isSelected == false){
			return;
		}

		cubeStraight --;
		straightTxt.text = cubeStraight.ToString ();

		if (cubeStraight <= 0) {
			dropcubeS.isStraightNoMore = true;
			return;
		}
	}
	public void fLeftUsed(){
		if (mainkawashima.isSelected == false){
			return;
		}

		cubeLeft --;
		leftTxt.text = cubeLeft.ToString ();

		if (cubeLeft <= 0) {
			dropcubeL.isLeftNoMore = true;
			return;
		}
	}
	public void fRightUsed(){
		if (mainkawashima.isSelected == false){
			return;
		}

		cubeRight --;
		rightTxt.text = cubeRight.ToString ();

		if (cubeRight <= 0) {
			dropcubeR.isRightNoMore = true;
			return;
		}
	}
}
