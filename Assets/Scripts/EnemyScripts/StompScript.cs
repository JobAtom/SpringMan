using UnityEngine;
using System.Collections;

public class StompScript : MonoBehaviour {

	// Use this for initialization
	private GameObject parent;
	void Start () {
		parent = transform.parent.gameObject;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroController>();
		var par = parent.GetComponent<EnemyScript> ();
        if (!par.dead && other.tag == "Player" && player.Vitals.Dead == false)
		{
			EnemyScript script = transform.root.gameObject.GetComponent<EnemyScript>();
			script.Stomped = true;
		}
	}
}
