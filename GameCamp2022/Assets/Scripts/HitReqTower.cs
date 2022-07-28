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
    public ParticleSystem Shoot;
     public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
           if (Vector3.Distance(enemy.transform.position, this.transform.position) < 2.5)
            {
                targets = targets.Concat(new GameObject[] { enemy }).ToArray();
            }
        }

      
    }

    // Update is called once per frame
    void Update()
    {
        
        if (targets.Length > 0)
        {
           if (targets[0] != null) {

                //Looking at the target
                var lookPos = targets[0].transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);


                //Shooting
                if (fireCountdown <= 0)
                {
                    anim.SetTrigger("Fire");
                    Shoot.Play();
                    targets[0].GetComponent<Enemy>().health -= 1;
                    if (targets[0].GetComponent<Enemy>().health <= 0)
                    {
                        targets = targets.Except(new GameObject[] { targets[0] }).ToArray();
                    }
                    fireCountdown = fireRate;
                }
            }
           else
            {
                for (int i = 0; i < targets.Length - 1; i++)
                {
                    targets[i] = targets[i + 1];
                }
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

