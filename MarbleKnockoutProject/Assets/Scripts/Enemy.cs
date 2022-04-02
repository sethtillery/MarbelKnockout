using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private Rigidbody enemyRb;
    public GameObject player;
    public float speed = 5;
    public bool isSafe = false;
    public gameManager manager;
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player1");
        manager = GameObject.Find("GameManager").GetComponent<gameManager>();
        enemyRb = GetComponent<Rigidbody>();
        
        timer = manager.timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer = manager.timer;

        if (timer.timeValue > 10.90 && isSafe == true)
            isSafe = true;

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        if (timer.timeValue < 0.00001 && !isSafe)
        {
            Destroy(gameObject);
        }
    }

    // OnTriggerStay is called once per frame for every Collider other that is touching the trigger
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("SafetyDome"))
        {

            isSafe = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SafetyDome"))
        {
            isSafe = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SafetyDome"))
        {
            isSafe = false;
        }
    }
    private void FixedUpdate()
    {
        if(gameManager.instance.gamePlaying && player)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
        }
    }
}
