using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddTask : MonoBehaviour
{
    public GameObject taskPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Add_Task);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add_Task()
    {
        //GameObject newTask = Instantiate(taskPrefab,Vector3.zero,transform.rotation);

    }
}
