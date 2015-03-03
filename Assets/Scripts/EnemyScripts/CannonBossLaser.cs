﻿using UnityEngine;
using System.Collections;

public class CannonBossLaser : MonoBehaviour 
{
	//Based on wanted selection
	public float laserCooldownTime;
	public float laserChargeTime;
	public float laserShootTime;
	public float laserChargeScaleSize;

	public int step;

	//Reference to needed game objects
	private GameObject bossBody;
	private GameObject playerBody;
	private GameObject laserChargeBall;
	private GameObject bossLaser;

	//Bools
	public bool playerInRange;
	public bool laserOnCooldown;
	public bool laserFullCharge;
	public bool laserFiring;
	public bool laserCharging;
	public bool fireOnce;
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
		fireOnce = false;
		step = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(step == 0 && playerInRange)
			step = 1;
		if(step == 1 && !laserOnCooldown)
		{
			laserChargeBall.transform.localScale = Vector3.Lerp(laserChargeBall.transform.localScale, new Vector3(laserChargeScaleSize,laserChargeScaleSize,laserChargeScaleSize), Time.deltaTime/2);
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
			bossLaser.SetActive(true);
		}
		if(step == 4)
		{
			laserChargeBall.transform.localScale = new Vector3(0,0,0);
			bossLaser.SetActive(false);
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
