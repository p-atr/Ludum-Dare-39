using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WorldGen : MonoBehaviour
{

    GameObject[] energyStones;
    GameObject[] oxygenStones;
    public int energyStoneAmount;
    public int stone1Amount;
    public int oxygenStoneAmount;
    public int stone2Amount;
    //public float range;
    public int minDistanceFromPlayer;
    public int trümmerAmount;
    public int spaceShipAmount;
    public int cosmetic1Amount;
    public int cosmetic2Amount;
    public int enemyAmount;
    //   public float minStoneDistance;
    public GameObject energyStone;
    public GameObject stone1;
    public GameObject oxygenStone;
    public GameObject stone2;
    public GameObject player;
    public GameObject spaceship;
    public GameObject cosmetic1;
    public GameObject cosmetic2;
    public GameObject trümmerBig;
    public GameObject trümmerMedium;
    public GameObject trümmerSmall;
    public GameObject enemy;

    Oxygen oxygen;
    Energy energy;

    private const int mapRadius = 390;

    GameObject gSpaceShip;

    // Use this for initialization
    public void NewGame()
    {
        oxygen = player.GetComponent<Oxygen>();
        energy = player.GetComponent<Energy>();

        gSpaceShip = GenInstanceOf(spaceship, spaceShipAmount);
        GenInstanceOf(stone1, stone1Amount);
        GenInstanceOf(stone2, stone2Amount);
        GenInstanceOf(cosmetic1, cosmetic1Amount);
        GenInstanceOf(cosmetic2, cosmetic2Amount);
        GenInstanceOf(enemy, enemyAmount);
        GenTrümmer();
    }

    public void GenTrümmer()
    {
       // gSpaceShip = GameObject.FindGameObjectWithTag("SpaceShip");
        for (int i = 0; i < trümmerAmount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-mapRadius, mapRadius), Random.Range(-mapRadius, mapRadius), 0);
            
            float distance = Vector3.Distance(pos, gSpaceShip.gameObject.transform.position);
            Debug.Log(pos + ", " + gSpaceShip.gameObject.transform.position);
            if (distance < 150)
            {
                Instantiate(trümmerBig, pos, Quaternion.identity);
            } else if (distance < 400){
                Instantiate(trümmerMedium, pos, Quaternion.identity);
            } else
                Instantiate(trümmerSmall, pos, Quaternion.identity);
            {

            }

        }
    }

    public void ClearMap()
    {
        GameObject[] delenergyStones = GameObject.FindGameObjectsWithTag("EnergyStone");
        GameObject[] deloxygenStones = GameObject.FindGameObjectsWithTag("OxygenStone");
        GameObject[] deldecoration = GameObject.FindGameObjectsWithTag("Decoration");
        GameObject[] deltrümmer = GameObject.FindGameObjectsWithTag("Trümmer");
        GameObject[] delspaceships = GameObject.FindGameObjectsWithTag("SpaceShip");

        DelAll(delenergyStones);
        DelAll(deloxygenStones);
        DelAll(deldecoration);
        DelAll(deltrümmer);
        DelAll(delspaceships);

        oxygen.currentOxygen = oxygen.maxOxygen;
        energy.currentEnergy = energy.maxEnergy;
    }

    void DelAll(GameObject[] things)
    {
        for (int i = 0; i < things.Length; i++)
        {
            Destroy(things[i].gameObject);
        }
    }

    GameObject GenInstanceOf(GameObject thing, int amount)
    {
        GameObject gThing = null;
        for (int i = 0; i < amount; i++)
        {

            Vector3 pos = new Vector3(Random.Range(-mapRadius, mapRadius), Random.Range(-mapRadius, mapRadius), 0);
            gThing = Instantiate(thing, pos, Quaternion.identity);
        }
        return gThing;
    }

    void GenRegenInstanceOf(GameObject thing, GameObject[] things, int amount)
    {
        if (things.Length < energyStoneAmount)
        {
            Vector3 pos;
            do
            {
                pos = new Vector3(Random.Range(-mapRadius, mapRadius), Random.Range(-mapRadius, mapRadius), 0);
            }
            while (Vector3.Distance(pos, player.transform.position) < minDistanceFromPlayer);
            GameObject gThing = Instantiate(thing, pos, Quaternion.identity);
            gThing.transform.localScale += new Vector3(Random.Range(-0.05f, 0.1f), Random.Range(-0.05f, 0.1f), 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
            energyStones = GameObject.FindGameObjectsWithTag("EnergyStone");
            oxygenStones = GameObject.FindGameObjectsWithTag("OxygenStone");

            GenRegenInstanceOf(energyStone, energyStones, energyStoneAmount);
            GenRegenInstanceOf(oxygenStone, oxygenStones, oxygenStoneAmount);
        //    energyStones = GameObject.FindGameObjectsWithTag("EnergyStone");
        //    if (energyStones.Length < energyStoneAmount)
        //    {
        //        Vector3 playerPos = player.transform.position;
        //        GameObject energyStone = Instantiate(this.energyStone, new Vector3(Random.Range(playerPos.x- range, playerPos.x + range), Random.Range(playerPos.y - range, playerPos.y + range), 0), Quaternion.identity);
        //        energyStone.transform.localScale += new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
        //    }

        //    oxygenStones = GameObject.FindGameObjectsWithTag("OxygenStone");
        //    if (oxygenStones.Length < oxygenStoneAmount)
        //    {
        //        Vector3 playerPos = player.transform.position;
        //        GameObject oxygenStone = Instantiate(this.oxygenStone, new Vector3(Random.Range(playerPos.x - range, playerPos.x + range), Random.Range(playerPos.y - range, playerPos.y + range), 0), Quaternion.identity);
        //        oxygenStone.transform.localScale += new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
        //    }
        //}

    }
}
