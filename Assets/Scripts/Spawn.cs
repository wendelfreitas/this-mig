using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	private _GC GameController;
	public GameObject[] objBullet;
	// Use this for initialization
	void Start () {
		GameController = FindObjectOfType (typeof(_GC)) as _GC;
		if (GameController.currentState == _GC.GameState.jogando || GameController.currentState == _GC.GameState.jogando2) {
			StartCoroutine ("SpawnTiros");
		}

	}
	

	IEnumerator SpawnTiros()
	{
		int i = Random.Range (0, objBullet.Length);
		yield return new WaitForSeconds (GameController.intervaloTiro);

		GameObject temp = Instantiate (objBullet[i]);	
		float distancez = (transform.position - Camera.main.transform.position).z;
		float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,distancez)).x;
		float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,0,distancez)).x;
		//Limitando área de posicionamento de bolinhas com base na câmera.
		temp.transform.position = new Vector3 (Random.Range (leftBorder+0.2f, rightBorder-0.2f), transform.position.y, transform.position.z);
		if (GameController.currentState == _GC.GameState.jogando || GameController.currentState == _GC.GameState.jogando2) {
			StartCoroutine ("SpawnTiros");
		}
	}

}
