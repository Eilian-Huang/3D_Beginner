using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public Slider m_slider;

    public float GetSliderValue ()
    {
        return m_slider.value;
    }

    public void SetSliderValue (float newValue)
    {
        m_slider.value = newValue;
    }
}
