using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManage : MonoBehaviour
{
    [SerializeField] Texture2D cursorImage; // 마우스 커서 이미지를 여기에 할당합니다.
    // Start is called before the first frame update
    void Start()
    {
        // 마우스 커서 이미지를 설정합니다.
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
