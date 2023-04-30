using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    Animator animator;
    string animationState = "AnimationState";

    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    Transform cameraTransform;

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
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();

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
        // main -> 빨간모자 집 이동
        if (playerTransform.position.y < 2.8 && playerTransform.position.y > 2 && playerTransform.position.x > -9 && playerTransform.position.x < -8)
        {
            playerTransform.position = new Vector3(-6, 15, 0);
            cameraTransform.position = new Vector3(0f, 20, -1);

        }
        //플레이어 main -> forest 이동
        else if (playerTransform.position.y == -9 && playerTransform.position.x > 2.5 && playerTransform.position.x < 3.5)
        {
            playerTransform.position = new Vector3(3, -16, 0);
            cameraTransform.position = new Vector3(3.5f, -20, -1);
            
        }
       //플레이어 forest -> flower 이동
       else if(playerTransform.position.x < 12 && playerTransform.position.x >11.7 && playerTransform.position.y > -23.5 && playerTransform.position.y < -22)
        {
            playerTransform.position = new Vector3(22, -22, 0);
            cameraTransform.position = new Vector3(30, -20, -1);
        }
       // 플레이어 flower -> shack 이동
       else if(playerTransform.position.x < 39 && playerTransform.position.x > 38.7 && playerTransform.position.y > -21.5 && playerTransform.position.y < -20)
        {
            playerTransform.position = new Vector3(51, -22, 0);
            cameraTransform.position = new Vector3(60, -20, -1);
        }
        // 플레이 shack -> 할머니집 이동
        else if (playerTransform.position.x < 65.5 && playerTransform.position.x > 64.5 && playerTransform.position.y > -19.5 && playerTransform.position.y < -19)
        {
            playerTransform.position = new Vector3(67, -5, 0);
            cameraTransform.position = new Vector3(73, 0, -1);
        }
        else
        {
            incameraCharacter();
        }
    }

    //캐릭터가 카메라 화면에서 못 벗어나는 코드
    void incameraCharacter()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 0.9f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
        
}
 