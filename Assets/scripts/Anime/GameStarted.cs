using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameInAn : MonoBehaviour
{
    public Animator animator;
    //public AnimationClip AnimationClip;
    //public Animation Animation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("IsGameStart");
        }
    }
}
