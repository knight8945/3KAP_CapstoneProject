using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class introScript : MonoBehaviour
{
    private void Start()
    {
        ShowText(currentDialogueIndex);
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // 다음 대사로 넘어가는 로직을 여기에 작성합니다.
            NextDialogue();
        }
    }

    public TextMeshPro textUI;
    private int currentDialogueIndex = 0;
    public string[] dialogues =
        {
        "소녀는 자신의 할머니를 무척이나 사랑해서, 할머니가 만들어주신 빨간 망토를 항상 쓰고 다녔어요.",
        "마을 사람들은 모두 그런 소녀를 ‘빨간 망토’라고 불렀답니다.",
        "그러던 어느 날, 홀로 숲 속에 사시는 할머니가 병이 나서 앓아눕고 말았어요.",
        "할머니가 걱정된 빨간 망토는 병문안을 위해 숲 속 오두막을 찾아가기로 결심했어요.",
        "게임 시작을 눌러주세요"
        };

    void NextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            string nextDialogue = dialogues[currentDialogueIndex];
            // 다음 대사를 표시하는 로직을 여기에 작성합니다.
            Debug.Log(nextDialogue);

            currentDialogueIndex++;
        }
        ShowText(currentDialogueIndex);
    }

    void ShowText(int index)
    {
        textUI.text = dialogues[index];
    }


}
