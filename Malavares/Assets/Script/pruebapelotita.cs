using UnityEngine;
using System.Collections;

public class pruebapelotita : MonoBehaviour {

    private Vector2 vector; //inicializar nuevo vector de velocidad de la pelota
    public Rigidbody2D rb; //declarar el rigidbody de la pelota
    public Vector2 pos1;
    public Vector2 pos2;
    public float escalar =1f;

    void Start () {
        rb= gameObject.GetComponent<Rigidbody2D>(); //inicializar rigid body
        rb.isKinematic=true; //cancela el movimiento inicial
	}

    void OnMouseDown() {
        pos1 = Input.mousePosition;
    }

    void OnMouseUp() {
        if (rb.isKinematic)
        {
            rb.isKinematic = false; //activa el movimiento
            pos2 = Input.mousePosition;
            vector = new Vector2((pos1.x - pos2.x)*escalar,(pos1.y-pos2.y)*escalar);
            rb.velocity = vector; //inicializar velocidad a partir del vector
        }
    }
	
	void Update () {
	}
}
