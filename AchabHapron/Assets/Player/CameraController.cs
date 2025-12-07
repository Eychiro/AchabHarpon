using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform _camera;
    public float cameraSensitivity = 200.0f;
    public float cameraAcceleration = 5.0f;

    private float rotationX;
    private float rotationY;

    public bool cameraLocked = false;
    
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (cameraLocked)
        return;
        rotationX += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Mouvement réaliste qui met du délai à la camera pour suivre le mouvement //
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, rotationY, 0), cameraAcceleration * Time.deltaTime);
        _camera.localRotation = Quaternion.Lerp(_camera.localRotation, Quaternion.Euler(-rotationX, 0, 0), cameraAcceleration * Time.deltaTime);
    }

    public void ResetPos()
    {
        rotationX = 0;
        rotationY = transform.localRotation.eulerAngles.y;
        _camera.localRotation = Quaternion.identity;
    }
}
