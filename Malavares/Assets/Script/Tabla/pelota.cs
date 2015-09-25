using UnityEngine;
using System.Collections;
using System;

public class pelota : MonoBehaviour {
    public GameObject vidas; //llama al contador de vidas
    public GameObject effects;
    private SpriteRenderer rnd; //llama al sprite renderer
    public vidas lives; //declara las vidas del contador 
    public Sprite[] sprites; //declara el arreglo de los sprites posibles
    public fx fx;
    private bool perder; //declara si se pierde una vida o no cuando la pelota cae de la pantalla 
    private int i; //indice para el arreglo de sprites

	private bool toNext = false;


    Sprite escogerSprite() { //devuelve un sprite seleccionado del arreglo de manera aleatoria
        i = (int)Math.Round((double)UnityEngine.Random.Range(0, 22));
        return sprites[i];
    }

	void goToGameOver()
	{
		
		fader f = GameObject.Find("Fader").GetComponent<fader>();
		
		f.endColor = Color.red;
		
		f.startUnFade();
		
		this.toNext = true;
		
	}

    void Start() {
        effects = GameObject.FindWithTag("Audio");
        fx = effects.GetComponent<fx>();
        rnd = this.GetComponent<SpriteRenderer>(); //incializa el sprite renderer
        rnd.sprite = escogerSprite(); //asigna el sprite al renderer
        vidas = GameObject.FindWithTag("vidas"); //inicializa el contador de vidas
        lives = vidas.GetComponent<vidas>(); //obtiene la variable de vidas del contador de vidas
        perder = true; //permite perder una vida tras pasar la distancia de la camara hacia abajo

    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Pelotita" || other.gameObject.tag=="bund" || other.gameObject.tag=="tabla") {
            fx.a[1].Play();
        }
    }
	
	void Update () {

		if (this.toNext) {

			fader f = GameObject.Find ("Fader").GetComponent<fader> ();

			
			Debug.Log (f.isInStartColor);
			if (!f.isInStartColor)
				Application.LoadLevel ("parkour");

		} else {
		

			if (this.transform.position.y < -6) { //checa si se cayó de la camara
				
				goToGameOver ();
				
				fx.a [2].Play ();
			}

		}
	}
}
