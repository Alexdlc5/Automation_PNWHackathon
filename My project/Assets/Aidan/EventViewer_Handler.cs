using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventViewer_Handler : MonoBehaviour
{
    [SerializeField] TMP_Text EventName;
    [SerializeField] TMP_Text EventDescription;
    [SerializeField] TMP_Text EventLocation;
    [SerializeField] TMP_Text EventDate;
    Calendar_Event reference;

    Calendar_Main main;

    public void Start()
    {
        main = GameObject.FindGameObjectWithTag("Calendar Handler").GetComponent<Calendar_Main>();
    }
    public void setup(Calendar_Event eventinfo)
    {
        reference = eventinfo;
        EventName.text = eventinfo.Name;
        EventDescription.text = eventinfo.Description;
        EventLocation.text = eventinfo.Location;
        EventDate.text = eventinfo.Date.ToString();
    }

    public void RemoveThisEvent()
    {
        Debug.Log("REMOVE EVENT BUTTON CLICKED");
        main.RemoveEvent(reference);
    }
}
