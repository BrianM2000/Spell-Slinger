using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int speed;
    GameObject player;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Debug.Log(player.transform.position.ToString() + " " + transform.position.ToString());
        dir = (player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (dir * speed * Time.deltaTime);
        
        if(Vector3.Distance(player.transform.position, transform.position) > 100){
            Destroy(gameObject);
        } 
    }

    void OnTriggerEnter2D(Collider2D collider){
        Destroy(gameObject);
    }

}
