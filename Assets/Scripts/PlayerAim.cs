using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAim : MonoBehaviour
{
    public GameObject bullet;
    public float period = 1f;
    float nextEvent = 0f;
    public bool needsToReload = false;
    Transform ts;
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        ts = GetComponent<Transform>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mp = Input.mousePosition;

        Vector3 point = mainCamera.WorldToScreenPoint(transform.position);

        Vector2 diff = new Vector2(mp.x - point.x, mp.y - point.y);

        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f,0f,angle);

        if(Input.GetKey("mouse 0") && !needsToReload){
            Instantiate(bullet, ts.position, Quaternion.identity);
            needsToReload = true;
        }

        if(Time.time > nextEvent){
            nextEvent += period;
            needsToReload = false;
        }
    }
}
