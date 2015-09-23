using UnityEngine;
using System.Collections;

public class pelotita : MonoBehaviour {

    private Vector2 vector; //inicializar nuevo vector de velocidad de la pelota
    private Vector2 next;
    public Vector2 pos1; //declarar el primer pivote para el drag
    public Vector2 pos2; //declarar el segundo pivote para el drag
    public Vector3 piv1;
    public Vector3 piv2;
    public Rigidbody2D rb; //declarar el rigidbody de la pelota
    public Camera cam; //obtiene la cámara
    public LineRenderer lin; //saca una línea para disparar
    public Collider2D col;
    public float escalar =1f; //escalar para el vector de velocidad de disparo
    public float inter;
    private bool click=false; //comprobar el estado del mouse
    private bool destr=false; //determina si el objeto es destructible o no
    private bool cread=false; //determina si ya se creó la siguiente pelotita

    void Start () {
        rb = this.GetComponent<Rigidbody2D>(); //inicializar rigid body
        rb.isKinematic=true; //cancela el movimiento inicial
        lin = this.GetComponent<LineRenderer>(); //inicializa la linea
        cam = FindObjectOfType<Camera>(); //inicializa la camara
        col = this.GetComponent<Collider2D>();
        col.isTrigger=true;
	}

    void OnMouseDown() {
        pos1 = Input.mousePosition; //toma el primer pivote para el drag
        lin.SetWidth(.7f, .1f);
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
            lin.SetWidth(0, 0); //desaparece la línea al disparar la pelota
            inter = Time.timeSinceLevelLoad;
            col.isTrigger = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Pelotita") {
            if (destr) { //si el objeto actual es destructible, se destruye
                Destroy(this);
            }
            else{  //si el objeto actual no es destructible, destruye el contrario
                Destroy(other.gameObject);
                rb.velocity = next;
            }
        }
    }
	
	void Update () {
        if (this.transform.position.y < cam.transform.position.y - 5) Application.LoadLevel("Malavares"); //reinicia el nivel si se cumple la condición de derrota
        if (this.transform.position.y >= cam.transform.position.y + 4) cam.transform.position = 
                new Vector3(cam.transform.position.x, this.transform.position.y - 4, -10); //mueve la camara para seguir esta pelota
        if (rb.isKinematic) {
            this.transform.position=new Vector2(this.transform.position.x, cam.transform.position.y-2); //se asegura que la pelota se mantenga en posición con la cámara mientras no se lanza

        }
        next = rb.velocity;
        if (click){
            piv1 = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z); //crea el primer pivote para la linea
            piv2 = cam.ScreenToWorldPoint(Input.mousePosition); //crea el segundo pivote para la linea
            piv2.z = 0;
            lin.SetPosition(0, piv1); //crea la linea
            lin.SetPosition(1, piv2); //crea la linea
        }
        if (.5 > Time.timeSinceLevelLoad - inter && Time.timeSinceLevelLoad - inter > .4 && !rb.isKinematic && !cread && !destr){
            cread = true; //declara que se ha creado la siguiente pelotita
            destr = true; //hace esta pelota destructible
            Sprite nuevo = (Sprite)Instantiate(this, new Vector2(cam.transform.position.x, cam.transform.position.y-2), transform.rotation); //crea el siguiente objeto
        }
    }
}
