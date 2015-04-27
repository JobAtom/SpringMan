using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class LeftBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	private HeroController controls;
	// Use this for initialization
	void Start () {
		controls = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroController>();
	}
	
	#region IPointerEnterHandler implementation
	public void OnPointerEnter (PointerEventData eventData)
	{
		controls.StartMoving(-1);
	}
	#endregion
	
	#region IPointerExitHandler implementation
	
	public void OnPointerExit (PointerEventData eventData)
	{
		controls.StartMoving(0);
	}
	
	#endregion
}
