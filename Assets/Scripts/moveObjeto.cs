using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class moveObjeto : MonoBehaviour {
	private _GC GameController;
	private Vector3 destino;
	private Player player;
	private static int contador;
	private bool pontuado,ativo;
	// Use this for initialization
	void Start () {
		GameController = FindObjectOfType (typeof(_GC)) as _GC;
		destino = new Vector3 (transform.position.x, GameController.fimObjetos.y, transform.position.z);
		player = FindObjectOfType(typeof(Player)) as Player;

	}

	// Update is called once per frame
	void Update () {
		if (contador == 2) {
			contador = 0;
			AdManager.Instance.ShowVideo ();

		}
		transform.position = Vector3.MoveTowards (transform.position, destino, GameController.velocidadeTiro * Time.deltaTime);
		if (GameController.currentState == _GC.GameState.jogando || GameController.currentState == _GC.GameState.secreta || GameController.currentState == _GC.GameState.jogando2) {
			if (transform.position.y == GameController.fimObjetos.y) {
				
				Destroy (this.gameObject);
			}
				if (pontuado == false && (transform.position.y < player.transform.position.y) && player.dead == false && GameController.score <= 99999) {
					pontuado = true;
					GameController.score += 1;
				if(GameController.score > 1000 && GameController.currentState == _GC.GameState.secreta){
						GameController.score = 1000;
						}
					}
				else {
					GameController.score += 0;
				}

			}
		}


	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.tag == "Player") {
			PlayerPrefs.SetInt ("score", GameController.score);

			if (GameController.score > PlayerPrefs.GetInt ("recorde")) {
				PlayerPrefs.SetInt ("recorde", GameController.score);
			}
			if (GameController.score < 99999 && GameController.currentState == _GC.GameState.jogando || GameController.score < 99999 && GameController.currentState == _GC.GameState.jogando2) {
				player.Dead ();
	
				if (player.Dead ()) {
					contador++;

				}
	
				StartCoroutine ("Carregar");
			
			}
		}
	}

	IEnumerator Carregar()
	{	
		GameController.currentState = _GC.GameState.gameOver;
		yield return new WaitForSeconds (3);

		SceneManager.LoadScene ("gameOver");
		AdManager.Instance.ShowBanner ();

		
	}

		

}
