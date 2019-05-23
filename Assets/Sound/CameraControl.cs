using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    Transform cameraTarget;

    float pitch;
    float yaw;
    float distance;

    const float minDistance = 1f;
    const float maxDistance = 20f;
    const float defaultDistance = 3f;
    const float zoomSpeed = 400f;

    const float maxPitch = 80f;
    const float minPitch = -20f;
    const float defaultPitch = 10f;
    Vector3 lastMousePos;
    float screenW;
    float screenH;

    void Start()
    {
        screenW = Screen.width;
        screenH = Screen.height;
        ResetParam();
        SetCamera();
    }

    void Update()
    {
        var z = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance + z * Time.deltaTime, minDistance, maxDistance);
        if (Input.GetMouseButton(0))
        {
            var pos = Input.mousePosition;
            if (!Input.GetMouseButtonDown(0))
            {
                var h = lastMousePos.x - pos.x;
                var v = lastMousePos.y - pos.y;
                yaw -= h * 360 / screenW;
                pitch = Mathf.Clamp(pitch + v * (maxPitch - minPitch) / screenH, minPitch, maxPitch);
            }
            lastMousePos = pos;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            ResetParam();
        }

        SetCamera();
    }
    void ResetParam()
    {
        pitch = defaultPitch;
        distance = defaultDistance;
        yaw = cameraTarget.rotation.eulerAngles.y;
    }
    void SetCamera()
    {
        var q = Quaternion.Euler(pitch, yaw, 0f);
        var vec = q * Vector3.forward * distance;
        transform.position = cameraTarget.position - vec;
        transform.LookAt(cameraTarget);
    }
}
