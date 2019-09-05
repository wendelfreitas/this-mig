using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
	private _GC GameController;
	public GameObject prefab;
	private bool instanciar;
	// Use this for initialization
	void Start () {
		GameController = FindObjectOfType (typeof(_GC)) as _GC;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, GameController.fim2, GameController.velocidadeAgua * Time.deltaTime);
		if (transform.position == GameController.fim2) {
			Destroy (this.gameObject);
		}
		if(transform.position.x >= 0 && instanciar == false){
			Instantiate (prefab, GameController.inicio2, transform.rotation);
			instanciar = true;
		}
	}
}
