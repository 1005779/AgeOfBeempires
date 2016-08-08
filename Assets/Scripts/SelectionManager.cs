using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour {
    GameManager gameManager;

    public Vector3 mousePosition; // position in world space

    // selection bounds
    public Vector3 mousePositionA;
    public Vector3 mousePositionB;

    public List<GameObject> selectedBees = new List<GameObject>();
    public GameObject selectionTriggerPrefab;
    public bool isSelecting = false;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Generate a ray based on the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Find where in the world the mouse cursor is over
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;
        }

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
                GameObject selectionTrigger = GameObject.Instantiate(selectionTriggerPrefab,
                                                                     mousePositionA,
                                                                     transform.rotation) as GameObject;

                // feed the mouse position information to the selection trigger
                selectionTrigger.GetComponent<SelectionTrigger>().mousePositionA = mousePositionA;
                selectionTrigger.GetComponent<SelectionTrigger>().mousePositionB = mousePositionB;
            }
        }

        // right click?
        if (Input.GetMouseButton(1) && selectedBees.Count > 0)
        {
            foreach (GameObject unit in selectedBees)
            {
                unit.GetComponent<Bee>().MoveTo(mousePosition);
            }
        }
    }
}
