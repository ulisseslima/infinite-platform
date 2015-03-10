using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{
	public static float _pipeDistance;
	public float speed;
	public int pipePoolSize;
	public float pipeDistance;

	// Use this for initialization
	void Start ()
	{
		_pipeDistance = pipeDistance;

		for (int i = 1; i <= pipePoolSize; i++) {
			GameObject pipeWall = Instantiate (Resources.Load ("Pipes")) as GameObject;
			incrementX (pipeWall, pipeDistance * i);
			Debug.LogFormat ("pipe: {0} #{1} - curr x: {2}", 
			                 pipeWall.transform.position.x, 
			                 pipeWall.GetInstanceID (),
			                 PipeBehaviour.currentX);

			GameObject bg = Instantiate (Resources.Load ("BG")) as GameObject;
			incrementXByWidth (bg, i);
			//Debug.Log("bg: "+bg.transform.position.x);
		}
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		incrementX (speed);
	}

	void Update ()
	{

	}

	void incrementX (float n)
	{
		Vector3 pos = transform.position;
		pos.x += n;
		transform.position = pos;
	}

	void incrementX (GameObject go, float n)
	{
		Vector3 pos = go.transform.position;
		pos.x += n;
		go.transform.position = pos;
		PipeBehaviour.currentX = pos.x;
	}

	void incrementXByWidth (GameObject go, int multiplier)
	{
		Vector3 pos = go.transform.position;
		pos.x += (go.GetComponent<BoxCollider2D> ().size.x * multiplier);
		go.transform.position = pos;
		BgBehaviour.currentX = pos.x;
	}
}
