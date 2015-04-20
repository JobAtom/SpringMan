using UnityEngine;
using System.Collections;

public class ProduceHealth : MonoBehaviour {
	public GameObject[] heal;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (HeroController.RestartOrNot) 
		{
			foreach (GameObject l in heal)
			{
				if(l!=null)
					l.SetActive (true);
			}

		}
		else
			foreach (GameObject l in heal)
			{
				
				l.SetActive (false);
			}
	
	}
}
