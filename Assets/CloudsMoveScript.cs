using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone = -66;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone) 
            Destroy(gameObject);
    }
}
