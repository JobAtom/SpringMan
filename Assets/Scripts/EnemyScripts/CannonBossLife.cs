using UnityEngine;
using System.Collections;

public class CannonBossLife : MonoBehaviour 
{
	public int bossLifeNodes;
	public int step;

	private bool stepLock;
	// Use this for initialization
	void Start () 
	{
		step = 0;
		stepLock = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(bossLifeNodes <= 0)
		{
			Debug.Log("Boss Destroyed.");

//			if(step == 0)
//			{
//				Debug.Log ("Play node explosion.");
//				addToStep(2);
//			}
//			else if(step == 1)
//			{
//				//Play destruction of boss life nodes
//				Destroy(GameObject.FindGameObjectWithTag ("CannonBossLifeNodes").transform.root.gameObject);
//				addToStep(2);
//			}
//			else if(step == 2)
//			{
//				//boss loses kinomatic
//				GameObject.FindGameObjectWithTag("Boss").rigidbody2D.isKinematic = false;
//				addToStep(2);
//
//			}
//			else if(step == 3)
//			{
//				Destroy(GameObject.FindGameObjectWithTag("Boss").gameObject);
//			}

			Destroy(GameObject.FindGameObjectWithTag ("CannonBossLifeNodes").transform.root.gameObject);
			GameObject.FindGameObjectWithTag("Boss").rigidbody2D.isKinematic = false;
		}
	}

	void addToStep(float waitTime)
	{
		StartCoroutine(wait(waitTime));
	}

	IEnumerator wait(float time)
	{
		yield return new WaitForSeconds(time);
		step++;
	}
}
