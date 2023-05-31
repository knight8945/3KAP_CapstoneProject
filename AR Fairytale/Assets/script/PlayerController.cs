using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    Animator animator;
    string animationState = "AnimationState";
    public GameManager manager;
    public QuizManager quizmanager;
    Vector3 lookDirection;
    public GameObject Player;
    public GameObject Player2;
    public GameObject SceneChanger;
    public GameObject wolf2;
    public GameObject wolf3;
    public GameObject Player3;
    public GameObject RealGM;
    public Transform playerTransform;
    public Transform cameraTransform;
    public string target;
    GameObject scanObject;

    //Mobile Key Set
    int up_Value;
    int down_Value;
    int left_Value;
    int right_Value;
    bool up_Down;
    bool down_Down;
    bool left_Down;
    bool right_Down;

    enum States
    {
        right = 1,
        left = 2,
        behind = 3,
        front = 4,
        idle_right = 5,
        idle_left = 6,
        idle_behind = 7,
        idle_front = 8,

        hunter_right = 11,
        hunter_left = 12,
        hunter_behind = 13,
        hunter_front = 14,
        hunter_idle_right = 15,
        hunter_idle_left = 16,
        hunter_idle_behind = 17,
        hunter_idle_front = 18
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "ChangeScene")
            SceneChanger.GetComponent< SceneChanger> ().ChangeScene(1);

        if (collision.transform.tag == "ChangeEnding")
            SceneChanger.GetComponent<SceneChanger>().ChangeScene(2);
        if (collision.transform.tag == "ChangeTree")
            SceneChanger.GetComponent<SceneChanger>().ChangeScene(4);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 1;
                up_Down = true;
                break;
            case "D":
                down_Value = -1;
                down_Down = true;
                break;
            case "L":
                left_Value = -1;
                left_Down = true;
                break;
            case "R":
                right_Value = 1;
                right_Down = true;
                break;
            case "A":
                if (scanObject != null)
                    manager.Action(scanObject);
                break;
            case "C":
                manager.SubMenuActive();
                break;
        }
    }
    
    public void ButtonUp(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 0;
                up_Down = false;
                break;
            case "D":
                down_Value = 0;
                down_Down = false;
                break;
            case "L":
                left_Value = 0;
                left_Down = false;
                break;
            case "R":
                right_Value = 0;
                right_Down = false;
                break;
        }
    }
    void Update()
    {

        if (manager.playerswitch == 1)
        {
            Player.transform.position = new Vector3(55, -43, 0);
            Player.SetActive(false);
            Player2.SetActive(true);
            playerTransform = GameObject.Find("Player2").GetComponent<Transform>();
        }
        if (manager.count == 1)
        {
            manager.talkPanel.SetActive(true);
            manager.isAction = true;
            manager.talkText.text = "빨리 할머니집으로 가야겠어!!";
            Invoke("CountUp", 2.0f);
            manager.count = 2;
        }
        if (manager.count == 3)
        {
            manager.talkPanel.SetActive(true);
            manager.isAction = true;
            manager.talkText.text = "할머니? 어디 계세요? 아! 침대에 계시구나";
            Invoke("CountUp", 2.0f);
            manager.count = 4;
        }
        if (manager.playerswitch == 1 && manager.count == 7 && manager.wolfquest == 0)
        {
            manager.talkPanel.SetActive(true);
            manager.isAction = true;
            manager.wolf.SetActive(false);
            manager.wolf_0.SetActive(true);
            manager.talkText.text = "한편 사냥꾼 아저씨가 순찰 중 이상한 것을 발견했어요!";
            playerTransform.position = new Vector3(54f, -22f, 0);
            cameraTransform.position = new Vector3(60, -20, -1);
            Invoke("CountUp", 2.0f);
            manager.count = 8;
        }
        if (manager.wolfquest == 1 && manager.count == 8)
        {
            manager.talkPanel.SetActive(true);
            manager.isAction = true;
            manager.wolf.SetActive(false);
            manager.wolf_0.SetActive(true);
            manager.talkText.text = "늑대의 발자국을 쫒아가보자!";
            //Invoke("CountUp", 2.0f);
            playerTransform.position = new Vector3(60, -38, 0);
            cameraTransform.position = new Vector3(60, -38, -1);
            manager.count = 9;

        }
        else if(manager.wolfquest == 2 && manager.count == 11)
        {
            Player.SetActive(true);
            Player.transform.position = new Vector3(89, -38, 0);
            Player.SetActive(false);
            playerTransform.position = new Vector3(89, -35, 0);
            cameraTransform.position = new Vector3(88, -38, -1);
            manager.count = 12;
           
        }
        if (manager.count == 10 && manager.wolfquest != 7)
        {
            playerTransform.position = new Vector3(60, -38, 0);
            cameraTransform.position = new Vector3(60, -38, -1);
            manager.talkPanel.SetActive(false);
            manager.isAction = false;
            manager.count = 11;
        }
        else if (manager.wolfquest == 1 && manager.count == 9)
        {
            manager.talkPanel.SetActive(false);
            playerTransform.position = new Vector3(60, -38, 0);
            cameraTransform.position = new Vector3(60, -38, -1);
            Invoke("CountDown", 2.0f);
        }
        if(manager.wolfquest == 7 && manager.count != 12)
        {
            manager.talkPanel.SetActive(true);
            manager.talkText.text = "잠시 후 잠에서 깬 늑대가 오두막 밖으로 나왔어요.";
            Invoke("CountDown", 3.0f);
            manager.wolf_0.SetActive(false);
            Player.SetActive(true);
            Player.transform.position = new Vector3(60, -25, 0);
            Player.SetActive(false);
            playerTransform.position = new Vector3(63f, -22f, 0);
            cameraTransform.position = new Vector3(60, -20, -1);
            Invoke("CountDraw", 3.0f);
            //manager.wolfquest =7 and manager.count = 10
        }

        // 캐릭터 이동 제어 스크립트(화면으로 보았을때)
        if (manager.isAction ? false : Input.GetKey(KeyCode.LeftArrow) || left_Down) //좌측 이동
        {
            if(!left_Down)
                transform.Translate(-speed * Time.deltaTime+ left_Value, 0, 0);
            else
                transform.Translate((-speed * Time.deltaTime + left_Value) / 5, 0, 0);
            animator.SetInteger(animationState, (int)States.left);
            if (manager.playerswitch == 1)
                animator.SetInteger(animationState, (int)States.hunter_left);
            lookDirection = Vector3.left;
        }
        else if (manager.isAction ? false : Input.GetKey(KeyCode.RightArrow) || right_Down) //우측 이동
        {
            if(!right_Down)
                transform.Translate(speed * Time.deltaTime + right_Value, 0, 0);
            else
                transform.Translate((speed * Time.deltaTime + right_Value) / 5, 0, 0);
            animator.SetInteger(animationState, (int)States.right);
            if (manager.playerswitch == 1)
                animator.SetInteger(animationState, (int)States.hunter_right);
            lookDirection = Vector3.right;
        }
        else if (manager.isAction ? false : Input.GetKey(KeyCode.UpArrow) || up_Down)//위측 이동
        {
            if(!up_Down)
                transform.Translate(0, speed * Time.deltaTime + up_Value,0);
            else
                transform.Translate(0, (speed * Time.deltaTime + up_Value) / 5, 0);
            animator.SetInteger(animationState, (int)States.front);
            if (manager.playerswitch == 1)
                animator.SetInteger(animationState, (int)States.hunter_front);
            lookDirection = Vector3.back;
        }
        
        else if (manager.isAction ? false : Input.GetKey(KeyCode.DownArrow) || down_Down) //아래측 이동
        {
            if(!down_Down)
                transform.Translate(0, -speed * Time.deltaTime + down_Value, 0);
            else
                transform.Translate(0, (-speed * Time.deltaTime + down_Value) / 5, 0);
            animator.SetInteger(animationState, (int)States.behind);
            if (manager.playerswitch == 1)
                animator.SetInteger(animationState, (int)States.hunter_behind);
            lookDirection = Vector3.forward;
        }
        // 캐릭터 idle 상태
        else //정지 상태
        {
            if (lookDirection ==  Vector3.right)
            {
                animator.SetInteger(animationState, (int)States.idle_right);
                if (manager.playerswitch == 1)
                    animator.SetInteger(animationState, (int)States.hunter_idle_right);
            }
            else if(lookDirection == Vector3.left)
            {
                animator.SetInteger(animationState, (int)States.idle_left);
                if (manager.playerswitch == 1)
                    animator.SetInteger(animationState, (int)States.hunter_idle_left);
            }
            else if (lookDirection == Vector3.back)
            {
                animator.SetInteger(animationState, (int)States.idle_front);
                if (manager.playerswitch == 1)
                    animator.SetInteger(animationState, (int)States.hunter_idle_front);
            }
            else if (lookDirection == Vector3.forward)
            {
                animator.SetInteger(animationState, (int)States.idle_behind);
                if (manager.playerswitch == 1)
                    animator.SetInteger(animationState, (int)States.hunter_idle_behind);
            }
        }

        // main -> 빨간모자 집 이동
        if (playerTransform.position.x > -9.5 && playerTransform.position.x < -8.5 && playerTransform.position.y > 2 && playerTransform.position.y < 3)
        {
            playerTransform.position = new Vector3(-6, 15, 0);
            cameraTransform.position = new Vector3(0f, 20, -1);

        }
        // 빨간모자 집 -> main 이동
        else if (playerTransform.position.x > -6 && playerTransform.position.x < -5.5 && playerTransform.position.y > 15 && playerTransform.position.y < 15.5)
        {
            playerTransform.position = new Vector3(-9f, 0.5f, 0);
            cameraTransform.position = new Vector3(-4f, 2, -1);
            if(manager.self == 1)
            {
                manager.isAction = true;
                manager.questPanel.SetActive(true);
            }

        }
        // 퀘스트 받았을 때 퀘스트 밀맵으로 이동
        else if (playerTransform.position.x > 14 && playerTransform.position.x < 16 && playerTransform.position.y > 1.5 && playerTransform.position.y < 2.5 && manager.questCheck == true && manager.countMeal != 1)
        {
            playerTransform.position = new Vector3(37, 19f, 0);
            cameraTransform.position = new Vector3(37, 21, -1);
        }
        // 퀘스트 완료시 main 맵으로 이동
        else if (playerTransform.position.x > 30 && playerTransform.position.x < 43 && playerTransform.position.y > 18 && playerTransform.position.y < 25 && manager.countMeal == 1)
        { 
            playerTransform.position = new Vector3(15, 0f, 0);
            cameraTransform.position = new Vector3(6, 6, -1);
        }
        //플레이어 main -> forest 이동
        else if (playerTransform.position.x > 2.5 && playerTransform.position.x < 3.5 && playerTransform.position.y == -9 && manager.self == 1)
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
        else if(playerTransform.position.x > 37 && playerTransform.position.x < 40 && playerTransform.position.y > -22 && playerTransform.position.y < -18 && manager.wolfswitch == 0)
        {
            manager.count = 1;
            playerTransform.position = new Vector3(54f, -22f, 0);
            cameraTransform.position = new Vector3(60, -20, -1);
        }
        if (manager.wolfswitch == 1)
        {
            manager.wolf.transform.position = new Vector3(60f, -20f, 0);
            cameraTransform.position = new Vector3(60, -20, -1);
        }
        else if (manager.wolfswitch == 2)
        {
            cameraTransform.position = new Vector3(30, -20, -1);
            manager.wolfswitch = 0;
        }
        else if (manager.count == 7)
        {
            manager.wolf.transform.position = new Vector3(76, 0, 0);
        }
        // 플레이어 shack -> flower 이동
        else if (playerTransform.position.x > 51 && playerTransform.position.x < 52 && playerTransform.position.y > -23 && playerTransform.position.y < -21)
        {
            playerTransform.position = new Vector3(39.5f, -20.5f, 0);
            cameraTransform.position = new Vector3(30, -20, -1);
        }
        // 플레이 shack -> 할머니집 이동
        else if (playerTransform.position.x > 64.5 && playerTransform.position.x < 65.5 && playerTransform.position.y > -20 && playerTransform.position.y < -19 || manager.wolfquest == 3 )
        {
            manager.count = 3;
            if (manager.wolfquest == 3)
            {
                Player.SetActive(true);
                Player.transform.position = new Vector3(67, -3, 0);
                Player.SetActive(false);
                manager.count = 13;
                manager.wolfquest = 4;
                wolf2.SetActive(true);
            }
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
       if(manager.wolfquest == 5)
        {
            RealGM.SetActive(true);
            Player3.SetActive(true);
        }
        if (manager.wolfquest == 6)
        {
            RealGM.SetActive(false);
            Player3.SetActive(false);
            manager.wolfquest = 7;
        }


        //Scan Object
        if (Input.GetKeyDown(KeyCode.Space) && scanObject != null)
            manager.Action(scanObject);

        //Movile Key Value false
        


    }
    void CountDraw()
    {
        manager.count = 12;
        manager.talkPanel.SetActive(false);
    }
    void CountDown()
    {
        manager.count = 10;
    }
    void CountUp()
    {
        manager.talkPanel.SetActive(false);
        manager.isAction = false;
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, lookDirection * 1.2f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, lookDirection, 1.2f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
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
 