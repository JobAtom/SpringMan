using UnityEngine;
using System.Collections;

public class HRSEnergyBar : MonoBehaviour {

	private float barDisplay = 0;
	private Vector2 pos = new Vector2(20,200);
	private Vector2 size = new Vector2(20,250);
	private HeatResistantSuit heatSuit;
	
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	
	// Use this for initialization
	void Start () {
		heatSuit = GameObject.Find ("HeatResistantSuit").GetComponent<HeatResistantSuit>();
	}
	
	void OnGUI()
	{
		// draw the background:
		GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
			GUI.Box (new Rect (0,0, size.x, size.y),progressBarFull);
			
			// draw the filled-in part:
			GUI.BeginGroup (new Rect (0, 0, size.x, size.y * barDisplay));
				GUI.Box (new Rect (0,0, size.x, size.y), progressBarEmpty);
			GUI.EndGroup ();
		
		GUI.EndGroup ();
	}
	
	void Update()
	{	
		float temp = heatSuit.currentTime / heatSuit.maxTime;	
		barDisplay = 1.0f - temp;
	}
}
