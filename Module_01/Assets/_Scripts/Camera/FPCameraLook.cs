using UnityEngine;

public class FPCameraLook : MonoBehaviour
{
    public Transform playerRoot;  // the Player (capsule)
    public float mouseSensitivity = 150f;
    public float minPitch = -75f;
    public float maxPitch = 75f;

    float pitch;

    void Update()
    {
        float mx = Input.GetAxisRaw("Mouse X");
        float my = Input.GetAxisRaw("Mouse Y");

        // yaw on player, pitch on camera
        playerRoot.Rotate(Vector3.up, mx * mouseSensitivity * Time.deltaTime);
        pitch = Mathf.Clamp(pitch - my * mouseSensitivity * Time.deltaTime, minPitch, maxPitch);
        transform.localEulerAngles = new Vector3(pitch, 0f, 0f);
    }
}