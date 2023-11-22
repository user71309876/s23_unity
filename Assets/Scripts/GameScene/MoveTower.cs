using UnityEngine;

public class MoveTower : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition; // �̵��ϱ� ���� ��ġ�� �����ϱ� ���� ����

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        // ���콺 Ŭ�� �� Ÿ�� �̵� ����
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseUp()
    {
        // ���콺 �� �� Ÿ�� �̵� ����
        isDragging = false;

        // �̵� �� ��ġ�� Ư�� ������ �����ϴ��� Ȯ��
        CheckMoveValidity();
    }

    void Update()
    {
        if (isDragging)
        {
            // ���콺 �巡�� �� Ÿ�� ��ġ ������Ʈ
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            // z �� ��ġ�� �̵��ϱ� ���� ��ġ�� ����
            curPosition.z = transform.position.z;

            transform.position = curPosition;
        }
    }

    void CheckMoveValidity()
    {
        // �̵� �� ��ġ�� Ư�� ������ �����ϴ��� Ȯ��
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0);
        bool isValidMove = false;
        Vector3 targetPosition = originalPosition;

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Tile"))
            {
                // �̵� �� ��ġ�� Tile�� ������ ���� ��� �̵� ���
                isValidMove = true;
                targetPosition = collider.bounds.center;
                originalPosition = transform.position;
                break;
            }
        }

        if (isValidMove)
        {
            // �̵� �� ��ġ�� ���Ǹ� Ÿ���� �ش� Tile�� �߽� ��ǥ�� �̵�
            transform.position = targetPosition;
        }
        else
        {
            // �̵� �� ��ġ�� ������ ���� ��� �̵��ϱ� ���� ��ġ�� �ǵ���
            transform.position = originalPosition;
        }
    }
}
