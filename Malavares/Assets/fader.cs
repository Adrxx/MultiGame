using UnityEngine;
using System.Collections;

public class fader : MonoBehaviour {


	private bool showing = false;


	public Color startColor = Color.black;
	public Color endColor = Color.clear;

	public bool isInStartColor = true;


	private float fading = 0.0f;
	public float speed = 1.0f;

	private bool startFade = false;
	

	// Use this for initialization
	void Start () {
		startFading ();
	}
	
	// Update is called once per frame
	void Update () {

		this.fading += Time.deltaTime * this.speed;
		SpriteRenderer sp = this.GetComponent<SpriteRenderer> ();

		if (this.startFade) {

			sp.color = Color.Lerp (startColor, endColor, this.fading);
			this.isInStartColor = this.fading > 1.0f;

		} else {

			sp.color = Color.Lerp (endColor, startColor, this.fading);

			this.isInStartColor = !(this.fading > 1.0f);

		}

	}


	public void startFading()
	{
		this.startFade = true;
		this.fading = 0.0f;


	}

	public void startUnFade()
	{
		this.startFade = false;
		this.fading = 0.0f;


	}
}
