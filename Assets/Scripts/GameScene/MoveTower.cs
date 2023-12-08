using DG.Tweening;
using UnityEngine;

public class MoveTower : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition;
    private Color[] originalColors;
    private float draggingAlpha = 0.5f;
    private string targetTag = "Earth";

    GameObject towerPlacement = null;

    public GameObject AttackBoundary;
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
        
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        AttackBoundary.SetActive(true);

        // 타워 투명도 변경
        SetObjectAlpha(draggingAlpha);

        // 타일 불투명
        SetTileAlpha(0.1f);
    }

    void OnMouseUp()
    {
        SFXManager.instance.playSFXSound("TowerUp");

        isDragging = false;

        CheckMoveValidity();

        AttackBoundary.SetActive(false);

        // 타워 투명도 복구
        SetObjectAlpha(1f);

        // 타일 투명하게
        SetTileAlpha(0f);
    }

    void Update()
    {
        if (isDragging)
        {
            // 타워 이동
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            curPosition.z = transform.position.z;

            transform.position = curPosition;
        }

        LookAtTarget();
    }

    void LookAtTarget() // 타워 지구 방향 유지
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
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0);
        bool isValidMove = false;
        Vector3 targetPosition = originalPosition;

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Tile"))
            {
                // 타일 체크
                isValidMove = true;
                targetPosition = collider.bounds.center;
                originalPosition = targetPosition;
                break;
            }
        }

        if (isValidMove)
        {
            transform.position = targetPosition;

            towerPlacement.GetComponent<TowerPlacementManager>().UpdateTowerStatus();
        }   
        else
        {
            transform.position = originalPosition;
        }
    }

    void SetObjectAlpha(float alpha)
    {
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            Color currentColor = spriteRenderers[i].color;
            currentColor.a = alpha;
            spriteRenderers[i].color = currentColor;
        }
    }

    void SetTileAlpha(float alpha)
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
