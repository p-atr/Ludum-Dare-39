using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    // Use this for initialization
    //private Vector3 mousePosition;
    //public float moveSpeed = 0.1f;
    //private GameObject player;

    Rigidbody2D rb;
    Oxygen oxygen;
    Energy energy;

    public int constantEnergyCost;
    public int constantOxygenCost;

    public float speed = 80;
    public float currentSpeed = 80;
    public float runningMultiplier = 6;
    public int runningCost = 20;
    private bool runningActive;

    public Light flashLight;
    public bool flashLightActive = false;
    public int flashLightCost = 20;
    private int counter;
    public Text countertext;

    public GameObject stone1;
    public GameObject stone2;
    public GameObject spaceship;
    public GameObject bubble_animation;


    void Awake()
    {
        oxygen = GetComponent<Oxygen>();
        energy = GetComponent<Energy>();
        rb = GetComponent<Rigidbody2D>();

        flashLight.gameObject.SetActive(false);
    }

    void Setup()
    {
        counter = 0;
        countertext.text = "Pickups" + counter.ToString();
    }

    private void FixedUpdate()
    {
        if (!GameObject.Find("Launch").GetComponent<Menu>().inMenu)
        {
            float movementX = Input.GetAxis("Horizontal");
            float movementY = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(movementX, movementY);

            rb.AddForce(movement * currentSpeed);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Launch").GetComponent<Menu>().inMenu)
        { 
            energy.LooseEnergy(constantEnergyCost);
            oxygen.LooseOxygen(constantOxygenCost);
            flashLight.gameObject.SetActive(false);
            flashLightActive = false;

            if (Input.GetKeyDown("left shift") && oxygen.currentOxygen > 0)
            {
                runningActive = true;
                bubble_animation.gameObject.SetActive(true);
            }
            if (Input.GetKeyUp("left shift") || oxygen.currentOxygen <= 0)
            {
                currentSpeed = speed;
                runningActive = false;
                bubble_animation.gameObject.SetActive(false);
            }
            
            if (Input.GetKey(KeyCode.Mouse0) && energy.currentEnergy > 0)
            {

                flashLight.gameObject.SetActive(true);
                flashLightActive = true;
            } 
            if (Input.GetKeyUp(KeyCode.Mouse0) || energy.currentEnergy <= 0)
            {
                flashLight.gameObject.SetActive(false);
                flashLightActive = false;
            }

            if (flashLightActive == true)
            {
                energy.LooseEnergy(flashLightCost);
            }

            if (runningActive == true)
            {
                currentSpeed = runningMultiplier * speed;
                oxygen.LooseOxygen(runningCost);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //counter += 1;
        //countertext.text = "Pickups" + counter.ToString();
        if (other.gameObject.CompareTag("Pickup")) {
            Debug.Log("Collison with Pickup");
            other.gameObject.SetActive(false);
            oxygen.GainOxygen();
            
        }
        if (other.gameObject.CompareTag("EnergyStone"))
        {
            Debug.Log("Collision with EnergyStone");
            GameObject stone1 = Instantiate(this.stone1, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, 0), Quaternion.identity);
            stone1.transform.localScale = other.transform.localScale;
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            energy.GainEnergy();
        }
        if (other.gameObject.CompareTag("OxygenStone"))
        {
            Debug.Log("Collision with OxygenStone");
            GameObject stone2 = Instantiate(this.stone2, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, 0), Quaternion.identity);
            stone2.transform.localScale = other.transform.localScale;
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            oxygen.GainOxygen();

        }
        if (other.gameObject.CompareTag("SpaceShip"))
        {
            Debug.Log("Collision with SpaceShip");
            GameObject.Find("Launch").GetComponent<Menu>().hasWon = true;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject.Find("Launch").GetComponent<Menu>().isDead = true;
        }
    }
}