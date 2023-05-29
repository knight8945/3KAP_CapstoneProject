using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Transform playerTransform;
    public Transform cameraTransform;
    GameObject scanObject;
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
    void Update()
    {
        if (manager.playerswitch == 1)
        {
            Player.SetActive(false);
            Player2.SetActive(true);
            playerTransform = GameObject.Find("Player2").GetComponent<Transform>();
        }
        // ĳ���� �̵� ���� ��ũ��Ʈ(ȭ������ ��������)
        if (manager.isAction ? false : Input.GetKey(KeyCode.LeftArrow)) //���� �̵�
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            animator.SetInteger(animationState, (int)States.left);
            if (manager.playerswitch == 1)
                animator.SetInteger(animationState, (int)States.hunter_left);
            lookDirection = Vector3.left;
        }
        else if (manager.isAction ? false : Input.GetKey(KeyCode.RightArrow)) //���� �̵�
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            animator.SetInteger(animationState, (int)States.right);
            if (manager.playerswitch == 1)
                animator.SetInteger(animationState, (int)States.hunter_right);
            lookDirection = Vector3.right;
        }
        else if (manager.isAction ? false : Input.GetKey(KeyCode.UpArrow)) //���� �̵�
        {
            transform.Translate(0, speed * Time.deltaTime,0);
            animator.SetInteger(animationState, (int)States.front);
            if (manager.playerswitch == 1)
                animator.SetInteger(animationState, (int)States.hunter_front);
            lookDirection = Vector3.back;
        }
        else if (manager.isAction ? false : Input.GetKey(KeyCode.DownArrow)) //�Ʒ��� �̵�
        {
            transform.Translate(0, -speed * Time.deltaTime,0);
            animator.SetInteger(animationState, (int)States.behind);
            if (manager.playerswitch == 1)
                animator.SetInteger(animationState, (int)States.hunter_behind);
            lookDirection = Vector3.forward;
        }
        // ĳ���� idle ����
        else //���� ����
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

        // main -> �������� �� �̵�
        if (playerTransform.position.x > -9.5 && playerTransform.position.x < -8.5 && playerTransform.position.y > 2 && playerTransform.position.y < 3)
        {
            playerTransform.position = new Vector3(-6, 15, 0);
            cameraTransform.position = new Vector3(0f, 20, -1);

        }
        // �������� �� -> main �̵�
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
        // ����Ʈ �޾��� �� ����Ʈ �и����� �̵�
        else if (playerTransform.position.x > 14 && playerTransform.position.x < 16 && playerTransform.position.y > 1.5 && playerTransform.position.y < 2.5 && manager.questCheck == true )
        {
            playerTransform.position = new Vector3(37, 19f, 0);
            cameraTransform.position = new Vector3(37, 21, -1);
        }
        // ����Ʈ �Ϸ�� main ������ �̵�
        else if (playerTransform.position.x > 30 && playerTransform.position.x < 43 && playerTransform.position.y > 18 && playerTransform.position.y < 25 && manager.countMeal == 1)
        { 
            playerTransform.position = new Vector3(15, 0f, 0);
            cameraTransform.position = new Vector3(6, 6, -1);
        }
        //�÷��̾� main -> forest �̵�
        else if (playerTransform.position.x > 2.5 && playerTransform.position.x < 3.5 && playerTransform.position.y == -9 && manager.self == 1)
        {
            playerTransform.position = new Vector3(3, -17.5f, 0);
            cameraTransform.position = new Vector3(3.5f, -20, -1);
            
        }
        //�÷��̾� forest -> main �̵�
        else if (playerTransform.position.x > 2.5 && playerTransform.position.x < 3.5 && playerTransform.position.y > -17 && playerTransform.position.y < -16)
        {
            playerTransform.position = new Vector3(3, -8, 0);
            cameraTransform.position = new Vector3(3.5f, -20, -1);

        }
        //�÷��̾� forest -> flower �̵�
        else if(playerTransform.position.x > 10.5 && playerTransform.position.x < 11.5 && playerTransform.position.y > -23 && playerTransform.position.y < -21)
        {
            playerTransform.position = new Vector3(23.5f, -22.5f, 0);
            cameraTransform.position = new Vector3(30, -20, -1);
        }
        //�÷��̾� flower -> forest �̵�
        else if (playerTransform.position.x > 21 && playerTransform.position.x < 22.8 && playerTransform.position.y > -23 && playerTransform.position.y < -21)
        {
            playerTransform.position = new Vector3(9.7f, -22.5f, 0);
            cameraTransform.position = new Vector3(3f, -20, -1);
        }
        // �÷��̾� flower -> shack �̵�
        else if(playerTransform.position.x > 38 && playerTransform.position.x < 39 && playerTransform.position.y > -21 && playerTransform.position.y < -20 && manager.wolfswitch == 0)
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
        // �÷��̾� shack -> flower �̵�
        else if (playerTransform.position.x > 51 && playerTransform.position.x < 52 && playerTransform.position.y > -23 && playerTransform.position.y < -21)
        {
            playerTransform.position = new Vector3(39.5f, -20.5f, 0);
            cameraTransform.position = new Vector3(30, -20, -1);
        }
        // �÷��� shack -> �ҸӴ��� �̵�
        else if (playerTransform.position.x > 64.5 && playerTransform.position.x < 65.5 && playerTransform.position.y > -20 && playerTransform.position.y < -19 )
        {
            manager.count = 3;
            playerTransform.position = new Vector3(67, -3, 0);
            cameraTransform.position = new Vector3(73, 0, -1);
        }
        // �÷��̾� �ҸӴ��� -> shack �̵�
        else if (playerTransform.position.x > 66 && playerTransform.position.x < 67 && playerTransform.position.y > -4.5 && playerTransform.position.y < -4)
        {
            playerTransform.position = new Vector3(65, -20.5f, 0);
            cameraTransform.position = new Vector3(60, -20, -1);
        }
        // incameraCharacter �Լ� �̿�
        else
        {
            incameraCharacter();
        }
        //Scan Object
        if (Input.GetKeyDown(KeyCode.Space) && scanObject != null)
            manager.Action(scanObject);

        if(manager.count == 1)
        {
            manager.talkPanel.SetActive(true);
            manager.isAction= true;
            manager.talkText.text = " �� ������ �� �� ���� ����� �ߴµ�!! ���� �ҸӴ������� ���߰ھ�!!";
            Invoke("CountUp", 2.0f);
            manager.count = 2;
        }
        if(manager.count == 3)
        {
            manager.talkPanel.SetActive(true);
            manager.isAction = true;
            manager.talkText.text = "�ҸӴ�? ��� �輼��? ��! ħ�뿡 ��ñ���";
            Invoke("CountUp", 2.0f);
            manager.count = 4;
        }
        if(manager.playerswitch == 1 && manager.count == 7 && manager.wolfquest == 0)
        {
            manager.talkPanel.SetActive(true);
            manager.isAction = true;
            manager.wolf.SetActive(false);
            manager.wolf_0.SetActive(true);
            manager.talkText.text = "���� ��ɲ� �������� ���� �� �̻��� ���� �߰��߾��!";
            playerTransform.position = new Vector3(60, -18, 0);
            cameraTransform.position = new Vector3(60, -18, -1);
            Invoke("CountUp", 2.0f);
            manager.count = 8;
        }
        if (manager.wolfquest == 1 && manager.count == 8)
        {
            manager.talkPanel.SetActive(true);
            manager.isAction = true;
            manager.wolf.SetActive(false);
            manager.wolf_0.SetActive(true);
            manager.talkText.text = "������ ���ڱ��� �i�ư�����!";
            Invoke("CountUp", 2.0f);
            cameraTransform.position = new Vector3(60, -38, -1);
            manager.count = 9;
            
        }



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
    //ĳ���Ͱ� ī�޶� ȭ�鿡�� �� ����� �ڵ�
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
 