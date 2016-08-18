using UnityEngine;
using System.Collections;

public class DroneHive : MonoBehaviour {

    private SelectionManager selectionManager;
    QueenHive queenHive;

    public GameObject beeType;
    public GameObject spawn;

	// Use this for initialization
	void Start () {
        selectionManager = GameManager.FindObjectOfType<SelectionManager>();
        queenHive = GameManager.FindObjectOfType<QueenHive>();
	    

	}

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBee()
    {
        if (!selectionManager.isPlacingBuilding && queenHive.honey >= 5)
        {
            queenHive.honey -= 5;  // Subtract cost oh hive

            selectionManager.isPlacingBuilding = true;  // enable building placement mode

            selectionManager.selectedBees.Clear();  // Clear the selected units

            selectionManager.Update_MousePosition();  // Force an update of the mouse possition

            GameObject BeeSpawn = Instantiate(beeType, spawn.transform.position, transform.rotation) as GameObject;
        }
    }
}
