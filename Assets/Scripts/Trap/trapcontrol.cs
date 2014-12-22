using UnityEngine;
using System.Collections;

public class trapcontrol : MonoBehaviour {
	public bool trapOn=true;
	public GameObject[] trap;
	public AudioSource Switch;

	// Use this for initialization
	void Start () 
	{
		foreach (GameObject l in trap)
		{
			l.SetActive (true);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (trapOn) {
		
		} else 
		{
			foreach (GameObject l in trap)
			{
				if(l.tag=="trap")
				{
					l.GetComponent<platformMove>().enabled=true;
				}
				else 
					l.SetActive (false);
				
			}
	
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			trapOn=false;
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && trapOn) 
        {
            trapOn=false;
            FlipLever(false);
        }
    }

    void FlipLever(bool state)
    {
		Switch.Play ();
        if (state)
        {
        }
        else
        {
            transform.Find("leverred").GetComponent<SpriteRenderer>().enabled = false;
            transform.Find("levergreen").GetComponent<SpriteRenderer>().enabled = true;

        }
    }

}
