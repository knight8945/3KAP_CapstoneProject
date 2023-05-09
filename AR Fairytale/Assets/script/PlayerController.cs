using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    Animator animator;
    string animationState = "AnimationState";
    public bool indicater = false;

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
        DontDestroyOnLoad(this.gameObject); // 게임 오브젝트 파괴금지


    }
    void Update()
    {
        // 캐릭터 이동 제어 스크립트(화면으로 보았을때)
        if (Input.GetKey(KeyCode.LeftArrow)) //좌측 이동
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            animator.SetInteger(animationState, (int)States.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) //우측 이동
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            animator.SetInteger(animationState, (int)States.right);
        }
        else if (Input.GetKey(KeyCode.UpArrow)) //위측 이동
        {
            transform.Translate(0, speed * Time.deltaTime,0);
            animator.SetInteger(animationState, (int)States.front);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) //아래측 이동
        {
            transform.Translate(0, -speed * Time.deltaTime,0);
            animator.SetInteger(animationState, (int)States.behind);
        }
        else //정지 상태
        {
            animator.SetInteger(animationState, (int)States.stop);
        }

        // Collider & RigidBody 컴포넌트 사용불가로 인한 대체 Transform 코드
        // main -> 빨간모자 집 이동
        if (playerTransform.position.x > -9.5 && playerTransform.position.x < -8.5 && playerTransform.position.y > 2 && playerTransform.position.y < 3)
        {
            playerTransform.position = new Vector3(-6, 15, 0);
            cameraTransform.position = new Vector3(0f, 20, -1);

        }
        // 빨간모자 집 -> main 이동
        else if (playerTransform.position.x > -6 && playerTransform.position.x < -5.5 && playerTransform.position.y > 15 && playerTransform.position.y < 15.5)
        {
            playerTransform.position = new Vector3(-9f,0.5f, 0);
            cameraTransform.position = new Vector3(-4f, 2, -1);

        }
        //플레이어 main -> forest 이동
        else if (playerTransform.position.x > 2.5 && playerTransform.position.x < 3.5 && playerTransform.position.y == -9)
        {
            playerTransform.position = new Vector3(3, -17.5f, 0);
            cameraTransform.position = new Vector3(3.5f, -20, -1);
            
        }
        //플레이어 forest -> main 이동
        else if (playerTransform.position.x > 2.5 && playerTransform.position.x < 3.5 && playerTransform.position.y > -17 && playerTransform.position.y < -16)
        {
            playerTransform.position = new Vector3(3, -8, 0);
            cameraTransform.position = new Vector3(3.5f, -20, -1);

        }
        //플레이어 forest -> flower 이동
        else if(playerTransform.position.x > 10.5 && playerTransform.position.x < 11.5 && playerTransform.position.y > -23 && playerTransform.position.y < -21)
        {
            playerTransform.position = new Vector3(23.5f, -22.5f, 0);
            cameraTransform.position = new Vector3(30, -20, -1);
        }
        //플레이어 flower -> forest 이동
        else if (playerTransform.position.x > 21 && playerTransform.position.x < 22.8 && playerTransform.position.y > -23 && playerTransform.position.y < -21)
        {
            playerTransform.position = new Vector3(9.7f, -22.5f, 0);
            cameraTransform.position = new Vector3(3f, -20, -1);
        }
        // 플레이어 flower -> shack 이동
        else if(playerTransform.position.x > 38 && playerTransform.position.x < 39 && playerTransform.position.y > -21 && playerTransform.position.y < -20)
        {
            playerTransform.position = new Vector3(52.5f, -22.5f, 0);
            cameraTransform.position = new Vector3(60, -20, -1);
        }
        // 플레이어 shack -> flower 이동
        else if (playerTransform.position.x > 51 && playerTransform.position.x < 52 && playerTransform.position.y > -23 && playerTransform.position.y < -21)
        {
            playerTransform.position = new Vector3(39.5f, -20.5f, 0);
            cameraTransform.position = new Vector3(30, -20, -1);
        }
        // 플레이 shack -> 할머니집 이동
        else if (playerTransform.position.x > 64.5 && playerTransform.position.x < 65.5 && playerTransform.position.y > -20 && playerTransform.position.y < -19)
        {
            playerTransform.position = new Vector3(67, -3, 0);
            cameraTransform.position = new Vector3(73, 0, -1);
        }
        // 플레이어 할머니집 -> shack 이동
        else if (playerTransform.position.x > 66 && playerTransform.position.x < 67 && playerTransform.position.y > -4.5 && playerTransform.position.y < -4)
        {
            playerTransform.position = new Vector3(65, -20.5f, 0);
            cameraTransform.position = new Vector3(60, -20, -1);
        }
        // incameraCharacter 함수 이용
        else
        {
            incameraCharacter();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ChangeScene")
            indicater = true;
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
 