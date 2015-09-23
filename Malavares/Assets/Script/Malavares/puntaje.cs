using UnityEngine;
using System.Collections;

public class puntaje : MonoBehaviour {
    public Camera cam; //llama a la camara
    public float poscam; //obtiene la posición de la camara
    public int score; //declara el valor del puntaje
    public GUIText txt; //declara el texto

    void Start () {
        txt = this.GetComponent<GUIText>();
        cam = FindObjectOfType<Camera>(); //inicializa la camara        
        score = 0; //incializa el puntaje
	}

    void Update() {
        poscam = cam.transform.position.y;
        score = (int) (poscam*10);
        txt.text = "Score: " + score; //sube el score dependiendo de la posición de la camara
    }
}
