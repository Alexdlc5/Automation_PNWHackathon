using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class New_Task : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject task;
    public Vector2 spawn_location;
    public Button button;
    public GameObject canvas;
    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(instantiateTask);
    }
    void instantiateTask()
    {
        if (!manager.GetComponent<Mouse_Manager>().is_task_held)
        {
            GameObject newtask = Instantiate(task, spawn_location, transform.rotation, canvas.transform);
            manager.GetComponent<Mouse_Manager>().task = newtask;
            manager.GetComponent<Mouse_Manager>().is_task_held = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        manager.GetComponent<Mouse_Manager>().over_button = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        manager.GetComponent<Mouse_Manager>().over_button = true;
    }
}
