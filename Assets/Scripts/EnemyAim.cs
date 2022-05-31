using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    public GameObject bullet;
    public float period = 1f;
    float nextEvent = 0f;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 diff = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);

        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f,0f,angle);

        if(Time.time > nextEvent){
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextEvent += period;
        }
        
    }
}
