using UnityEngine;
using System.Collections;

public class movercam : MonoBehaviour {

    public Camera cam;
    public Transform tracam;
    public Transform tra;

    // Use this for initialization
    void Start () {
        cam = (Camera)FindObjectOfType<Camera>(); 
        tracam = cam.GetComponent<Transform>();
        tra = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (tra.position.y>=tracam.position.y+4) tracam.position=new Vector2(tracam.position.x, (tra.position.y-3)*Time.deltaTime);
	}
}
