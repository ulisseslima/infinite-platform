using UnityEngine;
using System.Collections;

public class SpawnBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static IEnumerator sleep(int seconds) {
		Debug.Log("sleep");
		yield return new WaitForSeconds(seconds);
		Debug.Log("sleep done");
	}
}
