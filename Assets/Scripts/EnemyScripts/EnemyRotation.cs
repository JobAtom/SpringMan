using UnityEngine;
using System.Collections;

public class EnemyRotation : MonoBehaviour {
	public bool rotateleft;
	public bool rotateright;
	private Vector3 rotatepointleft;
	private Vector3 rotatepointright;
	// Use this for initialization
	void Start () {
		rotatepointleft = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y + 5f, this.gameObject.transform.position.z);
		rotatepointright=new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 5f, this.gameObject.transform.position.z);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (rotateleft&&!rotateright)
		{
			transform.RotateAround(rotatepointleft, Vector3.forward, 50 * Time.deltaTime);
		}
		if (rotateright&&!rotateleft) 
		{
			transform.RotateAround(rotatepointright, Vector3.forward, -50 * Time.deltaTime);
		}
	}
}
