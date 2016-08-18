using UnityEngine;
using System.Collections;

public class BeeAnimation : MonoBehaviour {

    Bee bee;

    Animator animationComponent;

	// Use this for initialization
	void Start () {
        bee = GetComponent<Bee>();
        animationComponent = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {

        //Animation Switch System
        switch (bee.playerState)
        {

            case Bee.PlayerState.Idle:
                animationComponent.Play("BeeIdleAnimation");
                break;

            case Bee.PlayerState.Move:
                animationComponent.Play("BeeMoveAnimation");
                break;

            case Bee.PlayerState.Gather:
                animationComponent.Play("BeeMoveAnimation");
                break;

            case Bee.PlayerState.Return:
                animationComponent.Play("BeeMoveAnimation");
                break;
                            
        }
    }
}
