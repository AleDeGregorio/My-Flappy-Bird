using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawnerScript : MonoBehaviour
{
    public GameObject clouds;
    public float spawnRate;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 1;
        spwanClouds();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) 
        {
            timer += Time.deltaTime;
        } 
        else 
        {
            spwanClouds(); 
            timer = 0;
        } 
    }

    void spwanClouds()
    {
        float lowestPoint = -22;
        float heighestPoint = 20;

        Instantiate(clouds, new Vector3(transform.position.x, Random.Range(lowestPoint, heighestPoint), 0), transform.rotation);
    }
}
