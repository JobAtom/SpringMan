using UnityEngine;
using System.Collections;

public class SpikeProduce : MonoBehaviour {
	public GameObject spike;
	private int spikeNum;

	// Use this for initialization
	void  Start () {
		spikeNum = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (/*GameObject.Find ("spikeFaceleft(Clone)") == null*/spikeNum<1)
		{
			Instantiate (spike,this.gameObject.transform.position,Quaternion.identity);
			spikeNum++;
			Invoke ("clearSpikeNum",3f);
		}

		/*if (GameObject.Find ("spikeFaceright(Clone)") == null)
		{
			Instantiate (spike,this.gameObject.transform.position,Quaternion.identity);
		}*/
	}
	void clearSpikeNum()
	{
		spikeNum = 0;
	}
}
