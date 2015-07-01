using UnityEngine;
using System.Collections;

public class testMoveCameraYamaguchi : MonoBehaviour {

	public int rtt;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	

		transform.Rotate (0, rtt, 0);
	}
}
