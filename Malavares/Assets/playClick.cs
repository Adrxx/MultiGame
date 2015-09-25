using UnityEngine;
using System.Collections;

public class playClick : MonoBehaviour {
	

	private bool toNext = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		fader f = GameObject.Find("Fader").GetComponent<fader>();

	

		if (this.toNext) {

			Debug.Log(f.isInStartColor);
			if (!f.isInStartColor)
				Application.LoadLevel ("Other");
		}


	}

	void OnMouseDown()
	{
		fader f = GameObject.Find("Fader").GetComponent<fader>();

		f.startUnFade();
		
		this.toNext = true;

	}


}
