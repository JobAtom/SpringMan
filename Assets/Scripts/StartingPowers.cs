using UnityEngine;
using System.Collections;

public class StartingPowers : MonoBehaviour {
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		HeroPowers.ChargeSkill = true;
		HeroPowers.DrillSkill = true;
		HeroPowers.BarrierSkill = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		VitalsScript.CurrentEnergy += 1;
	}
}
