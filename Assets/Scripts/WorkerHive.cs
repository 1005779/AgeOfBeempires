using UnityEngine;
using System.Collections;

public class WorkerHive : MonoBehaviour {

    private SelectionManager selectionManager;
    private QueenHive queenHive;

    public GameObject beeType;
    public GameObject spawnObject;
    private Vector3 spawnLocation;
    
	// Use this for initialization
	void Start () {

        queenHive = GameObject.FindObjectOfType<QueenHive>();
        selectionManager = GameObject.FindObjectOfType<SelectionManager>();

        spawnLocation = spawnObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnBee()
    {
        if (queenHive.honey >= 5)
        {
            queenHive.honey -= 5; // Subtract cost from Hive

            GameObject Instance = Instantiate(beeType, spawnLocation, transform.rotation) as GameObject;
        }
    }
}
