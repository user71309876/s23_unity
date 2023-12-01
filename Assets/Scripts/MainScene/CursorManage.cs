using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManage : MonoBehaviour
{
    [SerializeField] Texture2D cursorImage; // ���콺 Ŀ�� �̹����� ���⿡ �Ҵ��մϴ�.
    // Start is called before the first frame update

    
    void Reset(){
        // set fullscreen when starting game
        Screen.SetResolution(1920, 1080, true);
    }
    void Start()
    {
        // Screen.SetResolution(1920, 1080, true);
        // ���콺 Ŀ�� �̹����� �����մϴ�.
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
