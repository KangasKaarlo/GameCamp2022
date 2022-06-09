using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public float speed;
    private WayPoints Wpoints;
    private int waypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<WayPoints>();
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


    }
}
