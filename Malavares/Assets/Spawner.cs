using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


	public GameObject spike;
	private float timeSum = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.timeSum += Time.deltaTime;
		//Debug.Log (Time.deltaTime);

		if (this.timeSum > Random.Range(0.27f,0.85f)) {
			//Debug.Log (this.timeSum);
			this.timeSum = 0.0f;


			for (int i = 0; i < Random.Range(3,7); i++)
			{

				Vector3 pos =new Vector3(this.transform.position.x,this.transform.position.y - (0.5f * i),0);
				GameObject obj =  Instantiate(spike,pos,this.transform.rotation) as GameObject;
				obj.AddComponent<SpikeScript>();
			}


		}
	}
}
