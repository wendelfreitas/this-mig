using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class Fala : MonoBehaviour {
	public Text txt;
	public string texto;

	// Use this for initialization
	void Start () {
		StartCoroutine ("escrever", texto);

	}
	


	IEnumerator escrever(string frase)
	{
		int i = 0;
		txt.text = "";
		while(i < frase.Length){
			txt.text += frase [i];
			i++;
			yield return new WaitForSeconds (0.2f);
		}
		yield return new WaitForSeconds (7.0f);
		SceneManager.LoadScene ("gameOver");
	}
		
}
