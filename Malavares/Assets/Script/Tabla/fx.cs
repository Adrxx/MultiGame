using UnityEngine;
using System.Collections;

//script para el manejo de sonido
public class fx : MonoBehaviour {
    public AudioSource[] a;

    void Start () {
        a = this.GetComponents<AudioSource>();
	}
	
	void Update () {
	
	}
}
