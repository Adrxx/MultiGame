using UnityEngine;
using System.Collections;

public class ChangingButton : MonoBehaviour {


	private float timer = 0.0f;
	public Sprite[] sprites;
	private int lastIndex = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.timer += Time.deltaTime;
		if (this.timer > 0.2f) {
			this.timer = 0.0f;

			SpriteRenderer sp = this.GetComponent<SpriteRenderer>();

			int newIndex = 0;

			while (newIndex == lastIndex)
			{
				newIndex = Random.Range(0,this.sprites.Length);
			}
			lastIndex = newIndex;

			sp.sprite = this.sprites[newIndex];

		}

	
	}

	
}
