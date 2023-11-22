using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    // 텍스트 옵션들
    private string[] textOptions = { "Add Tower", "Attack Power Up", "Attack Speed Up" };
    private Button[] buttons;
    private string[] buttonTexts;

    void Start()
    {
        buttons = GetComponentsInChildren<Button>();

        SetInitialButtonText();

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => { StartCoroutine(ChangeButtonTexts(button)); });
        }
    }

    void SetInitialButtonText()
    {
        buttonTexts = new string[buttons.Length];
        for(int i=0;i<buttons.Length; i++)
        {
            buttonTexts[i] = "Add Tower";
            SetButtonText(buttons[i], buttonTexts[i]);
        }
    }

    // 버튼 텍스트 변경 메서드
    IEnumerator ChangeButtonTexts(Button button)
    {
        yield return new WaitForSeconds(1f);

        // 랜덤으로 텍스트 선택
        string randomText = GetRandomText();

        // 선택된 텍스트로 버튼 텍스트 변경
        SetButtonText(button, randomText);
    }

    void SetButtonText(Button button, string newText)
    {
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

        buttonText.text = newText;
    }

    // 랜덤으로 텍스트 선택하는 메서드
    string GetRandomText()
    {
        int randomIndex = Random.Range(0, textOptions.Length);
        return textOptions[randomIndex];
    }
}
