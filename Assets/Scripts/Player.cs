using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

	public _GC GameController;
	private VirtualJoystick joystick;
	private Rigidbody2D 	playerRb;
	private Animator 		playerAnimator;
	public 	float 			velocidade, velocidadeBase;
	public 	bool			olhandoEsquerda,walk,dead;
	private AudioSource		audio;

	// Use this for initialization
	void Start () {
		velocidadeBase = velocidade;
		audio = GetComponent<AudioSource> ();
		GameController = FindObjectOfType (typeof(_GC)) as _GC;
		playerRb = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();
		joystick = FindObjectOfType (typeof(VirtualJoystick)) as VirtualJoystick;

		
	}
	
	// Update is called once per frame
	void Update () {

		#if UNITY_EDITOR
		//float horizontal = Input.GetAxisRaw ("Horizontal");

		#endif
	
		//Verificando posicionamento do toque na tela

		float horizontal = joystick.Horizontal ();
		if (horizontal < 0) {
			horizontal = -1;
		} else if (horizontal > 0) {
			horizontal = 1;
		}

		//Movimentação e flip personagem
		if (horizontal != 0 && GameController.currentState != _GC.GameState.secreta) { walk = true; } else { walk = false;}
	
		if (horizontal < 0 && olhandoEsquerda == false && dead == false && GameController.currentState != _GC.GameState.secreta) {
			virarPersonagem ();
		} else if (horizontal > 0 && olhandoEsquerda == true && dead == false && GameController.currentState != _GC.GameState.secreta) {
			virarPersonagem ();
		}


		//Limitar espaço do personagem dentro da câmera.
		float distancez = (transform.position - Camera.main.transform.position).z;
		float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,distancez)).x;
		float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1,0,distancez)).x;
		transform.position = new Vector3(Mathf.Clamp(transform.position.x,(leftBorder + 0.2f),(rightBorder - 0.2f)),transform.position.y,transform.position.z);

		//Velocidade Personagem
		if (GameController.currentState == _GC.GameState.jogando || GameController.currentState == _GC.GameState.jogando2 ) {
			playerRb.velocity = new Vector2 (velocidadeBase * horizontal, playerRb.velocity.y);
		}
		//Animação
		playerAnimator.SetBool ("walk", walk);
	}

	public void virarPersonagem()
	{
		olhandoEsquerda = !olhandoEsquerda;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
		
	public bool Dead()
	{
		audio.Play ();
		dead = true;
		playerAnimator.SetBool ("dead", dead);
		this.velocidadeBase = 0;

		return dead;

	}
}
