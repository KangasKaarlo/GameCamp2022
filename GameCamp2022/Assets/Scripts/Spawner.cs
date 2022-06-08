using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //NonReorderable is here just to fix a bug in inspector
    [NonReorderable]
    public SpawnSerializable[] levelOne;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < levelOne.Length; i++)
        {
            for (int y = 0; y < levelOne[i].amount; y++)
            {
                Instantiate(levelOne[i].Enemy, this.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(levelOne[i].delay);
            }
        }
    }
}
