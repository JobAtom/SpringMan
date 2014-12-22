using UnityEngine;
using System.Collections;

public class HeroPowers : MonoBehaviour
{

    public GameObject Barrier;
    private GameObject player;
    private HeroController heroController;
	public static bool ChargeSkill = false;
	float lastTime;
	public float ArrowLeftCount;
	public float ArrowRightCount;
	public bool HeroStartCharge;
	bool success;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        heroController = player.GetComponent<HeroController>();
		ArrowLeftCount = 0;
		ArrowRightCount = 0;
		HeroStartCharge=false;
		success = false;


    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            SummonBarrier();
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
	public void HeroCharge()
	{
		Invoke ("StopCharge", 0.2f);

		if (!player.GetComponent<HeroController> ().enabled)
						return;
		success=heroController .Vitals .UseEnergy (1);

		if (success&&!HeroController.GameOver) 
		{
			HeroStartCharge=true;
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


	}


}
