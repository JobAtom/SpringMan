using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public int heal = 1;
	public VitalsScript vitals;
	private GameObject player;
		
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			player.GetComponent<HeroController>().Vitals.Heal(heal);
			GameObject.FindGameObjectWithTag ("Player").GetComponent<HeroController>().HealSound .Play ();
			Destroy (this.gameObject);
		}
	}
}
