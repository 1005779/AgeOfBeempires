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
        // Check  if the mousebutton is down and if we are ofer the level geometry
        if (Input.GetMouseButton(0) && selectionManager.mouseOverLegelGeometry)
        {
            mousePositionB = selectionManager.mousePosition;

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
