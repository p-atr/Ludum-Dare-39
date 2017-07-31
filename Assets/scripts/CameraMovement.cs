using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject player;
    Vector3 distance;

    // Use this for initialization
    void Start () {
        distance = transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = player.transform.position + distance;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
