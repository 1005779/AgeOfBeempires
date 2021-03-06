﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wasp : MonoBehaviour {
    private NavMeshAgent agent;
    public float moveSpeed = 5.0f;
    private Vector3 destination; // Vector fed to the navmesh agent

    Vector3 currentPos;
    private GameObject[] Bees;
    private GameObject bMin = null;
    private float minDistA = Mathf.Infinity;
    private Vector3 closestTarget;

    private GameObject[] WarBee;
    private GameObject wMin = null;
    private float minDistB = Mathf.Infinity;
    
    private GameObject QueenHive;

    public float health = 100;
    public float damage = 1;

    private Animator animator;
    private bool animLock = false;

    public enum PlayerState
    {
        Idle,
        Attack
    }
    public PlayerState playerState;

	// Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>(); // Get the animator

        agent = GetComponent<NavMeshAgent>();
        destination = transform.position;
    }
    IEnumerator AnimationDelay(PlayerState thisPlayerState, float waitTime)
    {
        playerState = thisPlayerState;
        animLock = true;
        yield return new WaitForSeconds(waitTime);
        animLock = false;
    }

    // Update is called once per frame
    void Update () {
        if (health <= 0)
            Destroy(this.gameObject);

        agent.SetDestination(destination);

        NextTarget();
    }

    public void MoveTo(Vector3 newDestination)
    {
        playerState = PlayerState.Idle;
        destination = newDestination;
    }

    public void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Bee"))
        {
            Other.GetComponent<Bee>().TakeDamage(damage);
        }

        if (Other.CompareTag("WarriorBee"))
        {
            Other.GetComponent<WarriorBee>().TakeDamage(damage);
        }

        if (Other.CompareTag("QueenHive"))
        {
            Other.GetComponent<QueenHive>().TakeDamage(damage);
        }
    }

    void NextTarget()
    {
        Bees = GameObject.FindGameObjectsWithTag("Bee");
        currentPos = transform.position;
        foreach(GameObject b in Bees)
        {
            float dist = Vector3.Distance(b.transform.position, currentPos);
            if (dist < minDistA)
            {
                bMin = b;
                minDistA = dist;
            }
        }
        closestTarget = bMin.transform.position;
        
        if( Bees.Length == 0)
        {
            WarBee = GameObject.FindGameObjectsWithTag("WarriorBee");
            currentPos = transform.position;
            foreach (GameObject WB in WarBee)
            {
                float dist = Vector3.Distance(WB.transform.position, currentPos);
                if (dist < minDistB)
                {
                    wMin = WB;
                    minDistB = dist;
                }
            }
            closestTarget = wMin.transform.position;
        }
        if(Bees.Length == 0 && WarBee.Length == 0)
        {
            closestTarget = QueenHive.transform.position;
        }

        MoveTo(closestTarget);
    }


    public void TakeDamage(float Damage)
    {
        health -= Damage * Time.deltaTime;
    }
}
