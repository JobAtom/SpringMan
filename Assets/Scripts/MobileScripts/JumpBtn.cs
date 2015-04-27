using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class JumpBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	private HeroController controls;
	// Use this for initialization
	void Start () {
		controls = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroController>();
	}
	
	#region IPointerDownHandler implementation
	
	public void OnPointerDown (PointerEventData eventData)
	{
		controls.StartJumping(1);
	}
	
	#endregion
	
	#region IPointerUpHandler implementation
	
	public void OnPointerUp (PointerEventData eventData)
	{
		controls.StartJumping(0);
	}
	
	#endregion
}
