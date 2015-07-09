using UnityEngine;
using System.Collections;

public class DamageHRS : MonoBehaviour {
	public float damageRate = 1f;

	private HeatResistantSuit heatSuit;
	private GameObject player;


	private bool causeDamage = false;

	// Use this for initialization
	void Start () {
		heatSuit = GameObject.Find("HeatResistantSuit").GetComponent<HeatResistantSuit>();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//if(causeDamage)

	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log("Entered Trigger");
		if(other.tag == "Player")
			InvokeRepeating("DamageSuit",0,1.25f);
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Player")
			CancelInvoke ("DamageSuit");
	}

	void DamageSuit(){
		heatSuit.currentTime -= damageRate;
	}
}
