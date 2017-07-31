using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour {

    private GameObject player;
    public float detectionDistance;
    private float distance;
    public float speed;
    Vector3 home;
    Vector3 destination;
    private Vector3 playerPos;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        home = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        playerPos = player.transform.position;

        distance = Vector3.Distance(playerPos, home);

        if (distance < detectionDistance)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, playerPos, step);
        }

        //Debug.Log(step);
    }
}
