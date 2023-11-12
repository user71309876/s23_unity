using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler, IScrollHandler
{
    public ScrollRect ParentSR;
    // Start is called before the first frame update
    private GameObject stageDetail;
    private bool activeSave=false;
    private float force=100f;
    private float gravity=3f;

    void Start()
    {
        transform.Find("InnerImage").gameObject.SetActive(false);
        stageDetail=GameObject.Find("StageDetail");
        // y=stageDetail.GetComponent<RectTransform>().anchoredPosition.y;
        // x=stageDetail.GetComponent<RectTransform>().anchoredPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(stageDetail.GetComponent<RectTransform>().anchoredPosition.x < 50){
            force+=gravity;
            stageDetail.GetComponent<RectTransform>().anchoredPosition += new Vector2(force, 0f)*Time.deltaTime;
            // Debug.Log(".GetComponent<RectTransform>().anchoredPosition : "  + stageDetail.GetComponent<RectTransform>().anchoredPosition);
        }
        // if(stageDetail.GetComponent<RectTransform>().anchoredPosition.x >= 50){
        //     force-=gravity;
        //     stageDetail.GetComponent<RectTransform>().anchoredPosition -= new Vector2(force, 0f)*Time.deltaTime;
        //     Debug.Log(".GetComponent<RectTransform>().anchoredPosition : "  + stageDetail.GetComponent<RectTransform>().anchoredPosition);
        // }
    }

    private void Awake()
    {
        Debug.Log("checkAwake");
        ParentSR = transform.parent.parent.parent.GetComponent<ScrollRect>();
    }
    
    public void OnBeginDrag(PointerEventData e)
    {
        ParentSR.OnBeginDrag(e);
    }
    public void OnDrag(PointerEventData e)
    {
        ParentSR.OnDrag(e);
    }
    public void OnEndDrag(PointerEventData e)
    {
        ParentSR.OnEndDrag(e);
    }
    public void OnScroll(PointerEventData e){
        ParentSR.OnScroll(e);
    }

    public void StageClick(){
        Debug.Log("click!!");
        Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        //해당 좌표에 있는 오브젝트 찾기
        RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero, 0f);
        if (hit.collider != null){
            GameObject click_obj=hit.transform.gameObject;
            Debug.Log(click_obj.name);
        }
        //-1300,50
    }
    public void StageHoverIn(){
        Debug.Log("hover!!");
        SetInnerImageActive(true);
    }
    public void StageHoverOut(){
        Debug.Log("hoverOut!!");
        SetInnerImageActive(false);
    }

    private void SetInnerImageActive(bool active){
        if(activeSave!=active){
            activeSave=active;
            transform.Find("InnerImage").gameObject.SetActive(active);
        }
    }
    public void GoMainScene(){
        SceneManager.LoadScene("MainScene");
    }
    public void GoGameScene(){
        SceneManager.LoadScene("GameScene");
    }
    public void GoSettingScene(){
        SceneManager.LoadScene("SettingScene");
    }
}
