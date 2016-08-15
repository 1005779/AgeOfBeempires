using UnityEngine;
using System.Collections;

public class BeeAnimation : MonoBehaviour {

    Bee bee;

    Animation animationComponent;

	// Use this for initialization
	void Start () {
        bee = GetComponent<Bee>();
        animationComponent = GetComponent<Animation>();	
	}
	
	// Update is called once per frame
	void Update () {

        //Animation Switch System
        switch (bee.playerState)
        {

            case Bee.PlayerState.Idle:
                animationComponent.Play("Idle");
                break;

            case Bee.PlayerState.Move:
                animationComponent.Play("Idle");
                break;

            case Bee.PlayerState.Gather:
                animationComponent.Play("Idle");
                break;

            case Bee.PlayerState.Return:
                animationComponent.Play("Idle");
                break;

            case Bee.PlayerState.Attack:
                animationComponent.Play("Attack");
                break;
        }
    }
}
