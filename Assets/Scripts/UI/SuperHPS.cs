using UnityEngine;
using System.Collections;

public class SuperHPS : MonoBehaviour {
	
	public camerafollowing camera;
	HeatResistantSuit heatSuit;
	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera").transform.parent.GetComponent<camerafollowing> ();
		heatSuit = GameObject.Find ("HeatResistantSuit").GetComponent<HeatResistantSuit>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			camera.BossCamera ();
			HeroPowers.BarrierSkill = false;
			//Instantiate (Barrier, new Vector3 (0.0f, transform.position.y + 4, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0)));
			float oldMaxTime=heatSuit.maxTime;
			heatSuit.maxTime =200f;
			heatSuit.currentTime =heatSuit.maxTime-(oldMaxTime-heatSuit.currentTime);
			Destroy(this.gameObject);
		}
	}
}
