using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBase : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("Implements click w/o inspector")]
    public bool m_Dummy;

    public void OnPointerClick(PointerEventData eventData)
    {
        ButtonAction();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public virtual void ButtonAction()
    {

    }

}