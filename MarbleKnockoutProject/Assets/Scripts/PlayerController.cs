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
    public float forwardInput;
    public float sideInput;
    public gameManager manager;
   // public GameObject powerUpIndicator;

    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(powerUpIndicator, new Vector3(0, 0, 0), powerUpIndicator.transform.rotation);
       // gameObject.transform.GetChild(0).gameObject.SetActive(false);
        manager = GameObject.Find("GameManager").GetComponent<gameManager>();
        playerRb = GetComponent<Rigidbody>();
       // powerUpOffset = powerUpIndicator.transform.position;
        timer = manager.timer;
    }

    private void Update()
    {
        timer = manager.timer;

        if (timer.timeValue > 10.90 && isSafe == true)
            isSafe = true;

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            manager.musicList[4].Play();
        }

        if (timer.timeValue < 0.00001 && !isSafe)
        {
            Destroy(gameObject);
            manager.musicList[4].Play();
        }
    }

    private void FixedUpdate()
    {
        if(gameManager.instance.gamePlaying)
            GetPlayerInput();        
    }

    private void GetPlayerInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        sideInput = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.W))
            playerRb.AddForce(Vector3.forward * speed);

        if (Input.GetKey(KeyCode.A))
            playerRb.AddForce(-Vector3.right * speed);

        if (Input.GetKey(KeyCode.S))
            playerRb.AddForce(-Vector3.forward * speed);

        if (Input.GetKey(KeyCode.D))
            playerRb.AddForce(Vector3.right * speed);

        
        //powerUpIndicator.transform.position = transform.position + powerUpOffset;  
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
        if (other.CompareTag("Powerup"))
        {
            manager.musicList[5].Play();
            Destroy(other.gameObject);
            hasPowerup = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            manager.musicList[2].Play();

        }
        if (collision.gameObject.CompareTag("player2") && hasPowerup)
        {
            manager.musicList[3].Play();
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPLayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPLayer * powerUpStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerUpTime);
        hasPowerup = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
