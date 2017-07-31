using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class Menu : MonoBehaviour
{

    public GameObject PauseMenu;
    public GameObject MainMenu;
    public GameObject DeadMenu;
    public GameObject WonUI;
    public GameObject EnergyUI;
    public GameObject OxygenUI;
    public GameObject UIImage;

    public bool inMenu;
    public bool isDead;
    public bool hasWon;
    private bool inMain;
    private bool inPause;


    void Awake()
    {
        inMenu = true;
        inMain = true;
        inPause = false;
        isDead = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inMenu = !inMenu;
            inPause = !inPause;
            PauseMenu.gameObject.SetActive(inMenu);
        }
    }

    public void Resume()
    {
        inMenu = !inMenu;
        inPause = !inPause;
        PauseMenu.gameObject.SetActive(inMenu);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void QuitMenu()
    {
        inMenu = false;
        inMain = false;
        MainMenu.gameObject.SetActive(false);
        EnergyUI.gameObject.SetActive(true);
        OxygenUI.gameObject.SetActive(true);
    }
    public void EnterMenu()
    {
        Resume();
        inMenu = true;
        inMain = true;
        MainMenu.gameObject.SetActive(true);
        EnergyUI.gameObject.SetActive(false);
        OxygenUI.gameObject.SetActive(false);

    }
    public void NewGame()
    {
        UIImage.gameObject.SetActive(true);
        Debug.Log("active");
        UIImage.GetComponent<Intro>().PlayIntro();
        isDead = false;
        EnergyUI.gameObject.SetActive(true);
        OxygenUI.gameObject.SetActive(true);
        DeadMenu.gameObject.SetActive(false);
        inMenu = false;
    }

    public void EndtoMenu()
    {
        GameObject.Find("Player").GetComponent<Energy>().currentEnergy = 10000;
        GameObject.Find("Player").GetComponent<Oxygen>().currentOxygen = 10000;
        DeadMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }
    private void FixedUpdate()
    {
        if (isDead)
        {
            inMenu = true;
            EnergyUI.gameObject.SetActive(false);
            OxygenUI.gameObject.SetActive(false);
            DeadMenu.gameObject.SetActive(true);
        }
        if (hasWon)
        {
            inMenu = true;
            EnergyUI.gameObject.SetActive(false);
            OxygenUI.gameObject.SetActive(false);
            WonUI.gameObject.SetActive(true);
        }
    }



}