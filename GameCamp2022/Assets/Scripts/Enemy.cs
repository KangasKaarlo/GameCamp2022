using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;

    private WayPoints Wpoints;
    private int waypointIndex;
    private int wayPointDecider;

    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {

        mainCamera = GameObject.Find("PixelCamera");

        wayPointDecider = Random.Range (1,10);
        if (wayPointDecider <= 5){
            Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<WayPoints>();
        } else {
            Wpoints = GameObject.FindGameObjectWithTag("Waypoints2nd").GetComponent<WayPoints>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        transform.position = Vector3.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, Wpoints.waypoints[waypointIndex].position)< 0.1f)
        {
            
            if (waypointIndex < Wpoints.waypoints.Length - 1)
            {
                waypointIndex++;
            }else{
                Debug.Log("End Reached");
            }
        }

        //Dying
        if(health == 0)
        {
            Destroy(transform.parent.gameObject);
            Destroy(this);
        }

        //Damaging the player
        if(this.transform.position.x > 11)
        {
            mainCamera.GetComponent<PlayerStatus>().health -= 1;
            Destroy(transform.parent.gameObject);
            Destroy(this);
        }
    }
}
