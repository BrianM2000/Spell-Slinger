using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseFollower : MonoBehaviour
{
    // Start is called before the first frame update
    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        point.z = 0;
        transform.position = point;
    }
}
