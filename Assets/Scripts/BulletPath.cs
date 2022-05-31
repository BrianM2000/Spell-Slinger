using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletPath : MonoBehaviour
{
    public GameObject source;
    public int speed;
    Vector3 start;
    Vector3 aim;
    Vector3 dir;
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.Find("Player");

        mainCamera = Camera.main;

        start = source.gameObject.transform.GetChild(0).position;

        aim = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        aim.z = 0;

        dir = (aim - start).normalized;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (dir * speed * Time.deltaTime);
        
        if(Vector3.Distance(source.transform.position, transform.position) > 100){
            Destroy(gameObject);
        } 
    }
    void OnTriggerEnter2D(Collider2D collider){
        Destroy(gameObject);
    }
    
}
