using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    Menu menu;
    public int maxEnergy;
    public int currentEnergy;
    public int energyGain = 1000;
    public Slider energySlider;

    public void LooseEnergy(int amount)
    {
        currentEnergy -= amount;
        if (currentEnergy <= 0)
        {
            currentEnergy = 0;
            Debug.Log("Ich bims der Tod!");
            GameObject.Find("Launch").GetComponent<Menu>().isDead = true;
        }
        energySlider.value = currentEnergy;
    }
    public void GainEnergy()
    {
        currentEnergy += energyGain; ;
        if (currentEnergy > maxEnergy)
        {
            energySlider.value = maxEnergy;
        }
    }
    //slider updaten
}
