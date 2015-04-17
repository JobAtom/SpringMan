using UnityEngine;
using System.Collections;

public class DestroyIfNotMobile : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		#if !UNITY_IOS && !UNITY_ANDROID && !UNITY_BLACKBERRY && !UNITY_WINRT
		Destroy (this.gameObject);
		#endif
	}
}
