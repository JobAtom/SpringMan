using UnityEngine;
using System.Collections;

public class MineScript : MonoBehaviour {


	public GameObject ExplosionEffect;
	public float delay;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag == "Player" || other.collider.tag == "trap") 
		{
			Invoke ("Explosion",delay);
			//Debug.Log("Explosion");

		}
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.collider.tag == "Player" || other.collider.tag == "trap") 
		{
			Invoke ("Explosion",delay);
			//Debug.Log("Explosion");
			
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" || other.tag == "trap") 
		{
			Invoke ("Explosion",delay);
			Debug.Log("Explosion");
			
		}
	}



	void Explosion()
	{
		CancelInvoke ();
		Instantiate (ExplosionEffect, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0)));
		Destroy(this.gameObject);
	}

}
