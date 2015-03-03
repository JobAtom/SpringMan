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
		if(object.ReferenceEquals(bossLink,null))
			bossLink = GetComponent<CannonBoss>();
		if(GameObject.FindGameObjectsWithTag("CannonBossLifeNodes").Length == 0)
			bossLink.setAlive(false);
	}
}
