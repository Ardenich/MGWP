using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStickScript : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    public Image backImg;
    public Image joystickImg;
    private Vector2 inputVec;

    public virtual void OnDrag(PointerEventData psd)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(backImg.rectTransform,psd.position,psd.pressEventCamera, out pos))
        {
            pos.x = pos.x / backImg.rectTransform.sizeDelta.x;
            pos.y = pos.y / backImg.rectTransform.sizeDelta.y;

            inputVec = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1);
            if (inputVec.magnitude > 1.0f)
            {
                inputVec = inputVec.normalized;
            }

            joystickImg.rectTransform.anchoredPosition = new Vector2(inputVec.x * (backImg.rectTransform.sizeDelta.x / 3), inputVec.y * (backImg.rectTransform.sizeDelta.y / 3));
        }
    }

    public virtual void OnPointerDown(PointerEventData psd)
    {
        OnDrag(psd);
    }

    public virtual void OnPointerUp(PointerEventData psd)
    {
        inputVec = Vector2.zero;
        joystickImg.rectTransform.anchoredPosition = Vector2.zero;
    }
    public float Horizontal()
    {
        if(inputVec.x != 0)
        {
            return inputVec.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }
    public float Vertical()
    {
        if(inputVec.y != 0)
        {
            return inputVec.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
