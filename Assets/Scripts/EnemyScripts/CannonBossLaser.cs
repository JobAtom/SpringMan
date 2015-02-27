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

		if(fireOnce)
			fireLaser ();
//		else
//			Debug.Log("On Cooldown.");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
//		Debug.Log(other.tag);
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
//		Debug.Log("in fire laser");
//		Debug.Log("Laser not on cooldown");

		if(!laserFullCharge && !laserFiring)
		{
//			Debug.Log("In !laserFullCharge Loop");
			laserChargeBall.transform.localScale = Vector3.Lerp(laserChargeBall.transform.localScale, new Vector3(laserChargeScaleSize,laserChargeScaleSize,laserChargeScaleSize), Time.deltaTime/2);
			StartCoroutine("laserCharge");
		}

		if(laserFullCharge)
			StartCoroutine("laserFire");

		if(laserFiring)
		{
//			Debug.Log("I'mma firrin mah lazor");
			laserChargeBall.transform.localScale = new Vector3(0,0,0);
			laserOnCooldown = true;
			StartCoroutine("laserCooldown");
		}
	}

	IEnumerator laserCharge()
	{
//		Debug.Log("in laser charge");
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
		bossLaser.SetActive(true);
		yield return new WaitForSeconds(laserShootTime);
		bossLaser.SetActive(false);
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
