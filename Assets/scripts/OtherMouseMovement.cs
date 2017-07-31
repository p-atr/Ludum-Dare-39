using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMouseMovement : MonoBehaviour
{

    public GameObject player;

    private float deltaY;
    private float deltaX;
    private float distance;
    private float sinA;
    private float angle;

    private void FixedUpdate()
    {
        if (!GameObject.Find("Launch").GetComponent<Menu>().inMenu)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.up * 10f);
            deltaY = mouseWorldPosition.y - player.transform.position.y;
            deltaX = mouseWorldPosition.x - player.transform.position.x;

            angle = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg +90;

            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }
    }

}