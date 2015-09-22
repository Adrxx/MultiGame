using UnityEngine;
using System.Collections;

public class pruebapelotita : MonoBehaviour {

    public Vector2 vector=new Vector2(0,0); //inicializar nuevo vector para pruebas modificable en la pantalla de unity
    public Rigidbody2D rb; //declarar el rigidbody de la pelota

	void Start () {
        rb= gameObject.GetComponent<Rigidbody2D>(); //inicializar rigid body
        rb.velocity=vector; //inicializar velocidad a partir del vector
	}
	
	void Update () {
	}
}
