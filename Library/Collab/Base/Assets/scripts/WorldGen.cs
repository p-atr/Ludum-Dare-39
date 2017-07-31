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
    public int spaceShipAmount;
    public int cosmetic1Amount;
    public int cosmetic2Amount;
    //   public float minStoneDistance;
    public GameObject energyStone;
    public GameObject stone1;
    public GameObject oxygenStone;
    public GameObject stone2;
    public GameObject player;
    public GameObject spaceship;
    public GameObject cosmetic1;
    public GameObject cosmetic2;

    private const int mapRadius = 410;


    // Use this for initialization
    public void NewGame()
    {
        GenInstanceOf(spaceship, spaceShipAmount);
        GenInstanceOf(stone1, stone1Amount);
        GenInstanceOf(stone2, stone2Amount);
        GenInstanceOf(cosmetic1, cosmetic1Amount);
        GenInstanceOf(cosmetic2, cosmetic2Amount);

    }

    public void ClearMap()
    {

    }

    void GenInstanceOf(GameObject thing, int amount)
    {
        for (int i = 0; i < amount; i++)
        {

            Vector3 pos = new Vector3(Random.Range(-mapRadius, mapRadius), Random.Range(-mapRadius, mapRadius), 0);
            Instantiate(thing, pos, Quaternion.identity);
        }
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
