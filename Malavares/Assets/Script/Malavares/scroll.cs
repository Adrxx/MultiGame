using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {
    public Camera cam;
    private float poscam;
    public Vector2 offset;
    private Renderer rend;
	
	void Start () {
        cam = FindObjectOfType<Camera>();
        rend = this.GetComponent<Renderer>();
	}
	
	
	void Update () {
        poscam = cam.transform.position.y;
        this.transform.position = new Vector3(cam.transform.position.x, poscam,10);

        offset = new Vector2(cam.transform.position.x, poscam*0.1f);
        rend.material.mainTextureOffset = offset;
	}
}
