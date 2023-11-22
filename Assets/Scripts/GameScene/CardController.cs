using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    // �ؽ�Ʈ �ɼǵ�
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

    // ��ư �ؽ�Ʈ ���� �޼���
    IEnumerator ChangeButtonTexts(Button button)
    {
        yield return new WaitForSeconds(1f);

        // �������� �ؽ�Ʈ ����
        string randomText = GetRandomText();

        // ���õ� �ؽ�Ʈ�� ��ư �ؽ�Ʈ ����
        SetButtonText(button, randomText);
    }

    void SetButtonText(Button button, string newText)
    {
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

        buttonText.text = newText;
    }

    // �������� �ؽ�Ʈ �����ϴ� �޼���
    string GetRandomText()
    {
        int randomIndex = Random.Range(0, textOptions.Length);
        return textOptions[randomIndex];
    }
}
