﻿using UnityEngine;
using System.Collections;

public class HeatResistantSuit : MonoBehaviour 
{
	public float maxTime;
	public float currentTime;

	void Start () 
	{
		PutOnSuit();
		currentTime = maxTime;
		InvokeRepeating("decreaseTimer",1,1.25f);
	}
	
	void PutOnSuit(){
		HeroController player = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroController>();
		player.suitOn = true;
	}

	public void changeTime(float time)
	{
		currentTime += time;
	}

	void outOfTime()
	{
		VitalsScript.CurrentHealth = 0;
	}

	void decreaseTimer()
	{
		if (currentTime <= 0) {
			CancelInvoke ("decreaseTimer");
			outOfTime ();
		} 
		else {
			currentTime--;
			//Debug.Log (currentTime);
		}
	}
}
