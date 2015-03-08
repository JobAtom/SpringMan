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
			Destroy(GameObject.FindGameObjectWithTag("Boss"));
			Destroy(GameObject.FindGameObjectWithTag ("CannonBossLifeNodes").transform.root.gameObject);
		}
	}
}
