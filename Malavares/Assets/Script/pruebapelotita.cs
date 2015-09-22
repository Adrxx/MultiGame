using UnityEngine;
using System.Collections;

public class pruebapelotita : MonoBehaviour {

    private Vector2 vector; //inicializar nuevo vector de velocidad de la pelota
    public Vector2 pos1; //declarar el primer pivote para el drag
    public Vector2 pos2; //declarar el segundo pivote para el drag
    public Vector3 piv1;
    public Vector3 piv2;
    public Rigidbody2D rb; //declarar el rigidbody de la pelota
    public Camera cam;
    public LineRenderer lin; 
    public float escalar =1f;
    private bool click = false;

    void Start () {
        rb= this.GetComponent<Rigidbody2D>(); //inicializar rigid body
        rb.isKinematic=true; //cancela el movimiento inicial
        lin = this.GetComponent<LineRenderer>();
        cam = (Camera)FindObjectOfType<Camera>();
	}

    void OnMouseDown() {
        pos1 = Input.mousePosition; //toma el primer pivote para el drag
        click = true;
    }

    void OnMouseUp() {
        if (rb.isKinematic)
        {
            click = false;
            rb.isKinematic = false; //activa el movimiento
            pos2 = Input.mousePosition;  //toma el segundo pivote para el drag
            vector = new Vector2((pos1.x - pos2.x)*escalar,(pos1.y-pos2.y)*escalar); //crea el vector de velocidad a partir de los pivotes
            rb.velocity = vector; //inicializar velocidad a partir del vector
            lin.SetWidth(0, 0);
        }
    }
	
	void Update () {
        if (click){
            piv1 = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            piv2 = cam.ScreenToWorldPoint(Input.mousePosition);
            piv2.z = 0;
            lin.SetPosition(0, piv1);
            lin.SetPosition(1, piv2);
        }
	}
}
