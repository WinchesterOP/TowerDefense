using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    public float cameraMovmentSpeed = 30f;
    public float screenBorder = 10f;

    public float minScrollHeight = 10f;
    public float maxScrollHeight = 180f;
    public float scrollSpeed = 10f;

    private bool doMovement = true;

    void Update()
    {
        // deactivates the camera movemont if you wants to test things in the inspector
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;
        if (!doMovement)
            return;

        // checks scrolling for the camera height
        CheckCameraScrolling();

        // checks for input for camera movement
        CheckCameraMovement();

        
    }

    private void CheckCameraMovement()
    {
        /**
         * Translate in Space.World left the object move without rotation(global position). If you don't use Space.World in Translate 
         * the object will move in the direction of his own rotation (local position)
         */
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - screenBorder)
        {
            transform.Translate(Vector3.forward * cameraMovmentSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= screenBorder)
        {
            transform.Translate(Vector3.back * cameraMovmentSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= screenBorder)
        {
            transform.Translate(Vector3.left * cameraMovmentSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - screenBorder)
        {
            transform.Translate(Vector3.right * cameraMovmentSpeed * Time.deltaTime, Space.World);
        }
    }

    private void CheckCameraScrolling()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        // checks if the pos variable is between min and max. Set's it to min or max if it's higher oder lower
        pos.y = Mathf.Clamp(pos.y, minScrollHeight, maxScrollHeight);

        transform.position = pos;
    }
}
