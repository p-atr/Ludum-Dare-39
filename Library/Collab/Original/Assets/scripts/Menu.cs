using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour
{

    public GameObject menu;
    private bool inMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape");
            inMenu = !inMenu;
            menu.SetActive(inMenu);
        }
    }
}