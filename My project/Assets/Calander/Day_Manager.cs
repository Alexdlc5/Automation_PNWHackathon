using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Day_Manager : MonoBehaviour
{
    [SerializeField]private int current_day = 1;
    public Calendar_Main calender_main;
    public void setCurrentDay(int day)
    {
        current_day = day;
    }
}
