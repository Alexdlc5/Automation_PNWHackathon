using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Snapping_point : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Mouse_Manager manager;
    public bool pointerover = false;
    public void OnPointerExit(PointerEventData eventData)
    {
        manager.over_point = true;
        pointerover = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        manager.over_point = true;
        pointerover = true;
    }
}
