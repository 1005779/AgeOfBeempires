using UnityEngine;
using System.Collections;

public class QueenHive : MonoBehaviour {

    // Variables for Currency conversion
    private int pollen;
    private int honey;

    // Variables for Build Materials
    private int workers;
    private int wax;

    // Build Costs
    public int droneHive = 2;

    // Timers Variables
    public int honeyTime = 2;

    // Prefabs to instantiate
    public GameObject DroneHive;
    public GameObject hiveSpot;

    // Use this for initialization
    void Start()
    {
        // Start Values so player can play straight away
        honey = 8;
        workers = 2;
        wax = 8;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DropOff(int nectar)
    {
        pollen = pollen + (nectar / 2);
    }

    public void Food()
    {
        new WaitForSeconds(honeyTime);

        if (pollen >= 2)
        {
            pollen -= 2;
            honey += 2;
        }
    }

    public void Currency()
    {       
        if (honey >= 2)
            {
                wax += honey;
            }               
    }

    public void BuildDroneHive()
    {
        if (Input.GetKeyDown("space") && wax >= droneHive)
        {
            wax -= droneHive;
           // Instantiate(DroneHive,);
        }
    }
}
