using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionTrigger : MonoBehaviour {
    private SelectionManager selectionManager;

    public List<GameObject> selectedBees = new List<GameObject>();

    public Vector3 mousePositionA;
    public Vector3 mousePositionB;

	// Use this for initialization
	void Start () {
        selectionManager = GameManager.FindObjectOfType<SelectionManager>();
    }

    void Update()
    {
        // Generate a ray based on the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Find where in the world the mouse cursor is over
        RaycastHit hit;
        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit))
        {
            mousePositionB = hit.point;

            // work out the scale
            Vector3 newScale = mousePositionA - mousePositionB;
            newScale.y = 3f; // nothing to see here. please ignore the magic

            // apply the scale
            transform.localScale = newScale;
            transform.position = (mousePositionA + mousePositionB) / 2;
        }
        else
        {
            selectionManager.isSelecting = false;
            selectionManager.selectedBees = selectedBees;

            // our job is done so time to say goodnight
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider otherObject)
    {
        Debug.Log(otherObject.gameObject.name);
        if (otherObject.CompareTag("Bee"))
            selectedBees.Add(otherObject.gameObject);        
    }
    void OnTriggerExit(Collider otherObject)
    {
        Debug.Log(otherObject.gameObject.name);
        if (otherObject.CompareTag("Bee"))
            selectedBees.Remove(otherObject.gameObject);
    }
}
