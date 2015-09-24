using UnityEngine;
using System.Collections;

public class tablita : MonoBehaviour {
    private int movimiento=2;

	void Start () {
	}
	
	void Update () {
        if (Input.GetKey("down")) transform.Rotate(Vector3.forward * -movimiento);
        if (Input.GetKey("up")) transform.Rotate(Vector3.forward * movimiento);
        if (Input.GetKey("left")) transform.position=new Vector3(transform.position.x-.05f, transform.position.y, transform.position.z);
        if (Input.GetKey("right")) transform.position = new Vector3(transform.position.x+.05f, transform.position.y, transform.position.z);
    }
    }

