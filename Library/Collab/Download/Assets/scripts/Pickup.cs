using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pickup : MonoBehaviour
{

    Oxygen oxygen;
    Energy energy;
    //public int oxygenGainAmount;
    //public int energyGainAmount;
    int energyGainAmount = 1000;
    int oxygenGainAmount = 1000;

    // Use this for initialization
    void Awake()
    {
        oxygen = GetComponent<Oxygen>();
        energy = GetComponent<Energy>();
    }
    public void Reaction(string type)
    {
        try
        {
            Debug.Log("react");
            if (type == "Pickup") {
                oxygen.GainOxygen(oxygenGainAmount);
            }
            if (type == "Energy_Pickup")
            {
                energy.GainEnergy(energyGainAmount);
            }
            
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("public void React()" + ex);
        }

    }

}