using DG.Tweening;
using UnityEngine;

public class MoveTower : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition; // 이동하기 전의 위치를 저장하기 위한 변수
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
        // 마우스 클릭 시 타워 이동 시작
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 드래그 동안 투명하게 설정(타워)
        SetObjectAlpha(draggingAlpha);

        // 드래그 동안에 불투명하게 설정(타일)
        SetTileAlpha(0.05f);
    }

    void OnMouseUp()
    {
        // 마우스 뗄 시 타워 이동 종료
        isDragging = false;

        // 이동 후 위치가 특정 조건을 만족하는지 확인
        CheckMoveValidity();

        // 드래그 종료 후 투명도 복구(타워)
        SetObjectAlpha(1f);

        // 드래그 끝나면 투명하게 설정(타일)
        SetTileAlpha(0f);
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

        LookAtTarget();
    }

    void LookAtTarget() // 타워 방향 통일
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
                originalPosition = targetPosition;
                Debug.Log("타일 만남");
                break;
            }
        }

        if (isValidMove)
        {
            // 이동 후 위치가 허용되면 타워를 해당 Tile의 중심 좌표로 이동
            transform.position = targetPosition;

            towerPlacement.GetComponent<TowerPlacementManager>().UpdateTowerStatus();
        }   
        else
        {
            // 이동 후 위치가 허용되지 않을 경우 이동하기 전의 위치로 되돌림
            transform.position = originalPosition;
        }
    }

    void SetObjectAlpha(float alpha)    // 타워 투명도 설정
    {
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            Color currentColor = spriteRenderers[i].color;
            currentColor.a = alpha;
            spriteRenderers[i].color = currentColor;
        }
    }

    void SetTileAlpha(float alpha)  // 타일 투명도 설정
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
