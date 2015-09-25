using UnityEngine;
using System.Collections;

public class MagnetScript : MonoBehaviour {



	private Rigidbody2D magnetRB;
	private bool right;
	//private Vector2 attractionVector;

	private float speed = 85.0f;

	private float chargeSpeed = 0.850f;
	private float dischargeSpeed = 1.0f;

	private float hardness = 160.0f;

	
	private float blueProgress = 0.0f;
	private float redProgress = 0.0f;

	public Sprite[] sprites;

	private bool toNext = false;


	// Use this for initialization
	void Start () {

		puntaje.globalScore = 0;


		GameObject magnet = GameObject.FindGameObjectWithTag("Player");

		this.magnetRB = magnet.GetComponent<Rigidbody2D>();

		magnetRB.velocity = Vector2.right * speed;
		this.right = true;

		SpriteRenderer sp = this.GetComponent<SpriteRenderer>();

		sp.sprite = chooseSprite();

	}


	void playAudio(int i)
	{
		AudioSource[] aus = GameObject.Find("Sounds").GetComponents<AudioSource> ();

		aus [i].Play ();
	}


	void goToGameOver()
	{

		fader f = GameObject.Find("Fader").GetComponent<fader>();

		f.endColor = Color.red;
		
		f.startUnFade();
		
		this.toNext = true;

	}

	Sprite chooseSprite() { 
		return this.sprites[UnityEngine.Random.Range(0,this.sprites.Length)];
	}


	void OnCollisionEnter2D(Collision2D coll) {


		if (coll.gameObject.tag == "Spike") {
			//Debug.Log (coll.gameObject);
			goToGameOver ();
			DestroyObject(coll.gameObject);
			//this.GetComponent<BoxCollider2D>().isTrigger = true;
			this.transform.position = new Vector3(-100,1000,this.transform.position.z);


		} else {
			
			GameObject puntaje = GameObject.Find("Puntaje");
			
			puntaje p = puntaje.GetComponent<puntaje>();
			
			p.addScore();

			playAudio(3);
		}
	}

	// Update is called once per frame
	void Update () {

		fader f = GameObject.Find("Fader").GetComponent<fader>();

		if (this.toNext) {
			
			Debug.Log (f.isInStartColor);
			if (!f.isInStartColor)
				Application.LoadLevel ("Malavares");

		} else {
		


			if (Input.GetMouseButtonDown (0)) {
				if (this.right) {
					magnetRB.velocity = new Vector2 ((-1 * speed), magnetRB.velocity.y);
					this.right = false;
				} else {
					magnetRB.velocity = new Vector2 ((1 * speed), magnetRB.velocity.y);
					this.right = true;
				}


			}


			hardness += 0.05f;

			if (hardness >= 165.0f) {

				if (this.transform.position.x > 0) {
					//Azul

					blueProgress += Time.deltaTime * chargeSpeed;
					redProgress -= Time.deltaTime * dischargeSpeed;

				
				} else {
					redProgress += Time.deltaTime * chargeSpeed;
					blueProgress -= Time.deltaTime * dischargeSpeed;

				
				}



				redProgress = Mathf.Clamp (redProgress, 0.0f, 2.0f);

				blueProgress = Mathf.Clamp (blueProgress, 0.0f, 2.0f);

			}


			GameObject azul = GameObject.Find ("BlueCharge");
		
			azul.transform.localScale = new Vector3 (azul.transform.localScale.x, hardness * blueProgress, azul.transform.localScale.z);

			GameObject rojo = GameObject.Find ("RedCharge");
		
			rojo.transform.localScale = new Vector3 (rojo.transform.localScale.x, hardness * redProgress, rojo.transform.localScale.z);



			if (azul.transform.localScale.y >= 200.0f || rojo.transform.localScale.y >= 200.0f) {
				goToGameOver ();
			}

		}
		
	}
}
