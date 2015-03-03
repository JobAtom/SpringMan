using UnityEngine;
using System.Collections;

public class CannonBossLaser : MonoBehaviour 
{
	//Based on wanted selection
	public float laserCooldownTime;
	public float laserChargeTime;
	public float laserShootTime;
	public float laserChargeScaleSize;

	//Reference to needed game objects
	private GameObject bossBody;
	private GameObject playerBody;
	private GameObject laserChargeBall;
	private GameObject bossLaser;

	//Bools
	private bool playerInRange;
	private bool laserOnCooldown;
	private bool laserFullCharge;
	private bool laserFiring;
	private bool laserCharging;
	private bool fireOnce;
	//Values inside

	public bool LaserFiring
	{
		get {	return laserFiring; 	}
	}

	public bool PlayerInRange
	{
		get {	return playerInRange;	}
	}

	// Use this for initialization
	void Start () 
	{
		bossBody = gameObject;
		playerBody = GameObject.FindGameObjectWithTag("Player");
		laserChargeBall = transform.FindChild("Charge").gameObject;
		bossLaser = transform.FindChild("Blast").gameObject;
		bossLaser.SetActive(false);
		laserOnCooldown = false;
		playerInRange = false;
		laserFullCharge = false;
		laserCharging = false;
		laserFiring = false;
		fireOnce = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!fireOnce && playerInRange)
			fireOnce = true;

		if(fireOnce && !laserOnCooldown)
		{
			fireLaser ();
			bossLaser.SetActive(laserFiring);
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

	private void fireLaser()
	{
		if(!laserFullCharge && !laserFiring)
		{
			laserChargeBall.transform.localScale = Vector3.Lerp(laserChargeBall.transform.localScale, new Vector3(laserChargeScaleSize,laserChargeScaleSize,laserChargeScaleSize), Time.deltaTime/2);
			StartCoroutine("laserCharge");
		}

		if(laserFullCharge && !laserFiring)
			StartCoroutine("laserFire");

		if(laserFiring && !laserFullCharge)
		{
			laserChargeBall.transform.localScale = new Vector3(0,0,0);
			StartCoroutine("laserCooldown");
		}
	}

	IEnumerator laserCharge()
	{
		if(!laserFullCharge)
		{
			yield return new WaitForSeconds(laserChargeTime);
			laserFullCharge = true;
		}
	}

	IEnumerator laserFire()
	{
		laserFiring = true;
		laserFullCharge = false;
		yield return new WaitForSeconds(laserShootTime);
		laserFiring = false;
	}

	IEnumerator laserCooldown()
	{
		fireOnce = false;
		laserOnCooldown = true;
		yield return new WaitForSeconds(laserCooldownTime);
		laserOnCooldown = false;
	}
}
