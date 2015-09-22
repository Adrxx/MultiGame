using UnityEngine;
using System.Collections;

public class pruebapelotita : MonoBehaviour {

    private Vector2 vector; //inicializar nuevo vector de velocidad de la pelota
    public Rigidbody2D rb; //declarar el rigidbody de la pelota
    public Vector2 pos1; //declarar el primer pivote para el drag
    public Vector2 pos2; //declarar el segundo pivote para el drag
    public float escalar =1f;

    void Start () {
        rb= gameObject.GetComponent<Rigidbody2D>(); //inicializar rigid body
        rb.isKinematic=true; //cancela el movimiento inicial
	}

    void OnMouseDown() {
        pos1 = Input.mousePosition; //toma el primer pivote para el drag
    }

    void OnMouseUp() {
        if (rb.isKinematic)
        {
            rb.isKinematic = false; //activa el movimiento
            pos2 = Input.mousePosition;  //toma el segundo pivote para el drag
            vector = new Vector2((pos1.x - pos2.x)*escalar,(pos1.y-pos2.y)*escalar); //crea el vector de velocidad a partir de los pivotes
            rb.velocity = vector; //inicializar velocidad a partir del vector
        }
    }
	
	void Update () {
	}
}
