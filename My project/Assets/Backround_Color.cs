using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backround_Color : MonoBehaviour
{
    public float color_multiplier = 1.2f;
    public RawImage backround;
    public RawImage[] rawImage;
    public Slider[] sliders;
    // Update is called once per frame
    void Update()
    {
        backround.color = new Color(sliders[0].value, sliders[1].value, sliders[2].value);
    }
}
