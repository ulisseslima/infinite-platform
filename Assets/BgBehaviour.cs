using UnityEngine;
using System.Collections;

public class BgBehaviour : MonoBehaviour
{
	public static float currentX;
	public int rearrangeDelay;
	bool seen = false;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnBecameInvisible ()
	{
		//Debug.LogFormat ("bg OnBecameInvisible ({0})",transform.GetInstanceID());
		if (seen) {
			Invoke ("rearrange", rearrangeDelay);
		}
	}

	void rearrange ()
	{
		float x = currentX + GetComponent<BoxCollider2D> ().size.x;
		setX (x);
		seen = false;
	}

	void OnBecameVisible ()
	{
		seen = true;
	}

	void setX (float x)
	{
		//Debug.LogFormat ("bg new x: {0} ({1})",x,transform.GetInstanceID());
		Vector3 pos = transform.position;
		pos.x = x;
		transform.position = pos;
		currentX = pos.x;
	}
}
