using UnityEngine;  
using UnityEngine.UI;
 
public class PlayerHealthBar : RawImage 
{
    private Slider m_BloodSlider;

    protected override void OnRectTransformDimensionsChange()  
    {
        base.OnRectTransformDimensionsChange();  
        // Get health bars  
        if (m_BloodSlider == null)  
            m_BloodSlider = transform.parent.parent.GetComponent<Slider>();  
        /* 
         * According to the length of the blood bar
         * Typeset circularly the pictures 
         */
        if (m_BloodSlider != null)  
        {
            // Refresh the display of the health bar
            float value = m_BloodSlider.value;  
            uvRect = new Rect(0,0,value,1);
        }  
    }     
}
