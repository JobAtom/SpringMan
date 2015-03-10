using UnityEngine;
using System.Collections;

public class SubMarineBoss : MonoBehaviour {
	public bool ShotPhase;
	public GameObject[] BossCannon;
	public GameObject StompZone;
	public bool ChargePhase;
	public bool SummonPhase;
	private bool BeginFight;
	public bool FaceRight;
	private int ChargeNum;
	private camerafollowing camera;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Camera").GetComponent<camerafollowing > ();
		ShotPhase = false;
		ChargePhase = false;
		SummonPhase = false;
		BeginFight = false;

	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (!camera.trackX && !camera.trackY)
						BeginFight = true;
		if (ShotPhase&&!ChargePhase&&!SummonPhase)
			Shot ();
		if(ChargePhase&&!ShotPhase&&!SummonPhase)
			Charge();
		if (SummonPhase&&!ShotPhase&&!ChargePhase)
			Summon ();
		if (BeginFight&&!ShotPhase&&!ChargePhase&&!SummonPhase)
						ShotPhase = true;
	
	}
	void Shot()
	{
		foreach(GameObject l in BossCannon)
		{
			l.SetActive (true);
		}
		StompZone .SetActive (true);

		ChargePhase = false;
		SummonPhase = false;
		Invoke ("Charge", 15f);
	}
	void Charge()
	{
		CancelInvoke ();
		ShotPhase = false;
		ChargePhase = true;
		SummonPhase = false;

		//Invoke ("Summon", 3f);
	}
	void Summon()
	{

		ChargePhase = false;
		ShotPhase = false;
		SummonPhase = true;
		//Invoke ("Shot", 3f);
	}
	void Flip()
	{
		FaceRight=!FaceRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
