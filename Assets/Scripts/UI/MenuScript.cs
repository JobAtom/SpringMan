
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class MenuScript : MonoBehaviour {

	public List<Color> primaryColors;
	public List<Color> secondaryColors;
	public List <Texture2D> skillsTextures;
	public static float Volume = .3f;
    public static bool Hints = true;
	private HeroController player;
	private Shop s;
	private Hospital H;
	public AudioSource ButtonSound;
	private camerafollowing cameracontrol;

	public bool IsLevel;
	private bool IsOpen = false;

	private bool hasUpdatedGui = false;
	private int currentColor;

   // bool chapterSelect = false;
	bool settings = false;
	bool confirmQuit = false;
    float native_width = 1920;
    float native_height = 1080;
    public static float gameSpeed = 1.25f;
	private float t=0;

	void Start () {
		if(Application.loadedLevelName!="Level_Shop")
			player = GameObject.FindGameObjectWithTag ("Player").GetComponent<HeroController> ();
		cameracontrol = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent <camerafollowing > ();
		if (player != null&&!IsLevel )
						player.enabled = false;
		if (!IsLevel && cameracontrol != null) 
		{
			cameracontrol.enabled=false;
		}
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
        
		/*if (chapterSelect)
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

		}*/
		 if (settings)
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
				Shop.healthlv1Selected =false;
				Shop.healthlv2Selected =false;
				Shop.healthlv3Selected =false;
				Shop.healthlv4Selected =false;
				Shop.sendHealthlv1 =false;
				Shop.sendHealthlv2 =false;
				Shop.sendHealthlv3 =false;
				Shop.sendHealthlv4 =false;
				Shop.energylv1Selected =false;
				Shop.energylv2Selected =false;
				Shop.energylv3Selected =false;
				Shop.energylv4Selected =false;
				Shop.sendEnergylv1 =false;
				Shop.sendEnergylv2 =false;
				Shop.sendEnergylv3 =false;
				Shop.sendEnergylv4 =false;
				Shop.barrierlv1Selected =false;
				Shop.barrierlv2Selected =false;
				Shop.barrierlv3Selected =false;
				Shop.barrierlv4Selected =false;
				Shop.sendBarrierlv1 =false;
				Shop.sendBarrierlv2 =false;
				Shop.sendBarrierlv3 =false;
				Shop.sendBarrierlv4 =false;
				Shop.drillSelected =false;
				Shop.sendDrill =false;
				Shop.chargeSelected =false;
				Shop.sendCharge =false;
				HeroPowers.ChargeSkill =false;
				HeroPowers.DrillSkill =false;
				Score.score =0;
				Score.memory =0;
				VitalsScript .MaxEnergy =3;
				VitalsScript .MaxHealth =3;
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
			if (GUI.Button(new Rect(100, 55, 800, 90), "NEW GAME"))
			{

				ButtonSound.Play();
				//System.Threading .Thread.Sleep (300);
				CheckPoint.CheckPointOne =false;
				CheckPoint.triggered =false;
				//Application.LoadLevel(1);

				cameracontrol .enabled=true;
				iTween.MoveTo (GameObject.FindGameObjectWithTag ("MainCamera"), iTween.Hash ("x",GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>().position.x,"y",GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>().position.y,"time",1.8));
				Invoke ("track",2f);
				IsLevel=true;
				IsOpen=false;
			}
			if (GUI.Button(new Rect(100, 188, 800, 90), "LOAD"))
			{
				ButtonSound.Play();

				Score.score =PlayerPrefs.GetInt ("Score");
				Score.memory=PlayerPrefs.GetInt ("MemoryChips");
				VitalsScript .MaxHealth=PlayerPrefs.GetInt ("MaxHealth");
				VitalsScript.MaxEnergy=PlayerPrefs.GetInt ("MaxEnergy");
				Shop.sendCharge=Convert.ToBoolean (PlayerPrefs.GetInt ("ChargeSkillSend"));
				Shop.sendDrill=Convert.ToBoolean (PlayerPrefs.GetInt ("DrillSkillSend"));
				Shop.sendHealthlv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv1Send"));
				Shop.sendHealthlv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv2Send"));
				Shop.sendHealthlv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv3Send"));
				Shop.sendHealthlv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("HealthLv4Send"));
				Shop.sendEnergylv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv1Send"));
				Shop.sendEnergylv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv2Send"));
				Shop.sendEnergylv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv3Send"));
				Shop.sendEnergylv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("EnergyLv4Send"));
				Shop.sendBarrierlv1 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv1Send"));
				Shop.sendBarrierlv2 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv2Send"));
				Shop.sendBarrierlv3 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv3Send"));
				Shop.sendBarrierlv4 =Convert.ToBoolean (PlayerPrefs.GetInt ("BarrierLv4Send"));
				Application.LoadLevel (PlayerPrefs.GetInt ("CurrentLevel"));

			}
			if (GUI.Button(new Rect(100,321 ,800, 90), "SETTINGS"))
			{
				ButtonSound.Play();
				settings = true;
			}
			if (GUI.Button(new Rect(100, 455, 800, 90), "QUIT GAME"))
			{
				ButtonSound.Play();
			

					confirmQuit = true;
			}
		}
		GUI.EndGroup ();
	}
	void track()
	{

		cameracontrol.trackX = true;
		cameracontrol.trackY = true;
		if (GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Transform> ().position.x == GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ().position.x) 
		{
			player.enabled = true;
			player.GetComponentInChildren <HeroPowers >().enabled=false;
		}
	}

	private void GameMenu()
	{
		GUI.Label (new Rect (1920 - 600, 100, 600, 700), "SCORE: " + Score.score + "    \r" + "\nMEMORY: " + Score.memory + " MB");
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
					Shop.healthlv1Selected =false;
					Shop.healthlv2Selected =false;
					Shop.healthlv3Selected =false;
					Shop.healthlv4Selected =false;
					Shop.sendHealthlv1 =false;
					Shop.sendHealthlv2 =false;
					Shop.sendHealthlv3 =false;
					Shop.sendHealthlv4 =false;
					Shop.energylv1Selected =false;
					Shop.energylv2Selected =false;
					Shop.energylv3Selected =false;
					Shop.energylv4Selected =false;
					Shop.sendEnergylv1 =false;
					Shop.sendEnergylv2 =false;
					Shop.sendEnergylv3 =false;
					Shop.sendEnergylv4 =false;
					Shop.barrierlv1Selected =false;
					Shop.barrierlv2Selected =false;
					Shop.barrierlv3Selected =false;
					Shop.barrierlv4Selected =false;
					Shop.sendBarrierlv1 =false;
					Shop.sendBarrierlv2 =false;
					Shop.sendBarrierlv3 =false;
					Shop.sendBarrierlv4 =false;
					Shop.drillSelected =false;
					Shop.sendDrill =false;
					Shop.chargeSelected =false;
					Shop.sendCharge =false;
					HeroPowers.ChargeSkill =false;
					HeroPowers.DrillSkill =false;
					Score.score =0;
					Score.memory =0;
					VitalsScript .MaxEnergy =3;
					VitalsScript .MaxHealth =3;
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
				if(Application.loadedLevelName!="Level_Shop")
				{
					if(GUI.Button(new Rect(100,188,800,90),"SAVE"))
			    	{
						ButtonSound.Play ();
						PlayerPrefs.SetInt ("CurrentLevel",Application.loadedLevel );
						PlayerPrefs.SetInt ("Score",Score.score );
						PlayerPrefs.SetInt ("MemoryChips",Score.memory );
						PlayerPrefs.SetInt ("MaxHealth",VitalsScript .MaxHealth);
						PlayerPrefs.SetInt ("MaxEnergy",VitalsScript .MaxEnergy);
						PlayerPrefs.SetInt ("ChargeSkillSend",Convert.ToInt32(Shop.sendCharge));
						PlayerPrefs.SetInt ("DrillSkillSend",Convert.ToInt32 (Shop.sendDrill));
						PlayerPrefs.SetInt ("HealthLv1Send",Convert.ToInt32 (Shop.sendHealthlv1 ));
						PlayerPrefs.SetInt ("HealthLv2Send",Convert.ToInt32 (Shop.sendHealthlv2 ));
						PlayerPrefs.SetInt ("HealthLv3Send",Convert.ToInt32 (Shop.sendHealthlv3 ));
						PlayerPrefs.SetInt ("HealthLv4Send",Convert.ToInt32 (Shop.sendHealthlv4 ));
						PlayerPrefs.SetInt ("EnergyLv1Send",Convert.ToInt32 (Shop.sendEnergylv1 ));
						PlayerPrefs.SetInt ("EnergyLv2Send",Convert.ToInt32 (Shop.sendEnergylv2 ));
						PlayerPrefs.SetInt ("EnergyLv3Send",Convert.ToInt32 (Shop.sendEnergylv3 ));
						PlayerPrefs.SetInt ("EnergyLv4Send",Convert.ToInt32 (Shop.sendEnergylv4 ));
						PlayerPrefs.SetInt ("BarrierLv1Send",Convert.ToInt32 (Shop.sendBarrierlv1 ));
						PlayerPrefs.SetInt ("BarrierLv2Send",Convert.ToInt32 (Shop.sendBarrierlv2 ));
						PlayerPrefs.SetInt ("BarrierLv3Send",Convert.ToInt32 (Shop.sendBarrierlv3 ));
						PlayerPrefs.SetInt ("BarrierLv4Send",Convert.ToInt32 (Shop.sendBarrierlv4 ));





					}
				}
				if(Application.loadedLevelName =="Level_Shop")
				{

						GUI.enabled=false;
						GUI.Button (new Rect(100,188,800,90),"SAVE");
						GUI.enabled=true;

				}
				if (GUI.Button(new Rect(100, 321, 800,90), "SETTINGS"))
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

