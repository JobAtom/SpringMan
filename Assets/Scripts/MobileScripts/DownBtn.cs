using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DownBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	private HeroController controls;
	// Use this for initialization
	void Start () {
		controls = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroController>();
	}
	
	#region IPointerEnterHandler implementation
	
	public void OnPointerEnter (PointerEventData eventData)
	{
		controls.StartSwimming(-1);
	}
	
	#endregion
	
	#region IPointerExitHandler implementation
	
	public void OnPointerExit (PointerEventData eventData)
	{
		controls.StartSwimming(0);
	}
	
	#endregion
}
