using UnityEngine;
using System.Collections;

public class Bee : MonoBehaviour {
    private NavMeshAgent agent;

    private GameObject[] recources;

    private float nectar = 0;
    private float maxNextar = 10;

    public float moveSpeed = 5.0f;

    private Vector3 destination;

    //Animation Variables

    // State Variables
    public enum PlayerState
    {
        Idle,
        Gather,
        Return,
        Attack,
        Move
    }

    public PlayerState playerState;

    // Use this for initialization
    void Start()
    {
        playerState = PlayerState.Idle;
        agent = GetComponent<NavMeshAgent>();
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destination);

        StateMode();
    }

    public void MoveTo(Vector3 newDestination)
    {
        playerState = PlayerState.Move;
        destination = newDestination;
    }

   public void OnTriggerEnter(Collider otherObject)
    {
        //collecting the currency
        if (otherObject.tag == "Resource" && nectar < maxNextar)
        {
            nectar += 2;
            Debug.Log("Recource Gained");
            playerState = PlayerState.Gather;             
            //remove from array
        }  
        
        //process to trancfer currency
        if(otherObject.tag == "QueenHive")
        {
            otherObject.GetComponent<QueenHive>().GiveNectar(nectar);
            Debug.Log("Ca$h Honey" + nectar);
            nectar = 0;

            playerState = PlayerState.Idle;
        }      
    }

    public void RecourceCheck()
    {
        recources = GameObject.FindGameObjectsWithTag("Recource");
    }

    public void StateMode()
    {
        if(playerState == PlayerState.Gather)
        {
            RecourceCheck();
            while(nectar < maxNextar)
            {
                //select closest resource
                // go to Recourse
            } 
        }
    }

}
