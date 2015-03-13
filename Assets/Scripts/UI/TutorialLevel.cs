using UnityEngine;
using System.Collections;

public class TutorialLevel : MonoBehaviour {
	private bool ShowChargeSkillInfo=false;
	private bool ShowDrillSkillInfo=false;
	private bool ShowBarrierSkillInfo=false;
	private bool ShowKillEnemyInfo=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
		}
	}
	void OnGUI()
	{
		if (ShowKillEnemyInfo) 
		{
			GUI.skin.label .fontSize = 32;
			GUI.BeginGroup (new Rect (1920 / 2 - 700, 1080 / 2-500 , 500, 200));
			GUI.Box (new Rect (0,0,500,200), "");
			
			GUI.Label(new Rect(50, 50, 400, 150), "JUMP ON ENEMY'S HEAD TO KILL IT");
			GUI.EndGroup ();
		}
		if (ShowChargeSkillInfo) 
		{
			GUI.skin.label .fontSize = 32;
			GUI.BeginGroup (new Rect (1920 / 2 - 700, 1080 / 2-500 , 500, 200));
			GUI.Box (new Rect (0,0,500,200), "");
			GUI.Label(new Rect(20, 20, 400, 150), "PRESS 'ALT' TO USE CHARGE SKILL TO KILL ENEMY");
			GUI.EndGroup ();
		}
		if (ShowDrillSkillInfo) 
		{
			GUI.skin.label .fontSize = 32;
			GUI.BeginGroup (new Rect (1920 / 2 - 700, 1080 / 2-500 , 500, 200));
			GUI.Box (new Rect (0,0,500,200), "");
			GUI.Label(new Rect(20, 20, 400, 150), "PRESS 'SHIFT' TO USE DRILL SKILL TO DRILL THROUGH PLATFORMS");
			GUI.EndGroup ();
		}
		if (ShowBarrierSkillInfo) 
		{

		}
	}
}
