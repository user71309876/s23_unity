using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    // 텍스트 옵션들
    private string[] textOptions = { "Add Tower", "Attack Power Up", "Attack Speed Up" };

    void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>();

        SetButtonTexts(buttons, "Add Tower");

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => { ChangeButtonTexts(buttons); });
        }
    }

    // 버튼 텍스트 변경 메서드
    void ChangeButtonTexts(Button[] buttons)
    {
        // 랜덤으로 텍스트 선택
        string randomText = GetRandomText();

        // 선택된 텍스트로 버튼 텍스트 변경
        SetButtonTexts(buttons, randomText);
    }

    void SetButtonTexts(Button[] buttons, string newText)
    {
        foreach (Button button in buttons)
        {
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

            buttonText.text = newText;
        }
    }

    // 랜덤으로 텍스트 선택하는 메서드
    string GetRandomText()
    {
        int randomIndex = Random.Range(0, textOptions.Length);
        return textOptions[randomIndex];
    }
}
