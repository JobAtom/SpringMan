using UnityEngine;
using System.Collections.Generic;

public class HeroController : MonoBehaviour
{

    Animator anim;
    public ParticleSystem particle;
    public bool grounded = false;
    private float groundRadius = 0.01f;
    private float lastHitTime;
    private bool stunned = false;
    private bool restarting = false;    //Checks if HandleDeath has been called.
    private int numberOfJumps = 0;

    public bool facingRight = true;
    private bool letgo = true;
    private bool jumping;
    private bool falling = true;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public static float walkSpeed = 20f;
    public float maxFallSpeed = -50f;
    public float jumpForce = 700f;
    public VitalsScript Vitals;

    public static bool GameOver = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        particle = GetComponent<ParticleSystem>();
        Collider2D[] col = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D cc in col)
            cc.isTrigger = false;
        anim.SetBool("Dead", false);
        lastHitTime = Time.time;
		if (Application .loadedLevelName != "MainMenu")
        	Vitals = new VitalsScript();
        HeroController.GameOver = false;
        restarting = false;
        falling = true;
        jumping = false;
        CheckPoint.Check();
    }

    void FixedUpdate()
    {
		if (Application .loadedLevelName != "MainMenu")
		{
			Vitals.HandleEnergy ();
			if (HeroController.GameOver || Vitals.Dead) 
			{
				HandleDeath ();
				Fall ();
			}
		}
        if (!stunned&&!HeroController .GameOver)
        {
            Controls();
        }
    }

    void Controls()
    {

        if (Input.GetAxis("Jump") == 1 && numberOfJumps == 0)
        {
            jumping = true;
            falling = false;
        }
        else if (Input.GetAxis("Jump") < 1 && jumping)
        {
            jumping = false;
            falling = true;
            numberOfJumps++;
        }
        if (jumping)
        {
            Jump();
        }
        else if (falling)
        {
            Fall();
        }
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (grounded && numberOfJumps > 0)
        {
            Invoke("ResetFatigue", .01f);
        }
        else if (!grounded)
        {
            falling = true;
            if (Input.GetAxis("Jump") == 0)
                numberOfJumps++;
        }
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        Walk(move, rigidbody2D.velocity.y);
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    void Walk(float move, float fallSpeed)
    {

        if (grounded&&!this.gameObject.GetComponentInChildren<HeroPowers >().HeroStartCharge )
            rigidbody2D.velocity = new Vector2(move * walkSpeed, fallSpeed);
        if(!grounded&&!this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge)
            rigidbody2D.velocity = new Vector2(move * walkSpeed, fallSpeed);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {

		if ((other.collider.tag == ("Weapon") || other.collider.tag == ("Enemy")||other.collider.tag=="Boss")&&!this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge)
        {
            if (Time.time > lastHitTime + .55)
            {
                TakeHit(other);
                lastHitTime = Time.time;
            }
        }
        else
        {
        }
		if ((other.collider.tag == ("Weapon") || other.collider.tag == ("Enemy")) && this.gameObject.GetComponentInChildren<HeroPowers> ().HeroStartCharge)
		{
			if (other.collider.GetComponent<EnemyScript>() != null||other.collider.name!="Boss")
				other.collider.GetComponent<EnemyScript>().Kill();
		
		}
		else if (other.collider.tag == "trap"||other.collider.tag=="Wall"&&this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge) 
		{
			StopCharge();
		}
		else if (this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge) 
		{
			if(facingRight )
			{
				rigidbody2D.velocity=new Vector2(50f,rigidbody2D.velocity.y);
			}
			else
				rigidbody2D.velocity=new Vector2(-50f,rigidbody2D.velocity.y);
		}

    }
	/*void OnCollisionStay2D(Collision2D other)
	{
		if (this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge&&this.enabled) 
		{
			if(facingRight )
			{
				rigidbody2D.velocity=new Vector2(50f,rigidbody2D.velocity.y);
			}
			else
				rigidbody2D.velocity=new Vector2(-50f,rigidbody2D.velocity.y);
		}
	}*/

    void TakeHit(Collision2D other)
    {
		if (other.gameObject.GetComponent<MoveProjectileScript> () != null)
						Destroy (other.gameObject);
        stunned = true;
        if (transform.position.x < other.transform.position.x)
            rigidbody2D.velocity = new Vector2(-10f, rigidbody2D.velocity.y / 2 + 5f);
        else
            rigidbody2D.velocity = new Vector2(10f, rigidbody2D.velocity.y / 2);
        Invoke("unstun", 0.15f);
        var shield = transform.Find("SpikeShield").gameObject;
        shield.GetComponent<SpikeShieldScript>().Drop();
        particle.Emit(15);
		StopCharge ();
        Vitals.TakeDamage();
        if (Vitals.Dead)
        {
            particle.Emit(10);

        }
        //Activate particle system or flash the character.
    }

    void unstun()
    {
        stunned = false;
    }

    public void Restart()
    {
        LevelChangeScript.RestartLevel();
        VitalsScript .CurrentEnergy = 0;
        VitalsScript .CurrentHealth = VitalsScript.MaxHealth ;
        Score.score = 0;
		Score.memory = 0;

        /*Shop.speedlevel = 0;
        Shop.energylevel = 0;
        Shop.healthlevel = 0;
        walkSpeed = 20f;
        VitalsScript .MaxEnergy = 100f;
        VitalsScript .MaxHealth = 100f;*/
    }

    /* 
     * This code will handle the players death. If it has not been called before,
     * it will set GameOver to true and Invoke Restart after two seconds.
     */
    public void HandleDeath()
    {
        if (!restarting)
        {
            HeroController.GameOver = true;

            Collider2D[] col = GetComponentsInChildren<Collider2D>();
            foreach (Collider2D cc in col)
                cc.isTrigger = true;
            restarting = true;
            falling = true;
            Invoke("Restart", 2);

        }
    }

    int maxJumpTime = 15;
    int jumpHeldTime = 0;
    void Jump()
    {
        if (jumpHeldTime < maxJumpTime && numberOfJumps == 0)
        {
            anim.SetBool("Ground", false);
            //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 20f);
            if (jumpHeldTime == 0)
                rigidbody2D.AddForce(new Vector2(0, 325f));
            else if (jumpHeldTime < maxJumpTime / 2)
                rigidbody2D.AddForce(new Vector2(0, 40f));
            else
                rigidbody2D.AddForce(new Vector2(0, 30f));
            jumpHeldTime++;
        }
        else
        {
            jumping = false;
            falling = true;
            numberOfJumps++;
        }
    }

    void ResetFatigue()
    {
        if (grounded)
        {
            jumpHeldTime = 0;
            numberOfJumps = 0;
            falling = false;
            jumping = false;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
        }
    }

    /* This is used when the hero picks up a powerup.
     *  It is publically callable from the powerup script.
     * Returns true if powerup accepted. False if not.
     */
    public bool PowerUp(string power)
    {
        if (power == "Spike")
        {
            var shield = transform.Find("SpikeShield").gameObject;
            shield.GetComponent<SpikeShieldScript>().PickUp();
            return true;
        }
        return false;
    }

    void Fall()
    {
        maxFallSpeed = -40;
        if (rigidbody2D.velocity.y < maxFallSpeed)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, maxFallSpeed);
        }
        else
            rigidbody2D.AddForce(new Vector2(0, -50f));
    }
	void StopCharge()
	{

		this.gameObject.GetComponentInChildren<HeroPowers>().HeroStartCharge =false;
	}
}
