using UnityEngine;
using System.Collections;

public class WaspAnimation : MonoBehaviour {

    Wasp wasp;

    Animator animator;

	// Use this for initialization
	void Start () {
        wasp = GetComponentInParent<Wasp>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //Animation Switch System
        switch (wasp.playerState)
        {
            case Wasp.PlayerState.Idle:
                animator.Play("WaspIdle_Animation");
                break;

            case Wasp.PlayerState.Attack:
                animator.Play("WaspAttack_Animation");
                break;                           
        }
    }
}
