using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Snapping_point : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    public Day_Manager day_manager;
    public bool pointerover = false;
    public int day = 1;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(setNewDay);
    }
    private void setNewDay()
    {
        day_manager.setCurrentDay(day);
    }
    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    manager.over_point = true;
    //    pointerover = false;
    //}
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    manager.over_point = true;
    //    pointerover = true;
    //}
}
