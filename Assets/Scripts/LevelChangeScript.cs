using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelChangeScript : MonoBehaviour {

    public static int currentLevel;
	public static List<string> levels;
	// Use this for initialization
	void Start () 
	{
		levels = new List<string>(){"Level_1-1", "Level_1-2", "Level_1-3", "Level_1-4","Level_1-5","Level_1-6","Level_1-7","Level_3-1","Level_3-2","Level_3-3"};
	}

    void OnCollisionEnter2D(Collision2D other)
    {
		if (Application.loadedLevelName == "MainMenu") 
		{
			Application.LoadLevel (1);
			return;
		}
        if (other.collider.tag == ("Player") && !HeroController.GameOver)
        {
            LoadShop();
        }
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && !HeroController.GameOver)
		{
           //Instantiate();
			if (Application.loadedLevelName != "MainMenu") 
            	 GameObject.Find("Camera").GetComponent<camerafollowing>().StopTrack();
		}
	}

	public static void RestartLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

    public static void LoadShop()
    {
        currentLevel = Application.loadedLevel;
        Application.LoadLevel("Level_Shop");
    }

    public static void NextLevel()
    {

        if (currentLevel < levels.Count)
        {
            Application.LoadLevel(currentLevel + 1);
			CheckPoint.CheckPointOne = false;
            CheckPoint.triggered = false;
        }

		if (currentLevel > 3)
			Meteor.fallSpeed = .1f;
		else
			Meteor.fallSpeed = .25f;
    }
}
