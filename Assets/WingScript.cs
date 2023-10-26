using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingScript : MonoBehaviour
{
    public Rigidbody2D wing;
    public float flapStrength;
    public BirdScript bird;
    public bool up = true;
    public float moveWingRate;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        flapStrength = bird.flapStrength;
        moveWingRate = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < moveWingRate) 
        {
            timer += Time.deltaTime;
        } 
        else 
        {
            moveWing(); 
            timer = 0;
        } 

         if (Input.GetKeyDown(KeyCode.Space))
            wing.velocity = Vector2.up * flapStrength;
    }

    void moveWing() 
    {
        if (up)
        {
            wing.transform.eulerAngles = new Vector3(
                wing.transform.eulerAngles.x + 65,
                wing.transform.eulerAngles.y,
                wing.transform.eulerAngles.z
            );

            up = false;
        }
        else
        {
            wing.transform.eulerAngles = new Vector3(
                wing.transform.eulerAngles.x - 65,
                wing.transform.eulerAngles.y,
                wing.transform.eulerAngles.z
            );

            up = true;
        }
    }
}
