using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("pointer enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("pointer exit");
    }
    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("selected");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("deselected");
    }
}
