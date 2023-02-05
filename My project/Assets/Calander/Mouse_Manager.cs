using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;

public class Mouse_Manager : MonoBehaviour
{
    public Vector2 mouse_position;
    public GameObject[] snap_points;
    public GameObject[] tasks;
    public bool is_task_held = false;
    public GameObject task;
    public GameObject closest_task;
    public GameObject closest_point;
    public bool over_button = false;
    private EventSystem eventSystem;
    public bool over_point = false;

    private void Start()
    {
        snap_points = GameObject.FindGameObjectsWithTag("Snap_Points");
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        snap_points = GameObject.FindGameObjectsWithTag("Snap_Points");
        findTask();
        //findPoint();
        foreach (GameObject point in snap_points)
        {
            if (point.GetComponent<Snapping_point>().pointerover)
            {
                closest_point = point;
            }
        }
        //get closest point
        mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!over_button && GameObject.FindGameObjectWithTag("Task") != null)
        {
            if (is_task_held)
            {
                task.transform.position = Camera.main.WorldToScreenPoint(new Vector2(mouse_position.x + .2f, mouse_position.y - .2f));
            }
            //no task held and user trys to pickup a task
            if (Input.GetMouseButtonDown(0) && !is_task_held)
            {
                task = closest_task;
                is_task_held = true;
            }
            //task held and user trys to drop task
            else if (Input.GetMouseButtonDown(0) && is_task_held && over_point)
            {
                if (closest_point != null)
                {
                    task.transform.position = closest_point.transform.position;
                    is_task_held = false;
                    task = null;
                }               
            }

        }
        closest_task = null;
        closest_point = null;
    }
    public void findTask()
    {
        //find closest task
        tasks = GameObject.FindGameObjectsWithTag("Task");
        foreach (GameObject t in tasks)
        {
            if (closest_task == null)
            {
                closest_task = t;
            }
            //if distance from mouse is less than current closest
            else if (Vector2.Distance(Camera.main.ScreenToWorldPoint(closest_task.transform.position), mouse_position) > Vector2.Distance(Camera.main.ScreenToWorldPoint(t.transform.position), mouse_position))
            {
                closest_task = t;
            }
        }
    }
    //public void findPoint()
    //{
    //    foreach (GameObject sp in snap_points)
    //    {
    //        if (closest_point == null)
    //        {
    //            closest_point = sp;
    //        }
    //        //if distance from mouse is less than current closest
    //        else if (Vector2.Distance(Camera.main.ScreenToWorldPoint(closest_point.transform.position), mouse_position) > Vector2.Distance(Camera.main.ScreenToWorldPoint(sp.transform.position), mouse_position))
    //        {
    //            closest_point = sp;
    //        }
    //    }
    //}
}
