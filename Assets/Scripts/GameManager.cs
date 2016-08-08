using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Vector3 mousePosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       

    }

    public void GetMousePos()
    {
        // Generate a ray based on the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Find where in the world the mouse cursor is over
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;
        }

    }
}
