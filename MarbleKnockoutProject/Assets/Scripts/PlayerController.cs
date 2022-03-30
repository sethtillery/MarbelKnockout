using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // private GameObject focalPoint;
    private Rigidbody playerRb;
    public float speed = 5;
    public bool isSafe = false;
    private Vector3 powerUpOffset;
    public bool hasPowerup = false;
    public float powerUpStrength = 15;
    public float powerUpTime = 5;
    public GameObject powerUpIndicator;
    
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        powerUpOffset = powerUpIndicator.transform.position;
        timer = GameObject.Find("Timer").GetComponentInChildren<Timer>();
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        if (timer.timeValue < 0.01 && !isSafe)
        {
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float sideInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.forward * forwardInput * speed);
        playerRb.AddForce(Vector3.right * sideInput * speed);
        powerUpIndicator.transform.position = transform.position + powerUpOffset;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SafetyDome"))
        {
            isSafe = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            StartCoroutine(PowerupCountdownRoutine());
            powerUpIndicator.gameObject.SetActive(true); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SafetyDome"))
        {
            isSafe = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player2") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPLayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPLayer * powerUpStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerUpTime);
        hasPowerup = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
}
