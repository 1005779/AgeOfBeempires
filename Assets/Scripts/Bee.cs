using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bee : MonoBehaviour {
    private NavMeshAgent agent;
    private QueenHive queenHive;
    private SelectionManager selectionManager;

    // Variables used for gathereing state
    private GameObject[] flowers; // Array of all the recources
    private GameObject fMin = null;
    private float minDist = Mathf.Infinity;
    Vector3 closestRecource;

    // Variables used for Bees movement and currency
    public float nectar = 0; // Honey Carry over
    public float pollen = 0; // Wax Carry over
    private float maxNextar = 10; // Max Honey carry over
    private float maxPollen = 25; // Max Wax carry over
    public float moveSpeed = 5.0f; 
    private Vector3 destination; // Vector fed to the navmesh agent

    //Animation Variables
    private Animator animator;
    private bool animationLock = false;

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
        selectionManager = GameManager.FindObjectOfType<SelectionManager>();
        queenHive = GameManager.FindObjectOfType<QueenHive>();

        animator = GetComponent<Animator>(); // Get the animator

        agent = GetComponent<NavMeshAgent>();
        destination = transform.position;
    }

    IEnumerator AnimationDelay(PlayerState thisPlayerState, float waitTime)
    {
        playerState = thisPlayerState;
        animationLock = true;
        yield return new WaitForSeconds(waitTime);
        animationLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("WalkSpeed", Mathf.Max(0.01f, agent.velocity.magnitude / agent.speed));

        agent.SetDestination(destination);

        GatherState();
        ReturnState();
        AttackState();

        if (nectar > maxNextar)
        {
            nectar = maxNextar;
            playerState = PlayerState.Return;
        }
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
            nectar += otherObject.gameObject.GetComponent<Resource>().honey;
            pollen += otherObject.gameObject.GetComponent<Resource>().wax;
            Debug.Log("Recource Gained");
            Destroy(otherObject.gameObject);
            playerState = PlayerState.Gather;
        }  
        
        //process to trancfer currency
        if(otherObject.tag == "QueenHive")
        {
            otherObject.GetComponent<QueenHive>().GiveNectar(nectar, pollen);
            Debug.Log("Ca$h Honey" + nectar);
            nectar = 0;
            pollen = 0;
            GatherState();
        }      
    }

    //Find the closest Recource
    public void Resource()
    {
        flowers = GameObject.FindGameObjectsWithTag("Resource");
        Vector3 CurrentPos = transform.position;
        foreach (GameObject f in flowers)
        {
            float dist = Vector3.Distance(f.transform.position, CurrentPos);
            if(dist < minDist)
            {
                fMin = f;
                minDist = dist;
            }
        }
        closestRecource = fMin.transform.position;
    }


    public void GatherState()
    {
        if (playerState == PlayerState.Gather)
        {
            while (nectar < maxNextar && flowers.Length == 0)
            {
                Resource();
                MoveTo(closestRecource);
            }               
        } else
            playerState = PlayerState.Idle;
    }

    public void ReturnState()
    {
        if (playerState == PlayerState.Return)
        {
            MoveTo(queenHive.transform.position);
        }
    }

    public void AttackState()
    {
        if (playerState == PlayerState.Attack)
        {
            animationLock = true;
        }
        else
            animationLock = false;
    }

}