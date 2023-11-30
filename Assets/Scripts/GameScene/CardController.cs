using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    // �ؽ�Ʈ �ɼǵ�
    private string[] textOptions1 = { "Add Tower", "Attack Power Up", "Attack Speed Up" };
    private string[] textOptions2 = { "Attack Power Up", "Attack Speed Up" };
    private Button[] buttons;
    private string[] buttonTexts;

    GameObject towerPlacement = null;

    void Start()
    {
        buttons = GetComponentsInChildren<Button>();

        SetInitialButtonText();

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => { StartCoroutine(ChangeButtonTexts(button)); });
        }

        towerPlacement = GameObject.Find("TowerPlacement");
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
        if (!towerPlacement.GetComponent<TowerPlacementManager>().IsPlacedTowerCountExceedsLimit())
        {
            int randomIndex = Random.Range(0, textOptions1.Length);
            return textOptions1[randomIndex];
        }
        else
        {
            int randomIndex = Random.Range(0, textOptions2.Length);
            return textOptions2[randomIndex];
        }
    }
}
