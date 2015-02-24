using UnityEngine;
using System.Collections;

public class SpikeProduce : MonoBehaviour {
	public GameObject spike;
	private int spikeNum;
	public float StartDelayTime;

	// Use this for initialization
	void  Start () {
		spikeNum = 0;
		if(StartDelayTime ==0)
			Instantiate (spike,this.gameObject.transform.position,Quaternion.identity);
		else
			Invoke("ProduceDelay",StartDelayTime );

	}
	
	// Update is called once per frame
	void Update () {
		if (/*GameObject.Find ("spikeFaceleft(Clone)") == null*/spikeNum<1)
		{

			spikeNum++;
			Invoke ("clearSpikeNum",1.8f+StartDelayTime);
		}

		/*if (GameObject.Find ("spikeFaceright(Clone)") == null)
		{
			Instantiate (spike,this.gameObject.transform.position,Quaternion.identity);
		}*/
	}
	void clearSpikeNum()
	{
		//CancelInvoke ();
		spikeNum = 0;
		StartDelayTime = 0;
		Instantiate (spike,this.gameObject.transform.position,Quaternion.identity);
	}
	void ProduceDelay()
	{
		//CancelInvoke ();
		//spikeNum = 0;
		Instantiate (spike,this.gameObject.transform.position,Quaternion.identity);
	}
}
