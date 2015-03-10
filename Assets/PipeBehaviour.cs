using UnityEngine;
using System.Collections;

public class PipeBehaviour : MonoBehaviour
{
	public static float currentX;
	public float verticalVariation;
	public int rearrangeDelay;
	bool seen = false;
	GameObject go;

	// Use this for initialization
	void Start ()
	{
		setRandomY (verticalVariation);
		go = transform.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnBecameInvisible ()
	{
		//Debug.LogFormat ("pipe OnBecameInvisible ({0}) at {1}", getId (), Time.time);
		if (seen) {
			Invoke("rearrange", rearrangeDelay);
		}
	}

	void rearrange ()
	{
		float x = currentX + CameraBehaviour._pipeDistance;
		setX (x);
		seen = false;
	}

	void OnBecameVisible ()
	{
		seen = true;
	}

	void setX (float x)
	{
		Debug.LogFormat ("pipe new x: {0} #{1} - curr x: {2}", x, getId (), currentX);
		Vector3 pos = transform.position;
		pos.x = x;
		transform.position = pos;
		currentX = pos.x;
	}

	void setRandomY (float variant)
	{
		Vector3 pos = transform.position;
		pos.y = Random.Range (-variant, variant);
		transform.position = pos;
	}

	int getId ()
	{
		if (go == null)
			Debug.Log ("go is null");
		return go.GetInstanceID ();
	}
}
