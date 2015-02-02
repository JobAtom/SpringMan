using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Shop : MonoBehaviour
{
    
	private string currentword;
    public List<Color> primaryColors;
    public List<Color> secondaryColors;
    public List <Texture2D> skillsTextures;
	public static Vector2 NativeResolution  = new Vector2(1920, 1080);

    private bool hasUpdatedGui = false;
  
    public bool PowerUp;
    public bool SkillUp;
    private int maxHP = 7;
    private int maxEN = 7;
	private GUIText scorecolor;
	private int ColorRepeat;
	//public static bool barrierSelected=false ;
	private static bool healthlv1Selected=false ;
	private static bool energylv1Selected=false ;
	private static bool healthlv2Selected = false;
	private static bool energylv2Selected = false;
	private static bool healthlv3Selected=false;
	private static bool energylv3Selected = false;
	private static bool healthlv4Selected = false;
	private static bool energylv4Selected = false;
	private static bool barrierlv1Selected = false;
	private static bool barrierlv2Selected = false;
	private static bool barrierlv3Selected = false;
	private static bool barrierlv4Selected = false;
	private static bool chargeSelected = false;
	private int buttonHeight=40;


	private static  bool sendHealthlv1=false;
	private static bool sendEnergylv1=false;
	private static bool sendHealthlv2 = false;
	private static bool sendEnergylv2 = false;
	private static bool sendHealthlv3 = false;
	private static bool sendEnergylv3 = false;
	private static bool sendHealthlv4 = false;
	private static bool sendEnergylv4 = false; 
	//public static bool sendBarrier=false;
	private static bool sendBarrierlv1 = false;
	private static bool sendBarrierlv2=false;
	private static bool sendBarrierlv3 = false; 
	private static bool sendBarrierlv4 = false;
	private static bool sendCharge = false;
	private int scoreCost=0;
	private bool sendSuccess=false;
	private string word;
	public AudioSource ButtonSound;
	public AudioSource TypeSound;
	public static float guiScaleFactor = -1.0f;
	public static Vector3 offset = Vector3.zero;
	public static bool _didResizeUI=false;
	static List<Matrix4x4> stack = new List<Matrix4x4> ();
	public Texture2D shopBackground;

    // Use this for initialization
    void Start()
    {

        //Speed.SetActive (true);
		//Score.memory = 110;
		//Score.score = 10;
		ColorRepeat = 3;
        PowerUp = true;
        SkillUp = false;
		scorecolor = GameObject.Find ("Score").GetComponent<GUIText> ();


       
        //GameObject.Find ("Speed").GetComponent<Transform> ().position = (new Vector2 ((Screen.width / 2 - 100)/100, (Screen.height / 3 - 30)/100));
	
		
	
    }
	
    // Update is called once per frame

    void OnGUI()
    {
		BeginUIResizing();

        if (!hasUpdatedGui)
        {
            ColoredGUISkin.Instance.UpdateGuiColors(primaryColors[0], secondaryColors[0]);
            hasUpdatedGui = true;
        }

	
        GUI.skin = ColoredGUISkin.Skin;
		GUI.skin.button.fontSize=64;
		GUI.depth = 10;
		GUI.DrawTexture (new Rect (-50, 0, 2100, 1500), shopBackground);
		GUI.Label (new Rect (1920 - 600, 100, 600, 700), "SCORE: " + Score.score + "    \r" + "\nMEMORY: " + Score.memory + " MB");
			

		//GUI.enabled = false;
		GUI.BeginGroup(new Rect(1920 /9-50, 1080/ 2 - 245,800, 1000));

		GUI.Box(new Rect(0, 0, 600, 330 ), "");

			
		GUI.skin.label.fontSize = 64;
		if (currentword!=null ) 
		{

			GUI.Label (new Rect (35, 35, 600-35 , 300), currentword);
			if(currentword.IndexOf ("\r")==currentword.Length-1)
			{

				if(GUI.Button (new Rect(130,240,220,75),"SEND"))
				{
					ButtonSound .Play();


					if(Score.memory-scoreCost>=0)
					{
						sendSuccess=true;
						Score.memory-=scoreCost;
						scoreCost =0;
						currentword=null;
					}
					else
						NoScore();
					if(healthlv1Selected&&!sendHealthlv1)
					{
						
						
						
						if(sendSuccess )
						{
							sendHealthlv1=true;
							VitalsScript.MaxHealth += 1;
						}
						
						
					}
					if(chargeSelected &&!sendCharge)
					{
						if(sendSuccess)
						{
							sendCharge=true;
						}
					}
					if(energylv1Selected&&!sendEnergylv1 )
					{
						if(sendSuccess)
						{
							sendEnergylv1=true;
							VitalsScript .MaxEnergy +=1;
						}
					}
					if(healthlv2Selected&&!sendHealthlv2)
					{
						if(sendSuccess)
						{
							VitalsScript.MaxHealth += 1;
							sendHealthlv2=true;
						}
						
					}
					if(energylv2Selected&&!sendEnergylv2)
					{
						if(sendSuccess)
						{
							sendEnergylv2 =true;
							VitalsScript .MaxEnergy +=1;
						}
					}
					if(healthlv3Selected &&!sendHealthlv3)
					{
						if(sendSuccess)
						{
							VitalsScript.MaxHealth += 1;
							sendHealthlv3=true;
						}
					}
					if(energylv3Selected &&!sendEnergylv3)
					{
						if(sendSuccess)
						{
							VitalsScript .MaxEnergy +=1;
							sendEnergylv3=true;
						}
					}
					if(healthlv4Selected &&!sendHealthlv4)
					{
						if(sendSuccess)
						{
							VitalsScript.MaxHealth += 1;
							sendHealthlv4=true;
						}
					}
					if(energylv4Selected&&!sendEnergylv4 )
					{
						if(sendSuccess)
						{
							VitalsScript .MaxEnergy +=1;
							sendEnergylv4=true;
						}
					}
					if(barrierlv1Selected&& !sendBarrierlv1)
					{
						if(sendSuccess)
						{
							sendBarrierlv1=true;
							Meteor.barrierTime++;
						}
					}
					if(barrierlv2Selected&& !sendBarrierlv2)
					{
						if(sendSuccess)
						{
							sendBarrierlv2=true;
							Meteor.barrierTime++;
						}
					}
					if(barrierlv3Selected&& !sendBarrierlv3)
					{
						if(sendSuccess)
						{
							sendBarrierlv3=true;
							Meteor.barrierTime++;
						}
					}
					if(barrierlv4Selected&& !sendBarrierlv4)
					{
						if(sendSuccess)
						{
							sendBarrierlv4=true;
							Meteor.barrierTime++;
						}
					}
					sendSuccess =false;
				

				}
				if(GUI.Button (new Rect(360,240,220,75),"CANCEL"))
				{
					ButtonSound .Play();
					currentword=null;
					if(healthlv1Selected&&!sendHealthlv1)
						healthlv1Selected =false;
					if(healthlv2Selected&&!sendHealthlv2)
						healthlv2Selected=false;
					if(healthlv3Selected&&!sendHealthlv3 )
						healthlv3Selected =false;
					if(healthlv4Selected&&!sendHealthlv4 )
						healthlv4Selected =false;
					if(energylv1Selected&&!sendEnergylv1)
						energylv1Selected =false;
					if(energylv2Selected&&!sendEnergylv2 )
						energylv2Selected =false;
					if(energylv3Selected&&!sendEnergylv3)
						energylv3Selected =false;
					if(energylv4Selected &&!sendEnergylv4)
						energylv4Selected =false;
					if(chargeSelected &&!sendCharge )
						chargeSelected =false;
					if(barrierlv1Selected &&!sendBarrierlv1 )
						barrierlv1Selected =false;
					if(barrierlv2Selected &&!sendBarrierlv2 )
						barrierlv2Selected =false;
					if(barrierlv3Selected &&!sendBarrierlv3 )
						barrierlv3Selected =false;
					if(barrierlv4Selected &&!sendBarrierlv4 )
						barrierlv4Selected =false;

				}
			}
		}	
		GUI.EndGroup();



        if (PowerUp)
        {
         
		
			GUI.Window (1,new Rect(1920 / 2+300 , 1080 / 2 - 250,600,415),DoMyWindow,"POWERS");
			GUI.skin.window.fontSize=64;
		}

        if (SkillUp)
        {
			GUI.Window (0,new Rect (1920 / 2+300, 1080 / 2 - 250,600,415),DoMyWindow ,"SKILLS");
			//Skillup things can be added here;

        }
		if (GUI.Button(new Rect(100 , 1080 - 200+offset.y/guiScaleFactor , 400 , 150), "POWERUP"))
        {
            PowerUp = true;
			ButtonSound .Play();
            SkillUp = false;
        }
		if (GUI.Button(new Rect(1920 / 3+100 , 1080 - 200+offset.y/guiScaleFactor , 400 , 150), "SKILLUP"))
        {
            PowerUp = false;
            SkillUp = true;
			ButtonSound .Play();
        }
		if (GUI.Button(new Rect(1920*2 / 3+100 , 1080 - 200+offset.y/guiScaleFactor,400 , 150), "CONTINUE"))
        {
			ButtonSound .Play();
			System.Threading .Thread.Sleep (300);
			VitalsScript .CurrentHealth =VitalsScript .MaxHealth ;
			VitalsScript.CurrentEnergy =0;
            LevelChangeScript.NextLevel();

        }

        
		EndUIResizing ();
		if (Score.score != 0) 
		{
			StartCoroutine(ScoreToMemory());
		}
    }
	IEnumerator  ScoreToMemory()
	{
		float time = 1f;
		while (Score.score!=0) 
		{
			Score.score--;
			Score.memory +=10;
			yield return new WaitForSeconds (time);
			
		}
		
	}

   

   

   
	void NoScore()
	{

		scorecolor.color = Color.red;

		InvokeRepeating ("ChangeColor", 0.1f,0.3f);

	}
	void ChangeColor()
	{
		if (ColorRepeat % 2 == 0)
						scorecolor .color = Color.white;
				else
						scorecolor .color = Color.red;

		if (ColorRepeat == 0) 
		{
			CancelInvoke ();
			ColorRepeat =4;
		}
		ColorRepeat--;
	}

	void DoMyWindow(int windowID)
	{
		GUI.skin.button.fontSize = 64;

		if (windowID == 0) 
		{
			if (sendCharge) 
			{
				GUI.enabled = false;
				GUI.Button (new Rect (10, 60, 580, 75), "CHARGE(LEARNED)");
				HeroPowers.ChargeSkill=true;
				GUI.enabled = true;
			}
			if(chargeSelected&&!sendCharge)
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,60,580,75),"CHARGE");
				GUI.enabled=true;
			}

			if (!chargeSelected )
			{	
				if (GUI.Button (new Rect (10, 60, 580, 75), "CHARGE") && currentword == null) 
				{
					StopAllCoroutines ();
					StartCoroutine (TypeWritter ("PRESS [ALT] TO USE CHARGE COST:10MB\n\r"));
					chargeSelected = true;
					scoreCost = 10;
					ButtonSound .Play();
				}
						
			}
		}
		if (windowID == 1) 
		{
			if (sendHealthlv4)
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10, 60, 580, 75),"HEALTH lvMAX");
				GUI.enabled=true;
			}
			if(sendEnergylv4)
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,140,580,75),"ENERGY lvMAX");
				GUI.enabled=true;
			}
			if(sendBarrierlv4)
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,220,580,75),"BARRIER lvMAX");
				GUI.enabled=true;
			}
			if(healthlv1Selected&&!sendHealthlv1 )
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,60,580,75),"HEALTH lv1");
				GUI.enabled=true;
			}
			if(healthlv2Selected &&!sendHealthlv2 )
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,60,580,75),"HEALTH lv2");
				GUI.enabled=true;
			}
			if(healthlv3Selected &&!sendHealthlv3 )
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,60,580,75),"HEALTH lv3");
				GUI.enabled=true;
			}
			if(healthlv4Selected &&!sendHealthlv4)
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,60,580,75),"HEALTH lv4");
				GUI.enabled=true;
			}
			if(energylv1Selected &&!sendEnergylv1 )
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,140,580,75),"ENERGY lv1");
				GUI.enabled=true;
			}
			if(energylv2Selected &&!sendEnergylv2 )
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,140,580,75),"ENERGY lv2");
				GUI.enabled=true;
			}
			if(energylv3Selected &&!sendEnergylv3)
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,140,580,75),"ENERGY lv3");
				GUI.enabled=true;
			}
			if(energylv4Selected &&!sendEnergylv4)
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,140,580,75),"ENERGY lv4");
				GUI.enabled=true;
			}
			if(barrierlv1Selected&&!sendBarrierlv1)
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,220,580,75),"BARRIER lv1");
				GUI.enabled=true;
			}
			if(barrierlv2Selected&&!sendBarrierlv2)
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,220,580,75),"BARRIER lv2");
				GUI.enabled=true;
			}
			if(barrierlv3Selected&&!sendBarrierlv3)
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,220,580,75),"BARRIER lv3");
				GUI.enabled=true;
			}if(barrierlv4Selected&&!sendBarrierlv4)
			{
				GUI.enabled=false;
				GUI.Button (new Rect(10,220,580,75),"BARRIER lv4");
				GUI.enabled=true;
			}


			if(!healthlv1Selected )
			{   
				if (GUI.Button (new Rect (10, 60, 580, 75), "HEALTH lv1")&&currentword==null)
				{

					StopAllCoroutines ();
					StartCoroutine (TypeWritter ("HEALTH lv1\nMAXIMUM HEALTH+1 COST:10MB\n\r"));
					healthlv1Selected=true;
					scoreCost=10;
					ButtonSound .Play();
				}

			}	
			if(!energylv1Selected  )
			{
				if(GUI.Button (new Rect(10, 140,580, 75),"ENERGY lv1")&&currentword==null)
				{

					StopAllCoroutines ();
					StartCoroutine (TypeWritter ("ENERGY lv1\nMAXIMUM ENERGY+1 COST:10MB\n\r"));
					energylv1Selected =true;
					scoreCost=10;
					ButtonSound .Play();
				}
			}
			if(!healthlv2Selected &&sendHealthlv1 )
			{
				if(GUI.Button (new Rect(10,60,580,75),"HEALTH lv2")&&currentword==null)
				{

					StopAllCoroutines ();
					StartCoroutine (TypeWritter ("HEALTH lv2\nMAXIMUM HEALTH+1 COST:20MB\n\r"));
					healthlv2Selected=true;
					scoreCost=20;
					ButtonSound .Play();
				}

			}
			if(!energylv2Selected&&sendEnergylv1)
			{
				if(GUI.Button (new Rect(10,140,580,75),"ENERGY lv2")&&currentword==null)
				{

					StopAllCoroutines ();
					StartCoroutine (TypeWritter ("ENERGY lv2\nMAXIMUM ENERGY+1 COST:20MB\n\r"));
					energylv2Selected=true;
					scoreCost=20;
					ButtonSound .Play();
				}
			}
			if(!healthlv3Selected &&sendHealthlv2)
			{
				if(GUI.Button (new Rect(10,60,580,75),"HEALTH lv3")&&currentword==null)
				{
					StopAllCoroutines ();
					StartCoroutine (TypeWritter ("HEALTH lv3\nMAXIMUM HEALTH+1 COST:30MB\n\r"));
					healthlv3Selected =true;
					scoreCost=30;
					ButtonSound .Play();
				}
			}
			if(!energylv3Selected &&sendEnergylv2)
			{
				if(GUI.Button (new Rect(10,140,580,75),"ENERGY lv3")&&currentword==null)
				{
					StopAllCoroutines ();
					StartCoroutine (TypeWritter ("ENERGY lv3\nMAXIMUM ENERGY+1 COST:30MB\n\r"));
					energylv3Selected =true;
					scoreCost=30;
					ButtonSound .Play();
				}
			}
			if(!healthlv4Selected&&sendHealthlv3)
			{
				if(GUI.Button (new Rect(10,60,580,75),"HEALTH lv4")&&currentword==null)
				{
					StopAllCoroutines ();
					StartCoroutine (TypeWritter("HEALTH lv4\nMAXIMUM HEALTH+1 COST:40MB\n\r"));
					healthlv4Selected =true;
					scoreCost=40;
					ButtonSound .Play();
				}
			}
			if(!energylv4Selected  &&sendEnergylv3)
			{

				if(GUI.Button (new Rect(10,140,580,75),"ENERGY lv4")&&currentword==null)
				{	

					StopAllCoroutines ();
					StartCoroutine (TypeWritter("ENERGY lv4\nMAXIMUM ENERGY+1 COST:40MB\n\r"));
					energylv4Selected =true;
					scoreCost=40;
					ButtonSound .Play();
				}
			}
			if(!barrierlv1Selected )
			{
				if(GUI.Button (new Rect(10, 220,580,75),"BARRIER lv1")&&currentword==null)
				{
					StopAllCoroutines ();
					StartCoroutine (TypeWritter("BARRIER lv1\nBARRLER HOLD TIME+2s COST:10MB\n\r"));
					barrierlv1Selected =true;
					scoreCost=10;
					ButtonSound .Play ();

				}
			}
			if(!barrierlv2Selected &&sendBarrierlv1)
			{
				if(GUI.Button (new Rect(10, 220,580,75),"BARRIER lv2")&&currentword==null)
				{
					StopAllCoroutines ();
					StartCoroutine (TypeWritter("BARRIER lv2\nBARRLER HOLD TIME+2s COST:20MB\n\r"));
					barrierlv2Selected =true;
					scoreCost=20;
					ButtonSound .Play ();
					
				}
			}
			if(!barrierlv3Selected &&sendBarrierlv2)
			{
				if(GUI.Button (new Rect(10, 220,580,75),"BARRIER lv3")&&currentword==null)
				{
					StopAllCoroutines ();
					StartCoroutine (TypeWritter("BARRIER lv3\nBARRLER HOLD TIME+2s COST:30MB\n\r"));
					barrierlv3Selected =true;
					scoreCost=30;
					ButtonSound .Play ();
					
				}
			}
			if(!barrierlv4Selected &&sendBarrierlv3)
			{
				if(GUI.Button (new Rect(10, 220,580,75),"BARRIER lv4")&&currentword==null)
				{
					StopAllCoroutines ();
					StartCoroutine (TypeWritter("BARRIER lv4\nBARRLER HOLD TIME+2s COST:40MB\n\r"));
					barrierlv4Selected =true;
					scoreCost=40;
					ButtonSound .Play ();
					
				}
			}

		}
	
	}

	IEnumerator  TypeWritter(string text)
	{

		currentword = "";
		float time=0.1f;
		TypeSound.Play ();
		foreach (var letter in text.ToCharArray ())
		{
			//TypeSound.Play();
			currentword +=letter;

			if(Input.GetMouseButton(0) )
			{
				time=0.01f;
			}				
			yield return new WaitForSeconds (time);
		}
		TypeSound .Stop ();
	}
	public static void BeginUIResizing()
	{
		Vector2 nativeSize = NativeResolution;
		
		_didResizeUI = true;
		
		stack.Add (GUI.matrix);
		Matrix4x4 m = new Matrix4x4();
		var w = (float)Screen.width;
		var h = (float)Screen.height;
		var aspect = w / h;
		offset = Vector3.zero;
		if(aspect < (nativeSize.x/nativeSize.y)) 
		{ 
			//screen is taller
			guiScaleFactor = (Screen.width/nativeSize.x);
			offset.y += (Screen.height-(nativeSize.y*guiScaleFactor))*0.5f;
		} 
		else 
		{ 
			// screen is wider
			guiScaleFactor = (Screen.height/nativeSize.y);
			offset.x += (Screen.width-(nativeSize.x*guiScaleFactor))*0.5f;

		}
		
		m.SetTRS(offset,Quaternion.identity,Vector3.one*guiScaleFactor);
		GUI.matrix *= m;	
	}
	public static void EndUIResizing()
	{
		GUI.matrix = stack[stack.Count - 1];
		stack.RemoveAt (stack.Count - 1);
		_didResizeUI = false;
	}



}
