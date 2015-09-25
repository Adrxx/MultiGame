using UnityEngine;
using System.Collections;

public class Contador : MonoBehaviour {

    public GUIText marcador;
    public GameObject m;
    public GameObject audio;
    public AudioSource[] a;

	private bool toNext = false;

	void goToGameOver()
	{
		
		fader f = GameObject.Find("Fader").GetComponent<fader>();

		this.transform.position = new Vector3(-100,1000,this.transform.position.z);

		
		f.endColor = Color.red;
		
		f.startUnFade();
		
		this.toNext = true;
		
	}
	// Use this for initialization
	void Start () {
        audio = GameObject.FindWithTag("Audio");
        a = audio.GetComponents<AudioSource>();
        m = GameObject.FindWithTag("Contador");
        marcador = m.GetComponent<GUIText>();
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            a[1].Play();

			GameObject puntaje = GameObject.Find("Puntaje");
			
			puntaje p = puntaje.GetComponent<puntaje>();
			
			p.addScore();
            
        }

    }

    // Update is called once per frame
    void Update () {

		if (this.toNext) {
			fader f = GameObject.Find("Fader").GetComponent<fader>();

			Debug.Log (f.isInStartColor);
			if (!f.isInStartColor)
				Application.LoadLevel ("Menu");
			
		} else {

			if (this.transform.position.y < -5) {
				goToGameOver();
			}

		}



			//

    }
	
		
}