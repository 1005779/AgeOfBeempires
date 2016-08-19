using UnityEngine;
using System.Collections;

public class QueenHive : MonoBehaviour {
    GameManager gameManager;
    SelectionManager selectionManager;

    // Variables for Currency conversion
    public float pollen = 0;
    public float honey;

    // Variables for Build Materials
    private float workers = 0;
    public float wax;

    // things for the build functions
    public GameObject droneHivePrefab;
    public float droneHive = 2;

    public GameObject workerHivePrefab;
    public float workerHive = 2;

    // Timers Variables
    public float honeyTime = 2;

    private float health = 10;

    // Use this for initialization
    void Start()
    {
        selectionManager = GameManager.FindObjectOfType<SelectionManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
        // Start Values so player can play straight away
        honey = 8;
        workers += 2;
        wax = 8;
    }
	
	// Update is called once per frame
	void Update () {
        Food();

        if (health <= 0)
            Destroy(this.gameObject);
	}

    // Transfer The Pollen Value To the bee then tell it to wait state
    public void GiveNectar(float nectar, float goop)
    {
        //take bees pollen and give it to the hives count
        pollen += nectar;
        wax += goop;
        // set the state to wait / colection state ***Not implimented***
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

    public void TakeDamage(float Damage)
    {
        health -= Damage * Time.deltaTime;
    }
}
