using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject cameraMovement;
    private Transform cameraTransform;
    private Vector3 offset = new Vector3(0f, 0f, -14f);

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform.position = cameraMovement.transform.position + offset;
    }
}
