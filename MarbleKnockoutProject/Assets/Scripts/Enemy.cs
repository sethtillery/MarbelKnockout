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
    public SpawnManager spawn;
    public PlayerController player1;
    public Vector3 playerDirection;
    public Vector3 domeDirection;
    public bool shouldLookForPlayer = true;


    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>(); 
        player1 = GameObject.FindGameObjectWithTag("player1").GetComponent<PlayerController>();
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

        if (transform.position.y < -15)
        {
            Destroy(gameObject);
            manager.musicList[4].Play();
        }

        if (timer.timeValue < 0.00001 && !isSafe)
        {
            if (gameObject.GetComponent<Renderer>().sharedMaterial == spawn.useMaterialList[0])
                Instantiate(spawn.particleList[0], transform.position, transform.rotation);

            if (gameObject.GetComponent<Renderer>().sharedMaterial == spawn.useMaterialList[1])
                Instantiate(spawn.particleList[1], transform.position, transform.rotation);

            if (gameObject.GetComponent<Renderer>().sharedMaterial == spawn.useMaterialList[2])
                Instantiate(spawn.particleList[2], transform.position, transform.rotation);

            if (gameObject.GetComponent<Renderer>().sharedMaterial == spawn.useMaterialList[3])
                Instantiate(spawn.particleList[3], transform.position, transform.rotation);

            if (gameObject.GetComponent<Renderer>().sharedMaterial == spawn.useMaterialList[4])
                Instantiate(spawn.particleList[4], transform.position, transform.rotation);

            if (gameObject.GetComponent<Renderer>().sharedMaterial == spawn.useMaterialList[5])
                Instantiate(spawn.particleList[5], transform.position, transform.rotation);

            if (gameObject.GetComponent<Renderer>().sharedMaterial == spawn.useMaterialList[6])
                Instantiate(spawn.particleList[6], transform.position, transform.rotation);

            Destroy(gameObject);
            manager.musicList[4].Play();
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
        if(manager.gamePlaying && shouldLookForPlayer)
        playerDirection = (player.transform.position - transform.position).normalized;

        if(manager.gamePlaying)
             domeDirection = (GameObject.Find("SafteyDome(Clone)").transform.GetChild(0).transform.position - transform.position).normalized;

        if(gameManager.instance.gamePlaying && player1.isSafe)
        {
            enemyRb.AddForce(playerDirection * speed);
        }
        else
            enemyRb.AddForce(domeDirection * speed);
        
    }
}
