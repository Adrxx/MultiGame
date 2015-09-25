using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rb = this.GetComponent<Rigidbody2D> ();

		rb.velocity = Vector2.up * 13.0f;

		if (this.gameObject.transform.position.y > 10.0f) {
			DestroyObject(this.gameObject);
			//Destroy(this);
		}
	}


}
