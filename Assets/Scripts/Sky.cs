using UnityEngine;
using System.Collections;

public class Sky : MonoBehaviour {
	private _GC GameController;
	public GameObject prefab;
	private bool instanciar;
	// Use this for initialization
	void Start () {
		GameController = FindObjectOfType (typeof(_GC)) as _GC;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, GameController.fim, GameController.velocidadeBackground * Time.deltaTime);
		if (transform.position == GameController.fim) {
			Destroy (this.gameObject);
		}
		if (GameController.currentState == _GC.GameState.jogando || GameController.currentState == _GC.GameState.inicio || GameController.currentState == _GC.GameState.gameOver) {
			if (transform.position.x >= -2 && instanciar == false) {
				Instantiate (prefab, GameController.inicio, transform.rotation);
				instanciar = true;
			}
		}

		if (GameController.currentState == _GC.GameState.secreta) {
			if (transform.position.x >= 0.08f && instanciar == false) {
				Instantiate (prefab, GameController.inicio, transform.rotation);
				instanciar = true;
			}
		}

		if (GameController.currentState == _GC.GameState.jogando2) {
			if (transform.position.x >= 0.08f && instanciar == false) {
				Instantiate (prefab, GameController.inicio, transform.rotation);
				instanciar = true;
			}
		}

	}
}
