using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameInAn : MonoBehaviour
{
    public Animator animator;

    public GameStateS _state;

    private bool prevState;
    //public AnimationClip AnimationClip;
    //public Animation Animation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_state.GameIsStart)
        {
            animator.SetTrigger("IsGameStart");
        }
        else
        {
            animator.ResetTrigger("IsGameStart");
        }
    }
}
