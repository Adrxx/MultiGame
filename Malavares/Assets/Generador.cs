using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {
	public GameObject[]obj;
	private float tiempoMin=0.38f;
	private float tiempoMax=1.1f;

	private float lim = 0;
	private float acumulador = 0.0f;


	// Use this for initialization
	void Start () {
		lim = Random.Range (tiempoMin, tiempoMax);
	}
	
	// Update is called once per frame
	void Update () {
	
	
		this.acumulador += Time.deltaTime;

		if (this.acumulador > lim) {
			Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);
			this.acumulador = 0;
			lim = Random.Range (tiempoMin, tiempoMax);

		}

	}
}
