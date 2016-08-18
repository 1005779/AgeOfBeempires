using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour {
    GameManager gameManager;
    private QueenHive queenHive;
    
    public Vector3 mousePosition; // position in world space
    public bool mouseOverLevelGeometry = false;

    // selection bounds
    public Vector3 mousePositionA;
    public Vector3 mousePositionB;

    public List<GameObject> selectedBees = new List<GameObject>();
    public List<GameObject> selectedWBees = new List<GameObject>();
    public GameObject selectionTriggerPrefab;
    public bool isSelecting = false;
    public bool isPlacingBuilding = false;

    // Use this for initialization
    void Start()
    {
        queenHive = GameManager.FindObjectOfType<QueenHive>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Reset mouseOverLegelGeometry flag
        mouseOverLevelGeometry = false;

        // Updating the mouse pos once the buttons are down
        if (isPlacingBuilding || Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            Update_MousePosition();           
        }  
        
        // If we're not placing a building
        if (!isPlacingBuilding)
        {
            Update_selection();
        }

        Update_MousePosition();
    
    }

    public void Update_MousePosition()
    {
        // Generate a ray based on the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Find where in the world the mouse cursor is over
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;

            // Flag thet we are over level geometry
            mouseOverLevelGeometry = true;
        }
    }

    void Update_selection()
    {
        // left click?
        if (Input.GetMouseButtonDown(0))
        {
            // selection not in progress?
            if (!isSelecting)
            {
                // selection in progress
                isSelecting = true;

                // store the mouse position and create the selection trigger
                mousePositionA = mousePosition;
                GameObject selectionTrigger = GameObject.Instantiate(selectionTriggerPrefab, mousePositionA, transform.rotation) as GameObject;

                // feed the mouse position information to the selection trigger
                selectionTrigger.GetComponent<SelectionTrigger>().mousePositionA = mousePositionA;
                selectionTrigger.GetComponent<SelectionTrigger>().mousePositionB = mousePositionB;
            }
        }

        // right click?
        if (Input.GetMouseButton(1) && (selectedBees.Count > 0 || selectedWBees.Count > 0))
        {
            // Move Workers
            foreach (GameObject unit in selectedBees)
            {
                unit.GetComponent<Bee>().MoveTo(mousePosition);
            }
            // Move Warriors
            foreach (GameObject unit in selectedWBees)
            {
                unit.GetComponent<WarriorBee>().MoveTo(mousePosition);
            }
        }
    }

    public void PlaceBuilding(GameObject buildingPrefab)
    {
        // if we are not in building placment mode
        if (!isPlacingBuilding && queenHive.wax >= 25)
        {           
            queenHive.wax -= 25;  // Subtract cost oh hive
          
            isPlacingBuilding = true;  // enable building placement mode
          
            selectedBees.Clear();  // Clear the selected units
           
            Update_MousePosition();  // Force an update of the mouse possition

            GameObject buildingInstance = Instantiate(buildingPrefab, mousePosition, transform.rotation) as GameObject; 
        }
    }

}
