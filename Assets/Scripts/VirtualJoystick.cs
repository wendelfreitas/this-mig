using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystick : MonoBehaviour, IDragHandler,IPointerUpHandler,IPointerDownHandler{

	private Image bgImage;
	private Vector2 inputJoystick;
	// Use this for initialization
	void Start () {
		bgImage = GetComponent<Image> ();
	}


	public void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			inputJoystick.x = pos.x;
		}

	}

	public void OnPointerUp(PointerEventData ped)
	{
		inputJoystick.x = 0;
	}

	public void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
	}

	public float Horizontal()
	{
		return inputJoystick.x;
	}
}
