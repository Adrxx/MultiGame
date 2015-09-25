using UnityEngine;
using System.Collections;

//script que maneja el score
public class score : MonoBehaviour {
    private GameObject manager; //obtiene el manejador de pelotitas
    private generador gen; //obtiene el script del manejador que genera las pelotitas
    private int puntos; //variable de puntos
    public GUIText txt; //texto de gui

    void Start() {
        txt = this.GetComponent<GUIText>(); //declara el texto del gui
        manager = GameObject.FindWithTag("manager"); //manejador de pelotitas
        gen = manager.GetComponent<generador>(); //generador
    }

	void Update () {
        puntos = gen.getContador(); //obtiene los puntos por el contador de pelotitas
        txt.text = "" + puntos; //pone el texto en el gui
       
	}
}
