using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
			var shield = GameObject.Find("SpikeShield").gameObject;
			shield.GetComponent<SpikeShieldScript>().Drop();
			other.gameObject.GetComponent<HeroController>().particle.Emit (1);
            other.gameObject.GetComponent<HeroController>().Vitals.TakeDamage();
        }
    }
	void OnCollisionStay2D(Collision2D other)
	{
		if (other.collider.tag == "Player")
		{
			var shield = GameObject.Find("SpikeShield").gameObject;
			shield.GetComponent<SpikeShieldScript>().Drop();
			other.gameObject.GetComponent<HeroController>().particle.Emit (1);
			other.gameObject.GetComponent<HeroController >().Vitals.TakeDamage ();

		}
	}
}
