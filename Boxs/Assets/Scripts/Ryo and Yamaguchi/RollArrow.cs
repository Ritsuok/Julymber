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

//********************************************* 0629 igarashi start
		if (gameObject.tag == "Bomb") 
		{
			StartCoroutine ("fBombObject");
		}
//********************************************* 0629 igarashi end

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

//********************************************* 0629 igarashi start
	IEnumerator fBombObject()
	{
		Collider collider;

		while (true)
		{

			if ((transform.localPosition.y % 1) >= 0.999F)
			{

				Collider[] c = Physics.OverlapSphere (new Vector3 (transform.localPosition.x,
				                                                   transform.localPosition.y - 1,
				                                                   transform.localPosition.z), 0.1F);
				if (c [0] != null)
				{
					collider = c [0];
					break;
				}
			}
			yield return new WaitForSeconds (0.01F);
		}

		//sound
		Sounds.SEbomb ();

		Destroy (collider.gameObject);
		Destroy (gameObject);
	}
//********************************************* 0629 igarashi end
}
