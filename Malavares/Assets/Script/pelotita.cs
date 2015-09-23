using UnityEngine;
using System.Collections;
using System;

public class pelotita : MonoBehaviour {

    private Vector2 vector; //inicializar nuevo vector de velocidad de la pelota
    private Vector2 next; //recupera el vector inicial tras una colisión
    private Vector2 pos1; //declarar el primer pivote para el drag
    private Vector2 pos2; //declarar el segundo pivote para el drag
    private Vector3 piv1; //primer pivote para la linea
    private Vector3 piv2; //segundo pivote para la linea
    private Rigidbody2D rb; //declarar el rigidbody de la pelota
    private Camera cam; //obtiene la cámara
    private LineRenderer lin; //saca una línea para disparar
    private Collider2D col; //llama al colisionador
    private SpriteRenderer rnd;
    private GameObject au;
    private AudioSource[] a;
    private float escalar = .2f; //escalar para el vector de velocidad de disparo
    private float inter; //intervalo de tiempo para la creación de la siguiente pelotita
    private float redox;
    public float start;
    public float redoxl;
    private Vector3 size;
    private bool click = false; //comprobar el estado del mouse
    private bool destr = false; //determina si el objeto es destructible o no
    private bool cread = false; //determina si ya se creó la siguiente pelotita
    private int i; //indice para escoger sprite
    public Sprite sprite;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;


    void Start() {
        au = GameObject.FindGameObjectWithTag("au");
        redox = .03f;
        rb = this.GetComponent<Rigidbody2D>(); //inicializar rigid body
        rb.isKinematic = true; //cancela el movimiento inicial
        lin = this.GetComponent<LineRenderer>(); //inicializa la linea
        lin.transform.position = new Vector3(lin.transform.position.x, lin.transform.position.y, 0); //mueve el line renderer
        cam = FindObjectOfType<Camera>(); //inicializa la camara
        col = this.GetComponent<Collider2D>(); //obtiene el collider
        col.isTrigger = true; //elimina collisiones mientras se apunta
        rnd = this.GetComponent<SpriteRenderer>();
        if (this.transform.localScale.x > .03) this.transform.localScale = new Vector3(this.transform.localScale.x - redox, this.transform.localScale.y - redox, 1);
        sprite = chooseSprite();
        rnd.sprite = sprite;
        a = au.GetComponents<AudioSource>();

    }


    Sprite chooseSprite() { 
        i = (int) Math.Round(UnityEngine.Random.Range(0f,2f));
        switch (i) {
           case 0:
                return sprite1;
                break;
           case 1:
                return sprite2;
                break;
            case 2:
                return sprite3;
                break;
        }
        return null;
    }

    void OnMouseDown() {
        pos1 = Input.mousePosition; //toma el primer pivote para el drag
        lin.SetWidth(start-redoxl, .1f);
        a[1].Play();
        click = true; 
    }

    void OnMouseUp() {
        if (rb.isKinematic)
        {
            a[3].Play();
            col.isTrigger = false;
            click = false;
            rb.isKinematic = false; //activa el movimiento
            pos2 = Input.mousePosition;  //toma el segundo pivote para el drag
            vector = new Vector2((pos1.x - pos2.x)*escalar,(pos1.y-pos2.y)*escalar); //crea el vector de velocidad a partir de los pivotes
            rb.velocity = vector; //inicializar velocidad a partir del vector
            lin.SetWidth(0, 0); //desaparece la línea al disparar la pelota
            inter = Time.timeSinceLevelLoad;
            
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Pelotita")
        {
            if (destr)
            { //si el objeto actual es destructible, se destruye
                Destroy(gameObject);
                a[4].Play();
            }
            else
            {  //si el objeto actual no es destructible, destruye el contrario
                Destroy(other.gameObject);
                rb.velocity = next;
            }
        }
        else {
            if (other.gameObject.tag == "bund") a[0].Play();
        }
    }

    void Update() {
        int count = GameObject.FindGameObjectsWithTag("Pelotita").Length;
        if (.8 > Time.timeSinceLevelLoad - inter && Time.timeSinceLevelLoad - inter > .7 && !rb.isKinematic && !cread && !destr && count < 2)
        {
            cread = true; //declara que se ha creado la siguiente pelotita
            destr = true; //hace esta pelota destructible
            Sprite nuevo = (Sprite)Instantiate(this, new Vector2(cam.transform.position.x, cam.transform.position.y - 2), transform.rotation); //crea el siguiente objeto

        }

        if (.8 > Time.timeSinceLevelLoad - inter && Time.timeSinceLevelLoad - inter > .7 && !rb.isKinematic && !cread && !destr && count<2){
            cread = true; //declara que se ha creado la siguiente pelotita
            destr = true; //hace esta pelota destructible
            Sprite nuevo = (Sprite)Instantiate(this, new Vector2(cam.transform.position.x, cam.transform.position.y-2), transform.rotation); //crea el siguiente objeto
            
        }

        if (this.transform.position.y < cam.transform.position.y - 5) {//reinicia el nivel si se cumple la condición de derrota
            a[2].Play();
            Application.LoadLevel("Malavares");

        }
        if (this.transform.position.y >= cam.transform.position.y + 4) cam.transform.position =
                new Vector3(cam.transform.position.x, this.transform.position.y - 4, -10); //mueve la camara para seguir esta pelota
        if (rb.isKinematic) {
            this.transform.position = new Vector2(this.transform.position.x, cam.transform.position.y - 2); //se asegura que la pelota se mantenga en posición con la cámara mientras no se lanza

        }
        next = rb.velocity;
        if (click) {
            piv1 = new Vector3(this.transform.position.x, this.transform.position.y, 0); //crea el primer pivote para la linea
            piv2 = cam.ScreenToWorldPoint(Input.mousePosition); //crea el segundo pivote para la linea
            piv2.z = 0;
            lin.SetPosition(0, piv1); //crea la linea
            lin.SetPosition(1, piv2); //crea la linea
        }
        
        /*if (.8 > Time.timeSinceLevelLoad - inter && Time.timeSinceLevelLoad - inter > .7 && !rb.isKinematic && !cread && !destr && count<2){
            cread = true; //declara que se ha creado la siguiente pelotita
            destr = true; //hace esta pelota destructible
            Sprite nuevo = (Sprite)Instantiate(this, new Vector2(cam.transform.position.x, cam.transform.position.y-2), transform.rotation); //crea el siguiente objeto
            
        }*/
    }
}
