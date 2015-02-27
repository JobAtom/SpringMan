using UnityEngine;
using System.Collections;

public class CannonBoss : MonoBehaviour 
{
	//The set speeds
	public float moveSpeed = 1f;
	public float laserRechargeSpeed = 5f;
	public float laserAimTime = 1f;

	//The current speeds
	private float laserRechargeTimer;
	private bool laserOnCooldown;
	private bool laserAiming;

	//Reference to needed game objects
	private GameObject bossBody;
	private GameObject playerBody;

	private bool facingRight;
	private bool playerInRange;
	private Vector3 forwardDirection;
	// Use this for initialization
	void Start () 
	{
		bossBody = transform.gameObject;
		playerBody = GameObject.FindGameObjectWithTag("Player");
		facingRight = true;
		playerInRange = false;
		laserRechargeTimer = 0;
		laserOnCooldown = false;
		forwardDirection = Vector3.right;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//follow player
		Debug.Log("Tangent: " + Mathf.Atan(transform.position.y/playerBody.transform.position.x));
		//players position locally = our position + their position?
		float angle = Mathf.Atan2 ((playerBody.transform.position.y - transform.position.y), (playerBody.transform.position.x - transform.position.x)) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
//			Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,Mathf.Atan2((playerBody.transform.position.y - transform.position.y),(playerBody.transform.position.x + transform.position.x)) * Mathf.Rad2Deg), Time.deltaTime);
//			0,0, Mathf.Tan(transform.position.y/playerBody.transform.position.y));
	}

	void FixedUpdate()
	{
		//Foward movement
		RaycastHit2D wallCheck = Physics2D.Raycast(new Vector2(bossBody.transform.position.x, bossBody.transform.position.y), forwardDirection, 3, 1<<11);
		Debug.DrawRay(transform.position, forwardDirection*3);

		if(!wallCheck)
		{
			if (facingRight)
				transform.position = new Vector2 (transform.position.x + moveSpeed, transform.position.y);
			else if (!facingRight)
				transform.position = new Vector2 (transform.position.x - moveSpeed, transform.position.y);
		}

		if(wallCheck)
			Flip ();
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

		if(facingRight)
			forwardDirection = Vector3.right;
		else if(!facingRight)
			forwardDirection = Vector3.left;
	}



//	private void fireLaser()
//	{
//		if(!laserOnCooldown)
//		{
//			Debug.Log("Fire the laser");
//			Debug.Log("Aim");
//			StartCoroutine("laserFireProcess");
//			Debug.Log("Aim Complete");
//		}
//		else
//			StartCoroutine("laserRecharge");
//	}

//	IEnumerable laserFireProcess()
//	{
//		if(!laserOnCooldown)
//		{
//			yield return StartCoroutine(laserAim);
//		}
//		else
//			yield return WaitForSeconds(0);
//	}
//
//	IEnumerable laserAim()
//	{
//		yield return WaitForSeconds(laserAimTime);
//	}
//
//	IEnumerable laserRecharge()
//	{
//		if(laserOnCooldown)
//		{
//			yield return new WaitForSeconds(5);
//			laserOnCooldown = false;
//		}
//		else
//			laserOnCooldown = true;
//	}

//	IEnumerable laserRecharge()
//	{
//		if(laserOnCooldown)
//		{
//			if(laserRechargeTimer !=0)
//			{
//				laserRechargeTimer--;
//				yield return new WaitForSeconds(1);
//			}
//			else
//				laserOnCooldown = false;
//		}
//		else
//			laserOnCooldown = true;
//	}
}
