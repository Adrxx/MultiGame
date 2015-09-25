using UnityEngine;
using System.Collections;

//script para generar pelotitas

public class generador : MonoBehaviour{
    public GameObject pelotita; //pelotita
    private int contador; //contador de pelotitas en el juego
    private float timer =0f; //timer para determinar el tiempo y generar pelotitas
    private float limite= 1.3f; //valor absoluto de los limtes del rango en el que puede aparecer una nueva pelotita

    float posicionar() { //devuelve la posicion en la que aparecerá la siguiente pelotita seleccionada aleatoriamente del rango
        float posicion;
        posicion = Random.Range(-limite, limite);
        return posicion;
    }

    public int getContador() {
        return contador;
    }

	void Start () {
        contador = 1; //inicializa el contador
        
	}

	void Update () {
        timer = timer + Time.deltaTime; //avanza el timer con cada frame
        pelotita = GameObject.FindWithTag("Pelotita");
        if (timer > 5) { //crea una nueva pelotita cada que el timer llega a 5 segundos
            contador=contador+1;
            timer = 0;
			puntaje.globalScore += 1;
            Instantiate(pelotita, new Vector2(posicionar(), 5), pelotita.transform.rotation);     
        }
    }
}
