using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ChargeBtn : MonoBehaviour, IPointerDownHandler {
	HeroPowers skills;
	// Use this for initialization
	void Start () {
		skills = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<HeroPowers>();
	}
	
	#region IPointerDownHandler implementation
	
	public void OnPointerDown (PointerEventData eventData)
	{
		if(HeroPowers.ChargeSkill)
			skills.HeroCharge();
	}
	
	#endregion
}
