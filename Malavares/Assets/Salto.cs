using UnityEngine;
using System.Collections;

public class Salto : MonoBehaviour {
	public float Fuerzasalto = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Fuerzasalto));

	
	}
}
