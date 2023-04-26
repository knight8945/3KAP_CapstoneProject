using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    Animator animator;
    string animationState = "AnimationState";

    enum States
    {
        right = 1,
        left = 2,
        behind = 3,
        front = 4,
        stop = 5
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            animator.SetInteger(animationState, (int)States.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            animator.SetInteger(animationState, (int)States.right);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime,0);
            animator.SetInteger(animationState, (int)States.front);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime,0);
            animator.SetInteger(animationState, (int)States.behind);
        }
        else
        {
            animator.SetInteger(animationState, (int)States.stop);
        }
    }

 
}