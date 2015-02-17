using UnityEngine;
using System.Collections;

public class MoveLeftOrRight : MonoBehaviour {
	public  bool faceright;
	private float moveSpeed=0.05f;
	// Use this for initialization
	void Start () {
		faceright = false;
	}
	
	void FixedUpdate () 
	{

			if (faceright)
			{	
				
				transform.position = new Vector2 (transform.position.x + moveSpeed, transform.position.y);
			}
			else if (!faceright)
			{
				
				transform.position = new Vector2 (transform.position.x - moveSpeed, transform.position.y);
			}

		
	}
	
	void Flip()
	{
		faceright=!faceright;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{

		if (other.collider.tag == "trap"||other.collider.tag=="Wall"||other.collider.tag=="ground")
		{
			//faceright =!faceright ;
			
			Flip ();
			if(faceright)
				transform.position=new Vector2(transform.position.x+1f,transform.position.y);
			else
				transform.position=new Vector2(transform.position.x-1f,transform.position.y);
			
		}
		
		
		
		
	}
}
