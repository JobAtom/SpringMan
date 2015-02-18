using UnityEngine;
using System.Collections;

public class SpikeProduce : MonoBehaviour {
	public GameObject spike;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("spike(Clone)") == null) 
		{
			Instantiate (spike,this.gameObject.transform.position,Quaternion.identity);
		}
	
	}
}
