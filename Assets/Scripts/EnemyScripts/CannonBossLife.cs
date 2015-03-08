using UnityEngine;
using System.Collections;

public class CannonBossLife : MonoBehaviour 
{
	public int bossLifeNodes;
	public CannonBoss bossLink;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(bossLifeNodes <= 0)
		{
			Debug.Log("Boss Destroyed.");

			//Play destruction of boss life nodes
			Destroy(GameObject.FindGameObjectWithTag ("CannonBossLifeNodes").transform.root.gameObject);

			//boss drops from the rail and explodes
			Destroy(GameObject.FindGameObjectWithTag("Boss"));
		}
	}

	IEnumerator WaitTimes(float time)
	{
		yield return WaitForSeconds(time);
	}
}
