using UnityEngine;
using System.Collections;

//script para el gui con las vidas
public class vidas : MonoBehaviour {
    private GUIText txt; //declara el componente de gui
    private int lives; //declara la variable de vidas
	
	void Start () {
        txt = this.GetComponent<GUIText>(); //inicializa el componente de gui
        lives = 1; //inicializa las vidas con un número
	}

    public int getVidas(){ //regresa el numero de vidas que restan
        return lives; 
    }

    public void setVidas(int nv) { //permite modificar el numero de vidas
        lives = nv;
    }

    void Update () { 
        txt.text = "Vidas: " + lives; //pone el texto de gui
        if (lives <= 0) { //si la vidas son menores o iguales a 0, termina el nivel
            Application.LoadLevel("Tabla");
        }
	}
    
}
