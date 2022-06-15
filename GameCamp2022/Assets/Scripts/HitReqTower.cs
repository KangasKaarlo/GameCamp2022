using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HitReqTower : MonoBehaviour
{
    public float fireRate;
    public float fireCountdown;
    public GameObject[] targets;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        
        if (targets.Length > 0)
        {
            if(fireCountdown <= 0)
            {
                targets[0].GetComponent<Enemy>().health -= 1;
                if (targets[0].GetComponent<Enemy>().health <= 0)
                {
                    targets = targets.Except(new GameObject[] { targets[0] }).ToArray();
                }
                fireCountdown = fireRate;
            }
        }
        fireCountdown -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            targets = targets.Concat(new GameObject[] { other.gameObject }).ToArray();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Remove exiting object from possible targets
        targets = targets.Except(new GameObject[] { other.gameObject }).ToArray();
    }
}

