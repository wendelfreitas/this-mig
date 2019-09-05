using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	private _GC GameController;

	// Use this for initialization
	void Start () {
		GameController = FindObjectOfType (typeof(_GC)) as _GC;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, GameController.fimTelaScore, GameController.velocidadeTelaScore * Time.deltaTime);
	}
}
