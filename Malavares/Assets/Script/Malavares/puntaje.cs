using UnityEngine;
using System.Collections;

public class puntaje : MonoBehaviour {


	public static int globalScore = 0;
    public Camera cam; //llama a la camara
    public float poscam; //obtiene la posición de la camara
    public int score; //declara el valor del puntaje
    public GUIText txt; //declara el texto

    void Start () {
        txt = this.GetComponent<GUIText>();
        cam = FindObjectOfType<Camera>(); //inicializa la camara        
        score = 0; //incializa el puntaje
	}


	public void addScore()
	{
		score++;
		puntaje.globalScore += 1;

	}

    void Update() {
        txt.text = "" + score; //sube el score dependiendo de la posición de la camara
    }
}
