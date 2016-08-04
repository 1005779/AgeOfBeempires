using UnityEngine;
using System.Collections;

public class CameraControllers : MonoBehaviour
{

    public GameObject cameraObject;

    public float minHeight = 10;
    public float maxHeight = 80;

    public float minAngle = 30;
    public float maxAngle = 80;

    public float currentZoom = 0.5f;

    public float zoomSpeed = 0.2f;

    public float hSpeed = 8f;
    public float vSpeed = 8f;

    public float scrollDistance = 5.0f;
    public float scrollSpeed = 25.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateZoom();

        UpdateMovement();
    }

    void UpdateMovement()
    {
        // no axis input? allow mouse panning
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            if (Input.mousePosition.x < scrollDistance)
                transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime);
            else if (Input.mousePosition.x > (Screen.width - scrollDistance))
                transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);

            if (Input.mousePosition.y < scrollDistance)
                transform.Translate(Vector3.forward * -scrollSpeed * Time.deltaTime);
            else if (Input.mousePosition.y > (Screen.height - scrollDistance))
                transform.Translate(Vector3.forward * scrollSpeed * Time.deltaTime);
        }
        else
        {
            // work out how much to move the camera based on the input
            Vector3 positionDelta = new Vector3(Input.GetAxis("Horizontal") * hSpeed * Time.deltaTime,
                                                0f,
                                                Input.GetAxis("Vertical") * vSpeed * Time.deltaTime);

            // If you want to restrict the camera bounds
            // There is a Bounds variable type which has a method ClosestPoint
            // You can use that to clamp to the bounds of the world

            // Move the camera
            transform.position += positionDelta;
        }
    }

    void UpdateZoom()
    {
        // update the current zoom
        float scrollInput = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        currentZoom = Mathf.Clamp01(currentZoom + scrollInput);

        // for smoother movement run current zoom through cos and use the new value
        float lerpFactor = Mathf.Clamp01(0.5f * (1.0f - Mathf.Cos(currentZoom * Mathf.PI)));

        // calculate the new angle and height
        float newAngle = Mathf.Lerp(minAngle, maxAngle, lerpFactor);
        float newHeight = Mathf.Lerp(minHeight, maxHeight, lerpFactor);

        // move the camera
        cameraObject.transform.localEulerAngles = new Vector3(newAngle, 0f, 0f);

        Vector3 currentPosition = transform.position;
        currentPosition.y = newHeight;
        transform.position = currentPosition;
    }
}