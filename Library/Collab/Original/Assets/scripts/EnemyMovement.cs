using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour {

    public GameObject enemy;
    private GameObject player;
    public float detectionDistance;
    private float distance;
    public float speed;
    Vector3 home;
    Vector3 destination;
    private Vector3 playerPos;
    private Vector3 enemyPos;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyPos = enemy.transform.position;
        home = enemyPos;
    }
	
	// Update is called once per frame
	void Update () {
        playerPos = player.transform.position;
        enemyPos = enemy.transform.position;

        distance = Vector3.Distance(playerPos, enemyPos);
        float step = 0;

        if (distance < detectionDistance)
        {
            step = speed * Time.deltaTime;
            enemyPos = Vector3.MoveTowards(enemyPos, playerPos, 1);
        }

        Debug.Log(step);
	}
}
