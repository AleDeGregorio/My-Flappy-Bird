using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        flapStrength = 80;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (birdBody.position.y <= -40 || birdBody.position.y >= 40)
        {
            logic.gameOver();
            birdIsAlive = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            birdBody.velocity = Vector2.up * flapStrength;   
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
