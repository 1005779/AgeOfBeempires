using UnityEngine;
using System.Collections;

public class WarriorBeeAnimations : MonoBehaviour {

    private WarriorBee warriorBee;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        warriorBee = GetComponentInParent<WarriorBee>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        // Animation Switch System
        switch (warriorBee.playerState)
        {
            case WarriorBee.PlayerState.Attack:
                animator.Play("WBAttack");
                break;

            case WarriorBee.PlayerState.Idle:
                animator.Play("WBIdle");
                break;

            case WarriorBee.PlayerState.Walk:
                animator.Play("WBMove");
                break;
        }
	
	}
}
