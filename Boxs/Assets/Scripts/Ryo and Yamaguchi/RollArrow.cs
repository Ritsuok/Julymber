using UnityEngine;
using System.Collections;

public class RollArrow : MonoBehaviour {
	float rollSpeed = 5;
	public GameObject turnCanvas;
	GameObject clone;

	// Use this for initialization
	void Start ()
	{
		if (gameObject.tag == "TurnL")
		{

			clone = Instantiate (turnCanvas, transform.position, Quaternion.Euler (90, 0, 0)) as GameObject;

			clone.transform.SetParent(transform);

			StartCoroutine ("fRollLObject");
		
		}

		if (gameObject.tag == "TurnR")
		{
			
			clone = Instantiate (turnCanvas, transform.position, Quaternion.Euler (90, 0, 0)) as GameObject;
			clone.transform.localScale = new Vector3(-1 * clone.transform.localScale.x,
			                                         clone.transform.localScale.y,
			                                         clone.transform.localScale.z);
			
			clone.transform.SetParent(transform);
	
			
			StartCoroutine ("fRollRObject");
			
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator fRollLObject()
	{
		while (true)
		{
			clone.transform.Rotate (0, 0, rollSpeed);
			yield return new WaitForSeconds (0.01F);
		}
	}

	IEnumerator fRollRObject()
	{
		while (true)
		{
//			print ("aaaa");
//			print (rollSpeed);
			clone.transform.Rotate (0, 0, -rollSpeed);
			yield return new WaitForSeconds (0.01F);
		}
	}
}
