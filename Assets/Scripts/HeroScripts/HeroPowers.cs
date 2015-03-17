<<<<<<< HEAD
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
			if(Physics2D.OverlapCircle(transform.root.Find("groundCheck").transform.position, 1f, 1<<11)!=null)
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
=======
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
	public static bool ChargeSkill = true;
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
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            SummonBarrier();
        }	
		if(Input.GetButton ("Fire1"))
		{
			Drill();
		}
		/*if (!ChargeSkill&&!HeroController .GameOver) 
		{

			if((Input.GetKeyDown (KeyCode.LeftArrow)))
			{
				ArrowLeftCount=1;

				if(Time.time<lastTime+0.3f&&!player.GetComponent<HeroController>().facingRight&&!HeroStartCharge )
				{
					ArrowLeftCount=2;
					lastTime =0;
				}
				else
					lastTime=Time.time;

			}
			if((Input.GetKeyDown (KeyCode.RightArrow)))
			{
				ArrowRightCount=1;

				if(Time.time<lastTime+0.3f&&player.GetComponent<HeroController>().facingRight&&!HeroStartCharge)
				{
					ArrowRightCount=2;
					lastTime=0f;
				}
				else
					lastTime=Time.time;

			}
			if (Input.GetKeyUp (KeyCode.LeftArrow)&&HeroStartCharge&&!player.GetComponent<HeroController>().facingRight) 
			{
				ArrowLeftCount = 0;
				HeroStartCharge=false;
				HeroController.walkSpeed=20f;
			}
			if (Input.GetKeyUp (KeyCode.RightArrow)&&HeroStartCharge&&player.GetComponent<HeroController>().facingRight)
			{
				ArrowRightCount = 0;
				HeroStartCharge=false;
				HeroController.walkSpeed=20f;
			}

			if((ArrowLeftCount>=2||ArrowRightCount>=2)&&!HeroStartCharge)
			{

				HeroCharge();

			}

				
		}*/
		if (Input.GetAxis ("Charge")==1&&!HeroStartCharge&&!HeroController .GameOver&&!success ) 
		{
			if(ChargeSkill)
				HeroCharge ();

		}
		if (Input.GetAxis ("Charge") == 0 && HeroStartCharge&&!HeroController .GameOver )
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

    //This creates a shield around the hero, protecting him from harm.
    public void Shield()
    {

    }

    //Releases the energy stored within the hero in a sphere of destruction, destroying everything on screen.
    public void Bomb()
    {
        //bool success = heroController.Vitals.UseEnergy(100);
    }

    //Slows time, allowing the hero to outmaneuver the meteor and enemies.
    public void TimeWarp()
    {
        //bool success = heroController.Vitals.UseEnergy(100);
	}

    //Uses energy to regenerate health.
    public void Heal()
    {
        //bool success = heroController.Vitals.UseEnergy(66);
    }

	public void Drill()
	{
//		if(anim.GetBool("Ground"))
//			Destroy(Physics2D.OverlapCircle (transform.root.Find ("groundCheck").transform.position, 1f, 1 << 11).gameObject);
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
			upperFlareRender.enabled = true;
			lowerFlareRender.enabled = true;
			Debug.Log ("I charge now");
			if (player.GetComponent<HeroController> ().facingRight) 
			{
				player.rigidbody2D.velocity = new Vector2 (50f, player.rigidbody2D.velocity.y);
			}
			if (!player.GetComponent<HeroController> ().facingRight)
			{
				player.rigidbody2D.velocity = new Vector2 (-50f, player.rigidbody2D.velocity.y);
			}
		}
	}
	void StopCharge()
	{
		CancelInvoke ();
		Debug.Log ("stoped");
		success = false;
		HeroStartCharge = false;
		anim.SetBool ("Charge", false);
		upperFlareRender.enabled = false;
		lowerFlareRender.enabled = false;
	}
}
>>>>>>> CannonBoss-Merge1
