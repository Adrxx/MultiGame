using UnityEngine;
using System.Collections;

public class Record : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<GUIText> ().text = "Último puntaje:  " + puntaje.globalScore;
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<GUIText> ().text = "Último puntaje:  " + puntaje.globalScore;

	}


}
