using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    // �ؽ�Ʈ �ɼǵ�
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

    // ��ư �ؽ�Ʈ ���� �޼���
    void ChangeButtonTexts(Button[] buttons)
    {
        // �������� �ؽ�Ʈ ����
        string randomText = GetRandomText();

        // ���õ� �ؽ�Ʈ�� ��ư �ؽ�Ʈ ����
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

    // �������� �ؽ�Ʈ �����ϴ� �޼���
    string GetRandomText()
    {
        int randomIndex = Random.Range(0, textOptions.Length);
        return textOptions[randomIndex];
    }
}
