using UnityEngine;

public class MoveTower : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition; // 이동하기 전의 위치를 저장하기 위한 변수

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        // 마우스 클릭 시 타워 이동 시작
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseUp()
    {
        // 마우스 뗄 시 타워 이동 종료
        isDragging = false;

        // 이동 후 위치가 특정 조건을 만족하는지 확인
        CheckMoveValidity();
    }

    void Update()
    {
        if (isDragging)
        {
            // 마우스 드래그 시 타워 위치 업데이트
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            // z 축 위치를 이동하기 전의 위치로 고정
            curPosition.z = transform.position.z;

            transform.position = curPosition;
        }
    }

    void CheckMoveValidity()
    {
        // 이동 후 위치가 특정 조건을 만족하는지 확인
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0);
        bool isValidMove = false;
        Vector3 targetPosition = originalPosition;

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Tile"))
            {
                // 이동 후 위치가 Tile의 범위와 같을 경우 이동 허용
                isValidMove = true;
                targetPosition = collider.bounds.center;
                originalPosition = transform.position;
                break;
            }
        }

        if (isValidMove)
        {
            // 이동 후 위치가 허용되면 타워를 해당 Tile의 중심 좌표로 이동
            transform.position = targetPosition;
        }
        else
        {
            // 이동 후 위치가 허용되지 않을 경우 이동하기 전의 위치로 되돌림
            transform.position = originalPosition;
        }
    }
}
