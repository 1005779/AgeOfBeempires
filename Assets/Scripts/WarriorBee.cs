using UnityEngine;
using System.Collections;

public class WarriorBee : MonoBehaviour {

    private GameManager gameManager;
    // wasp goes Here \\
    private DroneHive droneHive;
    private NavMeshAgent agent;

    public float moveSpeed = 20;
    public float health = 2; // Hit it can take
    public float Damage = 20; // damage to enemy
    private Vector3 destination; // Vector fed to the navmesh agent

    // Animation 
    private Animator animator;
    public bool animationLock = false;

    public enum PlayerState
    {
        Idle,
        Walk,
        Attack
    }

    public PlayerState playerState;

	// Use this for initialization
	void Start () {
        gameManager = GameManager.FindObjectOfType<GameManager>();
        droneHive = GameManager.FindObjectOfType<DroneHive>();
        agent = GetComponent<NavMeshAgent>();
        destination = transform.position;

        animator = GetComponent<Animator>();
	}

    IEnumerator AnimationDelay(PlayerState thisPlayerState, float waitTime)
    {
        playerState = thisPlayerState;
        animationLock = true;
        yield return new WaitForSeconds(waitTime);
        animationLock = false;
    }

    // Update is called once per frame
    void Update () {

        agent.SetDestination(destination);

        if (destination == transform.position && animationLock == false)
            playerState = PlayerState.Idle;

        Seppuku();  // Bees Die When The STING of get hurt by wasps

    }

    public void MoveTo(Vector3 newDestination)
    {
        playerState = PlayerState.Walk;
        destination = newDestination;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wasp")
        {
            StartCoroutine(AnimationDelay(PlayerState.Attack, 0.75f));
            // Run TakeDamage on wasp
            //other.GetComponent<Wasp>.TakeDamage(Damage);
            if(  animationLock != true)
            {
                health = 0;
            }
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;  
    }

    void Seppuku()
    {
        if (health <= 0)
        {
            // Seppuku Sound?
            Destroy(this.gameObject);
        }
    }
    
}
