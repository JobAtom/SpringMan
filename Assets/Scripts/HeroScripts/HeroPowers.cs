﻿using UnityEngine;
using System.Collections;

public class HeroPowers : MonoBehaviour
{
	Animator anim;
    public GameObject Barrier;
    private GameObject player;
	private GameObject upperFlare;
	private GameObject lowerFlare;
    private HeroController heroController;
	private SpriteRenderer upperFlareRender;
	private SpriteRenderer lowerFlareRender;

	public static bool ChargeSkill =true;

	public static bool BarrierSkill =true;
	public static bool DrillSkill=false;
	float lastTime;
	public float ArrowLeftCount;
	public float ArrowRightCount;
	public bool HeroStartCharge;
	bool success;

    // Use this for initialization
    void Start()
    {
		anim = GetComponentInParent<Animator> ();
        player = GameObject.FindGameObjectWithTag("Player");
		upperFlare = GameObject.Find ("Upper Flare");
		lowerFlare = GameObject.Find ("Lower Flare");
        heroController = player.GetComponent<HeroController>();
		upperFlareRender = upperFlare.GetComponent<SpriteRenderer> ();
		lowerFlareRender = lowerFlare.GetComponent<SpriteRenderer> ();
		ArrowLeftCount = 0;
		ArrowRightCount = 0;
		HeroStartCharge=false;
		success = false;
		anim.SetBool ("Charge", false);
    }
	
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
		if(Input.GetButtonDown("Barrier") && !HeroController.GameOver)
        {
			if(BarrierSkill)
            	SummonBarrier();
        }	

		if (Input.GetButtonDown("Drill") && !HeroController.GameOver)
		{
			if(DrillSkill)
				UseDrill();
		}

		if (Input.GetButtonDown ("Charge")&&!HeroStartCharge&&!HeroController .GameOver&&!success ) 
		{
			if(ChargeSkill)
				HeroCharge ();

		}
		if (Input.GetButtonUp ("Charge") && HeroStartCharge&&!HeroController .GameOver )
		{
			HeroStartCharge=false;

		}
    }
    //This summons a barrier, which stops the meteor for a short time.
    public void SummonBarrier()
    {
        var meteor = GameObject.Find("Meteor");

        bool success = heroController.Vitals.UseEnergy(3);
        if (success)
        {
            if (meteor.transform.position.y - transform.position.y < 8)
				Instantiate(Barrier, new Vector3(0.5859733f, meteor.transform.position.y - 5, meteor.transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
            else
				Instantiate(Barrier, new Vector3(0.5859733f, transform.position.y + 12, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));

        }
    }

	public void UseDrill()
	{
		bool success = heroController.Vitals.UseEnergy (4);
		if (success) 
		{
			//Destroy(Physics2d.overlapcircle(transform.root.find("groundCHeck").transform.position, 1f, 1 << 11).gameObject);
			Destroy(Physics2D.OverlapCircle(transform.root.Find("groundCheck").transform.position, 1f, 1<<11).gameObject);
		}
	}

	public void HeroCharge()
	{
		Invoke ("StopCharge", 0.2f);

		if (!player.GetComponent<HeroController> ().enabled)
						return;
		success=heroController .Vitals .UseEnergy (1);

		if (success&&!HeroController.GameOver) 
		{
			HeroStartCharge=true;
			anim.SetBool("Charge", true);
			heroController .SetFall(false);
			upperFlareRender.enabled = true;
			lowerFlareRender.enabled = true;
			if (player.GetComponent<HeroController> ().facingRight) 
			{
				player.rigidbody2D.velocity = new Vector2 (40f, 0f);
			}
			if (!player.GetComponent<HeroController> ().facingRight)
			{
				player.rigidbody2D.velocity = new Vector2 (-40f, 0f);
			}
		}
	}
	void StopCharge()
	{
		CancelInvoke ();
		heroController .SetFall (true);
		success = false;
		HeroStartCharge = false;
		anim.SetBool ("Charge", false);
		upperFlareRender.enabled = false;
		lowerFlareRender.enabled = false;
	}
}
