using UnityEngine;
using System.Collections;

public class movercam : MonoBehaviour {

    public Camera cam; //objeto camara
    public Transform tracam; //transform de la camara
    public Transform tra; //transform de este objeto

    // Use this for initialization
    void Start () {
        cam = (Camera)FindObjectOfType<Camera>(); //encuentra el objeto camara
        tracam = cam.GetComponent<Transform>(); //incializa el objeto camara
        tra = this.GetComponent<Transform>(); //inicializa el transform de este objeto
	}
	
	// Update is called once per frame
	void Update () {
       if (tra.position.y>=tracam.position.y+4) tracam.position=new Vector3(tracam.position.x, tra.position.y-4,-10); //mueve la camara para seguir esta pelota
	}
}
 