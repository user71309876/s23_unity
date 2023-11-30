using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollButtonHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IScrollHandler
{
    private ScrollRect ParentSR;// ScrollView의 Scroll Rect component를 담기 위함
    private bool activeSave=false;// 버튼을 채우는 오브젝트의 초기 활성화 여부
    private int clickButtonNumber;
    public const string stageNumber="stageNumber";

    void Start(){
        transform.Find("InnerImage").gameObject.SetActive(activeSave);// 버튼을 채우는 오브젝트 비활
        ParentSR = transform.parent.parent.parent.GetComponent<ScrollRect>();// scrollview의  Scroll Rect component를 담음
    }
    
    // 마우스 이벤트를 stageButton이 다 먹고 있어 scrollview에서 드래그 또는 스크롤이 안되는 현상 발생
    // 밑의 4개의 함수는 마우스 이벤트를 scrollview에게도 전달하는 역활
    public void OnBeginDrag(PointerEventData e){
        ParentSR.OnBeginDrag(e);
    }
    public void OnDrag(PointerEventData e){
        ParentSR.OnDrag(e);
    }
    public void OnEndDrag(PointerEventData e){
        ParentSR.OnEndDrag(e);
    }
    public void OnScroll(PointerEventData e){
        ParentSR.OnScroll(e);
    }

    // 버튼을 클릭했을 때 이벤트
    public void StageClick(){
        // 버튼 이름의 마지막 숫자를 clickButton에 저장한 후 hashmap에 저장, key는 stageNumber를 사용
        clickButtonNumber=int.Parse(this.gameObject.name.Substring(this.gameObject.name.Length-1));
        Debug.Log(clickButtonNumber);
        PlayerPrefs.SetInt(stageNumber,clickButtonNumber);
    }

    // 버튼 hover in, hover out 이벤트 처리
    public void StageHoverIn(){
        SetInnerImageActive(true);
    }
    public void StageHoverOut(){
        SetInnerImageActive(false);
    }

    private void SetInnerImageActive(bool active){
        if(activeSave!=active){
            activeSave=active;
            transform.Find("InnerImage").gameObject.SetActive(active);
        }
    }
}