using UnityEngine;
using System.Collections;

//script que dicta la conducta de la tabla balanceadora

public class tablita : MonoBehaviour {
    private float velrotacion = 5f; // velocidad de rotación de la tabla 

	void Start () {
	}

    void Update() {

		transform.Translate(Input.acceleration.x * 1.0f, 0, 0);
		this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x,-2.0f,2.0f),Mathf.Clamp(this.transform.position.y,-4.0f,-3.0f),this.transform.position.z);

		transform.Rotate(Vector3.forward,Input.acceleration.x * 8.0f); //rotación hacia la derecha
		//this.transform.rotation = new Vector3(this.transform.rotation.x,this.transform.rotation.y,Mathf.Clamp(this.transform.rotation.z,-50.0f,50.0f));

    }
}

