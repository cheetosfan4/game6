using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Reference to the player transform
    public Vector3 defaultCameraPosition = new Vector3(0, 8, 13); // Default camera position
	public Vector3 defaultCameraRotation = new Vector3(25, 180, 0);
    public Vector3 alternateCameraPosition = new Vector3(-18, 8, 13); // Alternate camera position
	public Vector3 alternateCameraRotation = new Vector3(25, 215, 0);
	public Vector3 alternateCameraPosition2 = new Vector3(25, 8, 7);

    void Update()
    {
        if (player != null)
        {
            // Check player's x position and update camera position instantly
            if (player.position.x < -8.5)
            {
                transform.position = alternateCameraPosition;
				transform.rotation = Quaternion.Euler(defaultCameraRotation);
            }
            else if (player.position.x > -8.5 && player.position.x < 8.5)
            {
                transform.position = defaultCameraPosition;
				transform.rotation = Quaternion.Euler(defaultCameraRotation);
            }
			else if (player.position.x > 8.5) {
				transform.position = alternateCameraPosition2;
				transform.rotation = Quaternion.Euler(alternateCameraRotation);
			}
        }
    }
}
