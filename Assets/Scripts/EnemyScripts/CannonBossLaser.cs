using UnityEngine;
using System.Collections;

public class CannonBossLaser : MonoBehaviour 
{
	//Based on wanted selection
	public float laserCooldownTime;
	public float laserChargeTime;
	public float laserShootTime;
	public float laserChargeScaleSize;
	public float laserBeamScaleSize;

	public int step;

	//Reference to needed game objects
	private GameObject bossBody;
	private GameObject playerBody;
	private GameObject laserChargeBall;
	private GameObject bossLaser;

	//Bools
	public bool playerInRange;
	public bool laserOnCooldown;
	public bool laserCharging;

	//Values inside

	//outside references
	public bool PlayerInRange
	{
		get {	return playerInRange;	}
	}

	public int Step
	{
		get {	return step;			}
	}

	// Use this for initialization
	void Start () 
	{
		bossBody = gameObject;
		playerBody = GameObject.FindGameObjectWithTag("Player");
		laserChargeBall = transform.FindChild("Charge").gameObject;
		bossLaser = transform.FindChild("Blast").gameObject;
		bossLaser.transform.localScale = new Vector3(0, bossLaser.transform.localScale.y, bossLaser.transform.localScale.z);
		laserOnCooldown = false;
		playerInRange = false;
		step = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(step == 0 && playerInRange)
			step = 1;
		if(step == 1 && !laserOnCooldown)
		{
			laserChargeBall.transform.localScale = Vector3.Lerp(laserChargeBall.transform.localScale, new Vector3(laserChargeScaleSize,laserChargeScaleSize,laserChargeScaleSize), Time.deltaTime);
			StartCoroutine("laserCharge");
		}
		if(step == 2)
		{
			StartCoroutine("laserFire");
			step = 3;
		}
		if(step == 3)
		{
			laserChargeBall.transform.localScale = Vector3.Lerp(laserChargeBall.transform.localScale, new Vector3(0,0,0), Time.deltaTime/3);
			bossLaser.transform.localScale = Vector3.Lerp(bossLaser.transform.localScale, new Vector3(laserBeamScaleSize, bossLaser.transform.localScale.y, bossLaser.transform.localScale.z), Time.deltaTime*6);
//			bossLaser.SetActive(true);
		}
		if(step == 4)
		{
			laserChargeBall.transform.localScale = new Vector3(0,0,0);
			bossLaser.transform.localScale = Vector3.Lerp(bossLaser.transform.localScale, new Vector3(0, bossLaser.transform.localScale.y, bossLaser.transform.localScale.z), Time.deltaTime*10);
//			bossLaser.SetActive(false);
			StartCoroutine("laserCooldown");
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag.Equals("Player"))
			playerInRange = true;
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag.Equals("Player"))
			playerInRange = false;
	}

	IEnumerator laserCharge()
	{
		yield return new WaitForSeconds(laserChargeTime);
		if(step == 1)
			step = 2;
	}

	IEnumerator laserFire()
	{
		yield return new WaitForSeconds(laserShootTime);
		if(step == 3)
			step = 4;
	}

	IEnumerator laserCooldown()
	{
		yield return new WaitForSeconds(laserCooldownTime);
		if(step == 4)
			step = 0;
	}
}
