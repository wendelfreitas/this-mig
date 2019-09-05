using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FalaTitulo : MonoBehaviour {
	public Text txt;
	public string[] texto;
	// Use this for initialization
	void Start () {
		int x = Random.Range (0, 3);
		StartCoroutine ("escrever", texto[x]);
	}


	IEnumerator escrever(string frase)
	{
		int i = 0;
		txt.text = "";
		while (i < frase.Length) {
			txt.text += frase [i];
			i++;
			yield return new WaitForSeconds (0.2f);
		}
	}
}
