using UnityEngine;
using System.Collections;

public class QueenHive : MonoBehaviour {

    // Variables for Currency conversion
    private float pollen = 0;
    private float honey;

    // Variables for Build Materials
    private float workers;
    private float wax;

    // Build Costs
    public float droneHive = 2;

    // Timers Variables
    public float honeyTime = 2;

    // Prefabs to instantiate
    public GameObject droneHivePrefab;

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
        Food();
        Currency();
	}

    // Transfer The Pollen Value To the bee then tell it to wait state
    public void OnColliderEnter(Collider otherObject)
    {
        if (otherObject.tag == "Bee")
        {
                        
        }            
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
