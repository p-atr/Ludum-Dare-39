using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Use this for initialization
    //private Vector3 mousePosition;
    //public float moveSpeed = 0.1f;
    //private GameObject player;

    Rigidbody2D rb;
    Oxygen oxygen;
    Energy energy;
    Pickup pickup;

    public float speed;

    void Awake()
    {
        oxygen = GetComponent<Oxygen>();
        energy = GetComponent<Energy>();
        pickup = GetComponent<Pickup>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(movementX, movementY);

        rb.AddForce(movement * speed);
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(1))
        //{
        //    mousePosition = Input.mousePosition;
        //    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //    transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        //}
        oxygen.LooseOxygen(2);
        energy.LooseEnergy(1);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup")) {
            Debug.Log("Collison with Pickup");
            pickup.Reaction("Pickup");
        }
        if (other.gameObject.CompareTag("Energy_Pickup"))
        {
            Debug.Log("Collision with Energy_Pickup");
            pickup.Reaction("Energy_Pickup");
        }
    }
}