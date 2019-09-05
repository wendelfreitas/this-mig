using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
	private SpriteRenderer tutorial;
	// Use this for initialization
	void Start () {
		tutorial = GetComponent<SpriteRenderer> ();
		StartCoroutine ("desligarTutorial");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator desligarTutorial()
	{
		yield return new WaitForSeconds (5.0f);
		tutorial.enabled = false;
	}
}
