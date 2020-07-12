using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform followTransform;
    public BoxCollider2D mapBounds;

    private float xMin, xMax, yMin, yMax;
    private float camX, camY;
    private float camOrthSize;
    private float cameraRatio;
    private Camera mainCam;

    void Awake()
    {
        // Boundaries the camera doesn't pass
        yMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.y;
        xMin = mapBounds.bounds.min.y;
        mainCam = GetComponent<Camera>();
        camOrthSize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthSize) / 3.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthSize, yMax - camOrthSize);
        camX = Mathf.Clamp(followTransform.position.x, xMin + cameraRatio - 1f, xMax - cameraRatio + 1f);
        this.transform.position = new Vector3(camX, camY, this.transform.position.z);
    }
}
