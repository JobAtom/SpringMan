
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public List<Color> primaryColors;
	public List<Color> secondaryColors;
	public List <Texture2D> skillsTextures;
	public static float Volume = .3f;
    public static bool Hints = true;
	private Shop s;
	private Hospital H;
	public AudioSource ButtonSound;

	public bool IsLevel;
	private bool IsOpen = false;

	private bool hasUpdatedGui = false;
	private int currentColor;

    bool chapterSelect = false;
	bool settings = false;
	bool confirmQuit = false;
    float native_width = 1920;
    float native_height = 1080;
    public static float gameSpeed = 1.25f;
	private float t=0;

	void Start () {
		if(Application.loadedLevelName =="Level_Shop")
			s = GameObject.Find ("Shop").GetComponent<Shop> ();
		if (Application.loadedLevelName == "Level_Hospital")
			H = GameObject.Find ("Shop").GetComponent<Hospital > ();
		AudioListener.volume = .3f;
		MenuScript.Volume = AudioListener.volume;
		if (!IsLevel)
			IsOpen = true;
        Time.timeScale = gameSpeed;
	}
    void OnGUI(){
		Shop.BeginUIResizing ();
		if (!hasUpdatedGui) {
			ColoredGUISkin.Instance.UpdateGuiColors(primaryColors[0], secondaryColors[0]);
			hasUpdatedGui = true;
		}
		GUI.skin = ColoredGUISkin.Skin;
		GUI.skin.button.fontSize = 64;
		GUI.skin.label .fontSize = 64;
        float rx = 1920 / native_width;
        float ry = 1080 / native_height;
    //    GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));
		if (!IsLevel)
			MainMenu();
		else
			GameMenu();
		Shop.EndUIResizing ();

    } 

	private void  MainMenu()
	{
		int boxHeight, boxWidth;
		boxWidth = 1000;
        
		if (chapterSelect)
		{
			boxHeight = 600;
			GUI.BeginGroup (new Rect (1920 / 2 - 500, 1080 / 2 - 150, 1000, boxHeight));
			GUI.Box (new Rect (0,0,1000,boxHeight), "");
			if (GUI.Button(new Rect(35, 30, 250, 90), "BACK"))
			{
				ButtonSound.Play();

				chapterSelect = false;
            }
			if (GUI.Button(new Rect(100, 180, 400, 90), "LEVEL 1-1"))
			{
				ButtonSound.Play();
				System.Threading .Thread.Sleep (300);
				Application.LoadLevel(1);
			}
			if (GUI.Button(new Rect(100, 330, 400, 90), "LEVEL 1-2"))
			{
				ButtonSound.Play();
				System.Threading .Thread.Sleep (300);
				Application.LoadLevel(2);
			}
			if (GUI.Button(new Rect(100, 480, 400, 90), "LEVEL 1-3"))
			{
				ButtonSound.Play();
				System.Threading .Thread.Sleep (300);
				Application.LoadLevel(3);
			}
            if (GUI.Button(new Rect(500, 180, 400, 90), "LEVEL 2-1"))
            {
                ButtonSound.Play();
                System.Threading .Thread.Sleep (300);
                Application.LoadLevel(4);
            }
            if (GUI.Button(new Rect(500, 330, 400, 90), "LEVEL 2-2"))
            {
                ButtonSound.Play();
                System.Threading .Thread.Sleep (300);
                Application.LoadLevel(5);
            }
            if (GUI.Button(new Rect(500, 480, 400, 90), "LEVEL 2-3"))
            {
                ButtonSound.Play();
                System.Threading .Thread.Sleep (300);
                Application.LoadLevel(6);
            }

		}
		else if (settings)
		{
			SettingsMenu();
        }
		else if (confirmQuit)
		{
			GUI.skin.label .fontSize = 64;
			boxHeight = 300;
			GUI.BeginGroup (new Rect (1920 / 2 - 500, 1080 / 2 - 150, boxWidth, boxHeight));
			GUI.Box (new Rect (0,0,boxWidth,boxHeight), "");

			GUI.Label(new Rect(50, 50, 800, 200), "ARE YOU SURE YOU WANT TO QUIT?");
			
			if (GUI.Button(new Rect(200, boxHeight - 100, 250, 90), "YES"))
			{
				ButtonSound.Play();
				System.Threading .Thread.Sleep (300);
				Application.Quit();
			}
			if (GUI.Button(new Rect(500, boxHeight - 100, 250, 90), "NO"))
			{
				ButtonSound.Play();
				confirmQuit = false;
			}
		}
		else
		{

			GUI.Label(new Rect(25, 25, 600, 200), "Spring Man: \nA Robot's Life");
			boxHeight = 600;
			GUI.BeginGroup (new Rect (1920 / 2 - 500, 1080 / 2 - 150, 1000, boxHeight));
			GUI.Box (new Rect (0,0,1000,boxHeight), "");
			if (GUI.Button(new Rect(100, 30, 800, 90), "PLAY"))
			{

				ButtonSound.Play();
				System.Threading .Thread.Sleep (300);
				CheckPoint.CheckPointOne =false;
				CheckPoint.triggered =false;
				Application.LoadLevel(1);

			}
			if (GUI.Button(new Rect(100, 180, 800, 90), "CHAPTER SELECT"))
			{
				ButtonSound.Play();
				chapterSelect = true;
			}
			if (GUI.Button(new Rect(100, 330,800, 90), "SETTINGS"))
			{
				ButtonSound.Play();
				settings = true;
			}
			if (GUI.Button(new Rect(100, 480, 800, 90), "QUIT GAME"))
			{
				ButtonSound.Play();
			

					confirmQuit = true;
			}
		}
		GUI.EndGroup ();
	}

	private void GameMenu()
	{
		if (IsOpen)
		{
			if(Application.loadedLevelName =="Level_Shop")
			{

				s.enabled=false;
				s.PowerUp =false;
				s.SkillUp =false;
			}
			if(Application.loadedLevelName=="Level_Hospital")
			{
				H .enabled=false;
				//GameObject.Find ("EntireUI").gameObject .SetActive (false);
			}
			Time.timeScale = 0;
			int boxHeight, boxWidth;
			boxWidth =1000;
			if (settings)
			{
				SettingsMenu();
			}
			else if (confirmQuit)
			{
				boxHeight = 300;
				GUI.BeginGroup (new Rect (1920 / 2 - 500, 1080 / 2 - 150, boxWidth, boxHeight));
				GUI.Box (new Rect (0,0,boxWidth,boxHeight), "");
				GUI.Label(new Rect(50, 50,800, 200), "ARE YOU SURE YOU WANT TO QUIT?");

				if (GUI.Button(new Rect(200, boxHeight - 100, 250, 90), "YES"))
				{
					ButtonSound.Play();
					System.Threading .Thread.Sleep (300);

					Application.LoadLevel(0);
				}
				if (GUI.Button(new Rect(500, boxHeight - 100, 250, 90), "NO"))
				{
					ButtonSound.Play();

						confirmQuit = false;
				}
			}
			else
			{
				boxHeight = 600;
				GUI.BeginGroup (new Rect (1920 / 2 - 500,1080/ 2 - 150, 1000, boxHeight));
				GUI.Box (new Rect (0,0,1000,boxHeight), "");
				if (GUI.Button(new Rect(100, 55, 800, 90), "RESUME"))
				{
					ButtonSound.Play();
					IsOpen = false;
                    Time.timeScale = gameSpeed;
					if(Application.loadedLevelName =="Level_Shop")
					{
						s.enabled=true;
						s.PowerUp=true;
						//s.SkillUp =true;
					}
				}
				if (GUI.Button(new Rect(100, 255, 800,90), "SETTINGS"))
				{
					ButtonSound.Play();
					settings = true;
				}
				if (GUI.Button(new Rect(100,455, 800, 90), "QUIT TO MAIN MENU"))
				{
					ButtonSound.Play();

						confirmQuit = true;
				}
			}
			GUI.EndGroup ();
		}
		else
		{
			if (GUI.Button(new Rect(20-Shop.offset.x/Shop.guiScaleFactor   , 5-Shop.offset.y/Shop.guiScaleFactor  , 250, 90), "MENU"))
			{
				ButtonSound.Play();
				IsOpen = true;
			}
		}
	}

	private void SettingsMenu()
	{
		int boxHeight, boxWidth;
		if (!IsLevel)
			boxHeight = 600;
		else
			boxHeight = 600;
		boxWidth = 1000;
		GUI.BeginGroup (new Rect (1920 / 2 - 500, 1080 / 2 - 150, boxWidth, boxHeight));
		GUI.Box (new Rect (0, 0, boxWidth, boxHeight), "");
		if (GUI.Button(new Rect(35, 35, 250, 90), "BACK"))
		{
			ButtonSound.Play();
			settings = false;
		}
		AudioListener.volume = MenuScript.Volume;
		GUI.Label(new Rect(100, 260, 250, 90), "VOLUME: ");
		MenuScript.Volume = GUI.HorizontalSlider(new Rect (boxWidth - 400, 300, 250, 60), MenuScript.Volume, 0.0f, 1.0f);
    }


}

