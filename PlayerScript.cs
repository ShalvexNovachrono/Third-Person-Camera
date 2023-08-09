using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Rigidbody rb;

    public float horizontal;
    public float vertical;
    public Vector3 movementDir;

    public float speed = 20;

    public Transform core;
    public Transform cameraBody;

    public float Sensitivity = 7f;
    public Vector3 CoreRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        movementDir = transform.forward * vertical + transform.right * horizontal;

        rb.AddForce(movementDir * speed, ForceMode.Force);

        CoreRotation.x += (Input.GetAxis("Mouse Y") * -1) * Sensitivity;
        CoreRotation.y += Input.GetAxis("Mouse X") * Sensitivity;

        CoreRotation.x = Mathf.Clamp(CoreRotation.x, -45, 75);

        core.rotation = Quaternion.Euler(CoreRotation.x, CoreRotation.y, CoreRotation.z);

        cameraBody.localPosition = new Vector3(0, 0.9f, cameraBody.localPosition.z + Input.mouseScrollDelta.y);

    }
}
