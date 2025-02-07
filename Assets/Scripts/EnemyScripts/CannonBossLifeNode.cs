﻿using UnityEngine;
using System.Collections;

public class CannonBossLifeNode : MonoBehaviour 
{
	public int nodeLife;
	public Sprite damagedNode;
	public GameObject weekpoint;
	private GameObject ShowWeekPoint=null;


	private bool nodeAlive;

	// Use this for initialization
	void Start () 
	{
		nodeAlive = true;
		ShowWeekPoint=Instantiate (weekpoint, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject ;
//		scriptConnector = GameObject.FindGameObjectWithTag("Boss").GetComponent<CannonBossLife>();
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			nodeLife--;
			iTween.ShakePosition(this.gameObject,new Vector3(0.3f,0.3f,0),0.5f);
			other.gameObject.rigidbody2D.velocity = new Vector2(other.gameObject.rigidbody2D.velocity.x, (-other.gameObject.rigidbody2D.velocity.y<25f)?18f:22f);
			if (Input.GetAxis("Jump") >0)
			{
				other.gameObject.rigidbody2D.velocity=new Vector2(other.gameObject.rigidbody2D.velocity.x,35f); 

			}
		}

	}

	void FixedUpdate()
	{	
		if(nodeLife == 0 && nodeAlive)
		{
			GetComponent<SpriteRenderer>().sprite = damagedNode;
			Destroy (ShowWeekPoint );
			GameObject.FindGameObjectWithTag("Boss").GetComponent<CannonBossLife>().bossLifeNodes--;
			nodeAlive = false;

		}
	}
}
