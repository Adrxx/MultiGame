using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {


	private float acumulador = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.acumulador += Time.deltaTime;
		if (this.acumulador > 5.0f) {
			DestroyObject(this.gameObject);
			
		}
	}

}