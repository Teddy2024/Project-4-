using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private string currentState;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //anim.Play("move");
    }

   
    void ChangeAnimationState(string newState)
    {
        if(currentState == newState)
        {
            return;
        }
        anim.Play(newState);
        currentState = newState;
    }
}
