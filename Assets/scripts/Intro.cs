using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour {

    public Image intro;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayIntro()
    {
        StartCoroutine(Pause());

        intro.sprite = Resources.Load<Sprite>("sprites/Intros/Intro_1") as Sprite;
        Pause();
        intro.sprite = Resources.Load<Sprite>("sprites/Intros/Intro_2") as Sprite;
        Pause();
        intro.sprite = Resources.Load<Sprite>("sprites/Intros/Intro_3") as Sprite;
        Pause();
        intro.sprite = Resources.Load<Sprite>("sprites/Intros/Intro_4") as Sprite;
        Pause();
        intro.sprite = Resources.Load<Sprite>("sprites/Intros/Intro_5") as Sprite;

        intro.gameObject.SetActive(false);
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(3);
    }
}
