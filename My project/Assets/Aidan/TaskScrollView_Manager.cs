using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskScrollView_Manager : MonoBehaviour
{
    [SerializeField] Calendar_Main calendar_Main;
    [SerializeField] General_UI_DropDown_Handler_ScriptV2 scrollviewHandler;
    [SerializeField] Day_Manager day_Manager;
    [SerializeField] GameObject prefab;

    int localSelectedDay = 1;

    // Start is called before the first frame update
    void Start()
    {
        localSelectedDay = day_Manager.current_day+1;
    }



    // Update is called once per frame
    void Update()
    {
        Calendar_Date date = new Calendar_Date(day_Manager.current_day, calendar_Main.SelectedMonth, calendar_Main.SelectedYear);
        if (localSelectedDay != day_Manager.current_day || eventCount != calendar_Main.GetEventsOnDate(date).Count)
        {
            localSelectedDay = day_Manager.current_day;

            foreach (General_UI_DropDown_Handler_ScriptV2 DH in scrollviewHandler.GetChildDropDowns())
            {
                Destroy(DH.gameObject);
            }
            scrollviewHandler.clearChildDropDowns();
            loadEvents();


        }
    }

    int eventCount = 0;
    void loadEvents()
    {
        Calendar_Date date = new Calendar_Date(day_Manager.current_day, calendar_Main.SelectedMonth, calendar_Main.SelectedYear);
        List<Calendar_Event> Events = calendar_Main.GetEventsOnDate(date);

        foreach (Calendar_Event e in Events)
        {
            GameObject tempOB = Instantiate(prefab);
            tempOB.transform.SetParent(scrollviewHandler.ChildrenObjectHolder.transform);
            General_UI_DropDown_Handler_ScriptV2 tempDH = tempOB.GetComponent<General_UI_DropDown_Handler_ScriptV2>();
            EventViewer_Handler EVH = tempOB.GetComponent<EventViewer_Handler>();
            EVH.setup(e);
            scrollviewHandler.addToChildDropDowns(tempDH);
        }
    }
}
