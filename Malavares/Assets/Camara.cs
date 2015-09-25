using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour {


	private float speed = 0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		speed += 0.0005f;

		float accel = 0.0f;
			//transform.Translate (Input.GetAxis ("Horizontal") * speed,0, 0);
		accel = Input.acceleration.x * 2.5f;
		if (accel < 0) accel = 0.0f;
				
			

		this.transform.position = new Vector3(this.transform.position.x + speed * (accel + 0.5f),this.transform.position.y,-10);



	}
}