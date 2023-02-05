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

    public void setup(Calendar_Event eventinfo)
    {
        EventName.text = eventinfo.Name;
        EventDescription.text = eventinfo.Description;
        EventLocation.text = eventinfo.Location;
        EventDate.text = eventinfo.Date.ToString();
    }
}
