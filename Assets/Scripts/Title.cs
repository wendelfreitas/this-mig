using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	private bool ativo;
	private SpriteRenderer subtitleSR;

	// Use this for initialization
	void Start () {
		subtitleSR = GetComponent<SpriteRenderer> ();
		StartCoroutine ("title");

	}
	

	IEnumerator title()
	{
		ativo = !ativo;
		subtitleSR.enabled = ativo;
		yield return new WaitForSeconds (0.6f);
		StartCoroutine ("title");
	}
}
