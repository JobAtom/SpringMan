using UnityEngine;
using System.Collections;

public class SubmarineBossCharge : MonoBehaviour {
	private SubMarineBoss Boss;
	public bool FaceRight = true;
	private bool StartCharge;
	private float ChargeSpeed=1f;
	private float OriginalPositionX;
	private float OriginalPositionY;
	private GameObject player;
	private bool PerpareToCharge = false;
	private int ChargeNum=0;
	// Use this for initialization
	void Start () {
		Boss = this.gameObject.GetComponent<SubMarineBoss> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		OriginalPositionX = this.gameObject.transform.position.x;
		OriginalPositionY = this.gameObject.transform.position.y;
		StartCharge = false;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Boss.ChargePhase && !StartCharge && !PerpareToCharge) 
		{
			CancelInvoke ();
			PerpareCharge ();


		}
		if (!PerpareToCharge)
						Boss.HeroChargePoint .SetActive (false);
		if (Boss.ChargePhase&&StartCharge&&ChargeNum<3) 
		{


			if(FaceRight )
				this.gameObject.transform.position=new Vector2(this.gameObject.transform.position.x+ChargeSpeed ,this.gameObject.transform.position.y);
			else
				this.gameObject.transform.position=new Vector2(this.gameObject.transform.position.x-ChargeSpeed ,this.gameObject.transform.position.y);
			if(this.gameObject.transform.position.x>48f)
				Flip ();
			if(this.gameObject.transform.position.x<-50f)
				Flip ();
		}
		if (Boss.ChargePhase&&ChargeNum >= 3)
		{
			//Boss.ChargePhase=false;

			if(FaceRight &&this.gameObject.transform.position.x<OriginalPositionX )
				this.gameObject.transform.position=new Vector2(this.gameObject.transform.position.x+0.5f,OriginalPositionY );
			if(!FaceRight&&this.gameObject.transform.position.x>OriginalPositionX)
				this.gameObject.transform.position=new Vector2(this.gameObject.transform.position.x-0.5f ,OriginalPositionY+15f);
			if(FaceRight&&this.gameObject.transform.position.x>=OriginalPositionX)
			{
				Boss.Shot();
				StartCharge=false;
				ChargeNum=0;
			}
			if(!FaceRight&&this.gameObject.transform.position.x<=OriginalPositionX )
			{
				Boss.Summon ();
				StartCharge =false;
				ChargeNum=0;
			}
		}

	}
	void Update()
	{
		if (!Boss.ChargePhase) 
		{
			StartCharge = false;
			PerpareToCharge =false;
		}
	}
	void PerpareCharge()
	{

		PerpareToCharge = true;
		
		if (Mathf.Abs(OriginalPositionY - this.gameObject.transform.position.y)<=0.001) 
		{
			Boss.HeroChargePoint .SetActive (true);

		}

		Invoke ("BeginCharge", 4f);

	}
	void BeginCharge()
	{
		CancelInvoke ();
		PerpareToCharge = false;
		StartCharge = true;
	}
	void Flip()
	{
		//if (FaceRight)
						this.gameObject.transform.position = new Vector2 (this.gameObject.transform.position.x, player.transform.position.y );
		/*else
			this.gameObject.transform.position = new Vector2 (this.gameObject.transform.position.x, player.transform.position.y );*/
		FaceRight=!FaceRight;
		ChargeNum++;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
