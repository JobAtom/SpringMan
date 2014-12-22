using UnityEngine;
using System.Collections;

public class PlatformDown : MonoBehaviour {

	//private GameObject player;
	// Use this for initialization
	void Start () {
		//player = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag == "Player")
		{
			this.gameObject.rigidbody2D .velocity=new Vector2(0,-3f);
			//this.gameObject.rigidbody2D .isKinematic =false;
			Invoke ("donotKinematic",1.5f);
		}


	}
	void donotKinematic()
	{
		CancelInvoke ();
		//this.gameObject.rigidbody2D .isKinematic = true;
		this.gameObject.rigidbody2D.velocity = new Vector2 (0, 0);
	}
}
