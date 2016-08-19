using UnityEngine;
using System.Collections;

public class DroneHive : MonoBehaviour {

    private SelectionManager selectionManager;
    QueenHive queenHive;

    public GameObject beeType;
    public GameObject spawn;
    public Vector3 spawnLocation;

	// Use this for initialization
	void Start () {
        selectionManager = GameManager.FindObjectOfType<SelectionManager>();
        queenHive = GameManager.FindObjectOfType<QueenHive>();

        spawnLocation = spawn.transform.position;
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBee()
    {
        if (queenHive.honey >= 5)
        {
            queenHive.honey -= 5;  // Subtract cost from hive
                        
            GameObject Instance = Instantiate(beeType, spawnLocation, transform.rotation) as GameObject;
        }
    }
}
