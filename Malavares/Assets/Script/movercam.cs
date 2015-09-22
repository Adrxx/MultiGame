using UnityEngine;
using System.Collections;

public class movercam : MonoBehaviour {

    public Camera cam; //objeto camara

    void Start () {
        cam = (Camera)FindObjectOfType<Camera>(); //encuentra el objeto camara
	}
	
	
	void Update () {
       if (this.transform.position.y>=cam.transform.position.y+4) cam.transform.position=new Vector3(cam.transform.position.x, this.transform.position.y-4,-10); //mueve la camara para seguir esta pelota
	}
}
 