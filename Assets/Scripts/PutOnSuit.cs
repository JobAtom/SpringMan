using UnityEngine;
using System.Collections;

public class PutOnSuit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		HeroController player = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroController>();
		player.suitOn = true;
	}
}
