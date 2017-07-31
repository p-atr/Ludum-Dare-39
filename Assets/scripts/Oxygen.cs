using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    Menu menu;
    public int maxOxygen;
    public int currentOxygen;
    public int oxygenGain = 1000;
    public Slider oxygenSlider;

    private void Awake()
    {
        menu = GetComponent<Menu>();
    }
    public void LooseOxygen(int amount)
    {
        currentOxygen -= amount;
        if (currentOxygen <= 0)
        {
            currentOxygen = 0;
            Debug.Log("Ich bims der Tod!");
            GameObject.Find("Launch").GetComponent<Menu>().isDead = true;
        }
        oxygenSlider.value = currentOxygen;
    }
    public void GainOxygen()
    {
        currentOxygen += oxygenGain;
        if (currentOxygen > maxOxygen)
        {
            oxygenSlider.value = maxOxygen;
        }
    }
}