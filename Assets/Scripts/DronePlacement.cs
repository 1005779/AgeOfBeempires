using UnityEngine;
using System.Collections;

public class DronePlacement : MonoBehaviour {
    private SelectionManager selectionManager;
    public GameObject DroneHivePrefab;
    private bool canPlace = true;

    // Use this for initialization
    void Start() {
        // Sellection manager set
        selectionManager = GameObject.FindObjectOfType<SelectionManager>();
    }

    // Update is called once per frame
    void Update() {
        // if placing move the building
        if (selectionManager.isPlacingBuilding)
        {
            transform.position = selectionManager.mousePosition;

            // place hive and stop build flag
            if (Input.GetMouseButton(0) && canPlace == true)
            {
                GameObject.Instantiate(DroneHivePrefab, transform.position, transform.rotation);
                selectionManager.isPlacingBuilding = false;
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Bee") || other.gameObject.CompareTag("Resource") || other.gameObject.CompareTag("QueenHive"))
        {
            canPlace = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bee") || other.gameObject.CompareTag("Resource") || other.gameObject.CompareTag("QueenHive"))
        {
            canPlace = true;
        }
    }

}
