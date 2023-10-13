using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 3;
    private float timer = 0;
    public float heightOffset = 15;

    // Start is called before the first frame update
    void Start()
    {
        spwanPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) 
        {
            timer += Time.deltaTime;
        } else 
        {
            spwanPipe(); 
            timer = 0;
        } 
    }

    void spwanPipe() 
    {
        float lowestPoint = transform.position.y - heightOffset;
        float heighestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, heighestPoint), 0), transform.rotation); 
    }
}
