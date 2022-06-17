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
    // Start is called before the first frame update
    void Start()
    {
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
        //this.transform.position += new Vector3(5 * Time.deltaTime,0,0); 
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

        //TEMP to test Dying
        if(health == 0)
        {
            speed = 0;
        }

    }
}
