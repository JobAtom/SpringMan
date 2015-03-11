using UnityEngine;
using System.Collections;

public class SubmarineBossCharge : MonoBehaviour {
	private SubMarineBoss Boss;
	private bool FaceRight = true;
	private bool StartCharge;
	private float ChargeSpeed=1f;
	private float OriginalPositionX;
	private float OriginalPositionY;
	private GameObject player;
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
		if (Boss.ChargePhase&&!StartCharge )
			PerpareCharge ();
		if (StartCharge&&ChargeNum<3) 
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
		if (ChargeNum >= 3)
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
		if (!Boss.ChargePhase)
						StartCharge = false;
	}
	void PerpareCharge()
	{

		Invoke ("BeginCharge", 4f);

	}
	void BeginCharge()
	{
		CancelInvoke ();
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
