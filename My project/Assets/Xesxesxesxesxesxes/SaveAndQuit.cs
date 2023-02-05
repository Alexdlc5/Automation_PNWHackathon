using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndQuit : MonoBehaviour
{
    public Calendar_Main c;
    public RawImage rawImage;

    // Start is called before the first frame update
    void Start()
    {
        saveData save = UtilClass.LoadFromFile<saveData>(Application.persistentDataPath, "txt", "bingus", false);
        c.Events.AddRange(save.Events);
        Color temp = new Color(save.color[0], save.color[1], save.color[2]);
        rawImage.color = temp;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            saveData save;
            save.Events = c.Events.ToArray();
            save.color = new float[] { rawImage.color.r, rawImage.color.g, rawImage.color.b };
            UtilClass.SaveToFile(Application.persistentDataPath + "", "txt", "bingus", save);
            //SaveSystem.Save(c.Events, new float[]{rawImage.color.r, rawImage.color.g, rawImage.color.b}  );
            Application.Quit();
        }
    }

    [System.Serializable]
    struct saveData
    {
        public Calendar_Event[] Events;
        public float[] color;
        

       
    }
}
