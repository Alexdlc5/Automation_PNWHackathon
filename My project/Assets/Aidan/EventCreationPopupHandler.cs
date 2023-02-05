using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class EventCreationPopupHandler : MonoBehaviour
{
    Calendar_Main calendar_Main;


    [SerializeField] TMP_Dropdown dayDropDown;
    [SerializeField] TMP_Dropdown monthDropDown;
    [SerializeField] TMP_InputField yearInput;

    [SerializeField] TMP_InputField NameInput;
    [SerializeField] TMP_InputField LocationInput;
    [SerializeField] TMP_InputField DescriptionInput;

    public System.Action<Calendar_Event> returnCall;

    // Start is called before the first frame update
    void Start()
    {
        calendar_Main = GameObject.FindGameObjectWithTag("Calendar Handler").GetComponent<Calendar_Main>();
        yearInput.text = System.DateTime.Now.Year.ToString();
        monthDropDown.value = System.DateTime.Now.Month-1;
        dayDropDown.value = System.DateTime.Now.Day-1;
        dayDropDown.options.Clear();
        updateDaySelectorOptions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateDaySelectorOptions()
    {
        int maxDays = calendar_Main.GetMaxDays(int.Parse(yearInput.text), monthDropDown.value+1);
        if (dayDropDown.options.Count == maxDays)
        {
            return;
        }

        if (dayDropDown.options.Count < maxDays)
        {
            Debug.Log("ADD DAYS");
            //add more day options
            List<TMP_Dropdown.OptionData> newDays = new List<TMP_Dropdown.OptionData>();
            for (int i = dayDropDown.options.Count+1; i <= maxDays; i++)
            {
                newDays.Add(new TMP_Dropdown.OptionData(i.ToString()));
            }
            Debug.Log("ADD DAYS LENGTH:" + newDays.Count);
            dayDropDown.options.AddRange(newDays);
        }
        else if (dayDropDown.options.Count > maxDays)
        {
            Debug.Log("REMOVE DAYS");
            dayDropDown.options.Clear();
            //add more day options
            List<TMP_Dropdown.OptionData> newDays = new List<TMP_Dropdown.OptionData>();
            for (int i = dayDropDown.options.Count + 1; i <= maxDays; i++)
            {
                newDays.Add(new TMP_Dropdown.OptionData(i.ToString()));
            }
            Debug.Log("ADD DAYS LENGTH:" + newDays.Count);
            dayDropDown.options.AddRange(newDays);
            dayDropDown.value = System.DateTime.Now.Day - 1;
        }
    }

    public void Accept()
    {
        Calendar_Date tempDate = new Calendar_Date(dayDropDown.value+1, monthDropDown.value + 1, int.Parse(yearInput.text));
        Calendar_Event temp = new Calendar_Event(NameInput.text, DescriptionInput.text, LocationInput.text, tempDate);
        returnCall?.Invoke(temp);
        Destroy(gameObject);
    }

    public void Cancel()
    {
        Destroy(gameObject);
    }
}
