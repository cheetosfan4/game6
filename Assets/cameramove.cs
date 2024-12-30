using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Reference to the player transform
    public Vector3 defaultCameraPosition = new Vector3(0, 8, 13); // Default camera position
    public Vector3 alternateCameraPosition = new Vector3(-18, 8, 13); // Alternate camera position

    void Update()
    {
        if (player != null)
        {
            // Check player's x position and update camera position instantly
            if (player.position.x < -8.5)
            {
                transform.position = alternateCameraPosition;
            }
            else
            {
                transform.position = defaultCameraPosition;
            }
        }
    }
}
