using UnityEngine;
using System.Collections;

public class CannonBossLifeNode : MonoBehaviour 
{
	public int nodeLife;
	public Sprite damagedNode;
	// Use this for initialization
	void Start () 
	{
//		scriptConnector = GameObject.FindGameObjectWithTag("Boss").GetComponent<CannonBossLife>();
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
			nodeLife--;
		if(nodeLife == 0);
			GetComponent<SpriteRenderer>().sprite = damagedNode;
	}

	void FixedUpdate()
	{
		if(nodeLife == 0)
			GameObject.FindGameObjectWithTag("Boss").GetComponent<CannonBossLife>().bossLifeNodes--;
	}
}
