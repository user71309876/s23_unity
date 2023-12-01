using DG.Tweening;
using UnityEngine;

public class MoveTower : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition; // �̵��ϱ� ���� ��ġ�� �����ϱ� ���� ����
    private Color[] originalColors;
    private float draggingAlpha = 0.5f;
    private string targetTag = "Earth";

    GameObject towerPlacement = null;

    void Start()
    {
        originalPosition = transform.position;

        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        originalColors = new Color[spriteRenderers.Length];

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            originalColors[i] = spriteRenderers[i].color;
        }

        towerPlacement = GameObject.Find("TowerPlacement");
    }

    void OnMouseDown()
    {
        SFXManager.instance.playSFXSound("TowerDown");
        // ���콺 Ŭ�� �� Ÿ�� �̵� ����
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // �巡�� ���� �����ϰ� ����(Ÿ��)
        SetObjectAlpha(draggingAlpha);

        // �巡�� ���ȿ� �������ϰ� ����(Ÿ��)
        SetTileAlpha(0.05f);
    }

    void OnMouseUp()
    {
        SFXManager.instance.playSFXSound("TowerUp");
        // ���콺 �� �� Ÿ�� �̵� ����
        isDragging = false;

        // �̵� �� ��ġ�� Ư�� ������ �����ϴ��� Ȯ��
        CheckMoveValidity();

        // �巡�� ���� �� ������ ����(Ÿ��)
        SetObjectAlpha(1f);

        // �巡�� ������ �����ϰ� ����(Ÿ��)
        SetTileAlpha(0f);
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

        LookAtTarget();
    }

    void LookAtTarget() // Ÿ�� ���� ����
    {
        GameObject target = GameObject.FindGameObjectWithTag(targetTag);

        if(target != null)
        {
            Vector3 relativePos = target.transform.position - transform.position;
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
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
                originalPosition = targetPosition;
                Debug.Log("Ÿ�� ����");
                break;
            }
        }

        if (isValidMove)
        {
            // �̵� �� ��ġ�� ���Ǹ� Ÿ���� �ش� Tile�� �߽� ��ǥ�� �̵�
            transform.position = targetPosition;

            towerPlacement.GetComponent<TowerPlacementManager>().UpdateTowerStatus();
        }   
        else
        {
            // �̵� �� ��ġ�� ������ ���� ��� �̵��ϱ� ���� ��ġ�� �ǵ���
            transform.position = originalPosition;
        }
    }

    void SetObjectAlpha(float alpha)    // Ÿ�� ������ ����
    {
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            Color currentColor = spriteRenderers[i].color;
            currentColor.a = alpha;
            spriteRenderers[i].color = currentColor;
        }
    }

    void SetTileAlpha(float alpha)  // Ÿ�� ������ ����
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

        foreach(GameObject tile in tiles)
        {
            SpriteRenderer tileRenderer = tile.GetComponent<SpriteRenderer>();

            if(tileRenderer != null)
            {
                Color currentColor = tileRenderer.color;
                currentColor.a = alpha;
                tileRenderer.color = currentColor;
            }
        }
    }
}
