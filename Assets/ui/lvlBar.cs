using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvlBar : MonoBehaviour
{
    public Slider slider; 
    public Text valueText; 

    private Player player;
    //private int playerPastLvl;

    void Start()
    {
        
        player = Player.GetInstance();
        slider.maxValue = player.expToLvl;
        // Add a listener to the slider's value change event
        slider.onValueChanged.AddListener(delegate { UpdateSliderValue(); });

        slider.value = player.exp;

        //Update the slider's value and UI Text with the initial int value
        if (valueText != null)
        {
            valueText.text = player.currentLvl.ToString();
        }
        slider.value = player.exp;
    }

    // Update the slider value when the int value changes
    void UpdateSliderValue()
    {
        slider.value = player.exp;
        slider.maxValue = player.expToLvl;
        if (valueText != null)
        {
            valueText.text = player.currentLvl.ToString();
        }
            
    }

    private void Update()
    {
        if (player.exp != slider.value)
        {
            UpdateSliderValue();
        }
    }
}
