using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class _GC : MonoBehaviour {

	public enum GameState
	{
		inicio,
		jogando,
		jogando2,
		secreta,
		pause,
		gameOver
	}
	public GameState currentState;
	public Vector3 inicio,fim,inicio2,fim2,fimObjetos,fimTelaScore;
	public Text scoreText,recordeText;

	private Player player;
	public float velocidadeBackground,velocidadeAgua,intervaloTiro,velocidadeTiro,velocidadeTelaScore;
	public int score;

	void Start () {
		inicio = GameObject.Find ("inicioBackground").transform.position;
		fim = GameObject.Find ("fimBackground").transform.position;
		inicio2 = GameObject.Find ("inicioAgua").transform.position;
		fim2 = GameObject.Find ("fimAgua").transform.position;
		player = FindObjectOfType (typeof(Player)) as Player;
		//PlayerPrefs.SetInt ("recorde", 0);
		//PlayerPrefs.SetInt ("zerou", 0);

		if (currentState == GameState.jogando || currentState == GameState.secreta || currentState == GameState.gameOver || currentState == GameState.jogando2) {
			fimObjetos = GameObject.Find ("fimObjetos").transform.position;

		}

		if (currentState == GameState.gameOver) {
			fimTelaScore = GameObject.Find ("fimTelaScore").transform.position;

			scoreText.text = PlayerPrefs.GetInt ("score").ToString ();

			recordeText.text = PlayerPrefs.GetInt ("recorde").ToString ();

		}

	}
	

	void Update () {
		if (currentState == GameState.jogando || currentState == GameState.jogando2) {
			scoreText.text = score.ToString ();
			if (score >= 25 && currentState == GameState.jogando || score >= 25 && currentState == GameState.jogando2) {
				intervaloTiro = 0.4f;
			} 
			if (score >= 50 && currentState == GameState.jogando || score >= 59 && currentState == GameState.jogando2) {
				intervaloTiro = 0.3f;
				velocidadeTiro = 4f;
			} 
			if(score >= 100 && currentState == GameState.jogando || score >= 150 && currentState == GameState.jogando2) {
				intervaloTiro = 0.2f;
				velocidadeTiro = 4f;
			}  
			if(score >= 500 && currentState == GameState.jogando || score >= 500 && currentState == GameState.jogando2) {
				intervaloTiro = 0.1f; //01
				velocidadeTiro = 5f; //5
				player.velocidadeBase = 4; //4
			}  
			if (score >= 1000 && currentState == GameState.jogando && PlayerPrefs.GetInt("zerou") == 0) {
				PlayerPrefs.SetInt ("recorde", 1000);
				PlayerPrefs.SetInt("score", 1000);
				StartCoroutine ("Carregar");
			}

		}

	}
	//game id unity 1100818

	public void Jogar()
	{
		
		if (PlayerPrefs.GetInt ("zerou") == 1) {
			SceneManager.LoadScene ("jogar2");
			currentState = GameState.jogando2;
		}
		if (PlayerPrefs.GetInt ("zerou") == 0) {
			SceneManager.LoadScene ("jogar1");
		}
	}

	IEnumerator Carregar(){
		currentState = GameState.secreta;
		player.velocidadeBase = 0;
		yield return new WaitForSeconds (3);

		SceneManager.LoadScene ("secreta");
		PlayerPrefs.SetInt ("zerou", 1);

	}



}
