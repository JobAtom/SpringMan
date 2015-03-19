using UnityEngine;
using System.Collections;

public class TutorialLevel : MonoBehaviour {
	private bool ShowChargeSkillInfo=false;
	private bool ShowDrillSkillInfo=false;
	private bool ShowBarrierSkillInfo=false;
	private bool ShowKillEnemyInfo=false;
	private bool ShowChipsInfo=false;
	private GameObject meteor;
	private bool barriercalled;
	public GameObject wall;

	// Use this for initialization
	void Start () {
		meteor = GameObject.FindGameObjectWithTag ("Meteor");
		barriercalled=false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (meteor.transform.position.y < -25f&&barriercalled) 
		{
			meteor.GetComponent<Meteor >().enabled=false;
			Destroy (wall);
			//HeroPowers .BarrierSkill =false;
		}
		if (GameObject.FindGameObjectWithTag ("Barrier"))
						barriercalled = true;

		if (barriercalled)
						HeroPowers.BarrierSkill = false;
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "EnemyKill") 
		{
			ShowKillEnemyInfo =true;
		}
		if (other.gameObject.name == "ChargeSkill") 
		{
			ShowChargeSkillInfo =true;
		}
		if (other.name == "DrillSkill") 
		{
			ShowDrillSkillInfo =true;
		}
		if (other.name == "BarrierSkill") 
		{
			ShowBarrierSkillInfo =true;
			meteor.GetComponent<Meteor >().enabled=true;
			HeroPowers .BarrierSkill =true;
		}
		if (other.name == "EatChips") 
		{
			ShowChipsInfo=true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == "EnemyKill") 
		{
			ShowKillEnemyInfo =false;
		}
		if (other.gameObject.name == "ChargeSkill") 
		{
			ShowChargeSkillInfo =false ;
		}
		if (other.name == "DrillSkill") 
		{
			ShowDrillSkillInfo =false ;
		}
		if (other.name == "BarrierSkill") 
		{
			ShowBarrierSkillInfo =false ;
			HeroPowers.BarrierSkill =false;
		}
		if (other.name == "EatChips") 
		{
			ShowChipsInfo=false;
		}
	}
	void OnGUI()
	{
		Shop.BeginUIResizing ();
		if (ShowKillEnemyInfo) 
		{
			GUI.skin.label .fontSize = 32;
			GUI.BeginGroup (new Rect (1920 / 2 -200, 1080 / 2-300 , 500, 200));
			GUI.Box (new Rect (0,0,500,200), "");
			
			GUI.Label(new Rect(50, 50, 400, 150), "JUMP ON ENEMY'S HEAD TO KILL IT");
			GUI.EndGroup ();
		}
		if (ShowChargeSkillInfo) 
		{
			GUI.skin.label .fontSize = 32;
			GUI.BeginGroup (new Rect (1920 / 2 -200, 1080 / 2-300 , 500, 200));
			GUI.Box (new Rect (0,0,500,200), "");
			GUI.Label(new Rect(20, 20, 400, 150), "PRESS 'ALT' TO USE CHARGE SKILL TO KILL ENEMY");
			GUI.EndGroup ();
		}
		if (ShowDrillSkillInfo) 
		{

			GUI.skin.label .fontSize = 32;
			GUI.BeginGroup (new Rect (1920 / 2 -200, 1080 / 2-300 , 500, 200));
			GUI.Box (new Rect (0,0,500,200), "");
			GUI.Label(new Rect(20, 20, 400, 150), "PRESS 'SHIFT' TO USE DRILL SKILL TO DRILL THROUGH PLATFORMS");
			GUI.EndGroup ();
		}
		if (ShowChipsInfo) 
		{
			GUI.skin.label .fontSize = 32;
			GUI.BeginGroup (new Rect (1920 / 2 -200, 1080 / 2-300 , 500, 200));
			GUI.Box (new Rect (0,0,500,200), "");
			GUI.Label(new Rect(20, 20, 400, 150), "EAT EACH MEMORY CHIP WILL GAIN 1MB EAT THEM ALL U WILL GET BONUS");
			GUI.EndGroup ();
		}
		if (ShowBarrierSkillInfo)
		{
			GUI.skin.label .fontSize = 32;
			GUI.BeginGroup (new Rect (1920 / 2 -200, 1080 / 2-300 , 500, 200));
			GUI.Box (new Rect (0,0,500,200), "");
			GUI.Label(new Rect(20, 20, 400, 150), "PRESS 'CTRL' USE BARRIER WHICH CAN STOP METEOR FOR A WHILE");
			GUI.EndGroup ();
		}
		Shop.EndUIResizing ();
	}
}
