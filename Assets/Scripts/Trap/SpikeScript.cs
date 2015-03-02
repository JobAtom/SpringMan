using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

	public bool rotateleft;
	public bool rotateright;
	private float offset=0f;
	private Vector3 rotatepointleft;
	private Vector3 rotatepointright;
	public bool Onboard;
	// Use this for initialization
	void Start () {
		if(this.gameObject.GetComponent<SpriteRenderer>()!=null)
			offset = this.gameObject.GetComponent<SpriteRenderer> ().bounds.size.x/2;
		rotatepointleft = this.transform.position - new Vector3 (offset, 0, 0);
		rotatepointright = this.transform.position + new Vector3 (offset, 0, 0);
		Onboard = false;

	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (rotateleft&&!rotateright)
		{
			transform.RotateAround(rotatepointleft, Vector3.forward, 30 * Time.deltaTime);
		}
		if (rotateright&&!rotateleft) 
		{
			transform.RotateAround(rotatepointright, Vector3.forward, -30 * Time.deltaTime);
		}
		/*if (Onboard&&!HeroController.GameOver ) 
		{

			HitPlayer();
		}*/
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.tag == "Player")
        {
			other.gameObject.GetComponent<HeroController>().particle.Emit (1);
			if(other.gameObject.GetComponent<HeroController >().Vitals.TakeDamage ())
			{
				var shield = GameObject.Find("SpikeShield").gameObject;
				shield.GetComponent<SpikeShieldScript>().Drop();
			}

        }
    }
	/*void OnCollisionExit2D(Collision2D other)
	{
		if (other.collider.tag == "Player")
		{

			Onboard=false;
		}
	}*/
	void OnCollisionStay2D(Collision2D other)
	{

		if (other.collider.tag == "Player")
		{

			other.gameObject.GetComponent<HeroController>().particle.Emit (1);
			if(other.gameObject.GetComponent<HeroController >().Vitals.TakeDamage ())
			{
				var shield = GameObject.Find("SpikeShield").gameObject;
				shield.GetComponent<SpikeShieldScript>().Drop();
			}

		}

	}
	void HitPlayer()
	{
		GameObject.FindGameObjectWithTag ("Player").GetComponent<HeroController>().particle.Emit (1);
		if(GameObject.FindGameObjectWithTag ("Player").GetComponent<HeroController >().Vitals.TakeDamage ())
		{
			var shield = GameObject.Find("SpikeShield").gameObject;
			shield.GetComponent<SpikeShieldScript>().Drop();
		}
	}
}
