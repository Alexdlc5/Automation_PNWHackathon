using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Day_Manager : MonoBehaviour
{
    public TextMeshProUGUI display;
    [SerializeField]private int current_day = 1;
    public Calendar_Main calender_main;
    public void setCurrentDay(int day)
    {
        current_day = day;
        display.text = day.ToString();
    }
}
