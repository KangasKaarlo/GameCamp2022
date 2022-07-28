using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;
    public int moneyGainedOnDeath;

    private WayPoints Wpoints;
    private int waypointIndex;
    private int wayPointDecider;

    public GameObject mainCamera;

    public ParticleSystem Blood;
    public Animator anim;
    private bool DeathAnimationPlaying = false;
    public AudioClip squish;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        mainCamera = GameObject.Find("PixelCamera");

        anim = GetComponentInChildren<Animator>();

        audioSource = GetComponent<AudioSource>();

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


        //turning towards waypoint
        var direction = Wpoints.waypoints[waypointIndex].position - transform.position;
        direction.y = 0;
        var rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3);
        
    
        

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
        if (health == 0)
        {
            StartCoroutine(Death());
        }

        //Damaging the player
        if(this.transform.position.x > 11)
        {
            mainCamera.GetComponent<PlayerStatus>().health -= 1;
            Destroy(transform.parent.gameObject);
            Destroy(this);
        }
        IEnumerator Death()
        {
           speed = 0.1f;
        if (DeathAnimationPlaying == false)
            {
                Blood.Play();
                DeathAnimationPlaying = true;
                audioSource.PlayOneShot(squish);
                anim.SetTrigger("Death");
            }
           yield return new WaitForSeconds(1.5f);
           mainCamera.GetComponent<PlayerStatus>().money += moneyGainedOnDeath;
           Destroy(transform.parent.gameObject);
           Destroy(this);
        }

    }
}
