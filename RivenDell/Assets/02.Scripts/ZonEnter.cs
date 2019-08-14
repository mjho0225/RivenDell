using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//DirIntZon에 진입시 힌트 UI 생성
//진입후 n초 후에 UI가 생성되야한다
//
public class ZonEnter : MonoBehaviour 
{

    public Canvas[] hintUI;

    #region ---------------------- 배열
    public enum UINumber 
    {
        UI1 = 0,
        UI2 = 1,
        UI3 = 2,
        UI4,
        UI5,
        UI6,
        UI7,
        UI8
    }
    #endregion

    public UINumber UInumber = UINumber.UI1;

    // Start is called before the first frame update
    void Start () {
        hintUI = GetComponentsInChildren<Canvas>();
        //hintUI.SetActive (false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Player"){
            //Invoke("ChangeUI", 1.0f);
            Invoke("ShowUI", 0.2f);
        }
    }


    public void ShowUI () {

        hintUI[(int)UInumber].GetComponent<CanvasGroup> ().interactable = true;
        hintUI[(int)UInumber].GetComponent<CanvasGroup> ().alpha = 1f;
    }

    public void ChangeUI () {

        hintUI[(int)UInumber].GetComponent<CanvasGroup> ().interactable = false;
        hintUI[(int)UInumber].GetComponent<CanvasGroup> ().alpha = 0f;
        
        //마지막 레이어인지 아닌지 판단하기
        if (hintUI.Length == (int)UInumber+1){
            //씬 전환하는 로직 넣기

        }
        else
        {
            //열거형 변수를 인티져 타입으로 바꾸고, 증감연산자로 1씩 증가.
            //그 인티저 변수를 열거형 타입으로 바꿈
            UInumber = (UINumber)((int)UInumber++);
            hintUI[(int)UInumber].GetComponent<CanvasGroup> ().interactable = true;
            hintUI[(int)UInumber].GetComponent<CanvasGroup> ().alpha = 1f; 
        }
    }

    // void CountNumber () {
    //     for (int i = 0; i < hintUI.Length; i++) {
    //         hintUI[i].gameObject.SetActive (true);
    //     }
    // }

    #region ----------------- UINumber 함수
    public void UI1 () {
        // hintUI[0].gameObject.SetActive (true);
        // hintUI[0].GetComponent<CanvasGroup> ().interactable = false;
        // hintUI[0].GetComponent<CanvasGroup> ().alpha = 0f;
        // UInumber = UINumber.UI2;
        ChangeUI ();
    }

    public void UI2 () {
        Debug.Log ("change UI1");
        hintUI[1].GetComponent<CanvasGroup> ().interactable = false;
        hintUI[1].GetComponent<CanvasGroup> ().alpha = 0f;
        UInumber = UINumber.UI3;
    }

    public void UI3 () {
        hintUI[2].GetComponent<CanvasGroup> ().interactable = false;
        hintUI[2].GetComponent<CanvasGroup> ().alpha = 0f;
        UInumber = UINumber.UI4;
    }

    public void UI4 () {
        hintUI[3].GetComponent<CanvasGroup> ().interactable = false;
        hintUI[3].GetComponent<CanvasGroup> ().alpha = 0f;
        UInumber = UINumber.UI5;
    }

    public void UI5 () {
        hintUI[4].GetComponent<CanvasGroup> ().interactable = false;
        hintUI[4].GetComponent<CanvasGroup> ().alpha = 0f;
        UInumber = UINumber.UI6;
    }

    public void UI6 () {
        hintUI[5].GetComponent<CanvasGroup> ().interactable = false;
        hintUI[5].GetComponent<CanvasGroup> ().alpha = 0f;
        UInumber = UINumber.UI7;
    }

    public void UI7 () {
        hintUI[6].GetComponent<CanvasGroup> ().interactable = false;
        hintUI[6].GetComponent<CanvasGroup> ().alpha = 0f;
        UInumber = UINumber.UI8;
    }

    public void UI8 () {
        hintUI[7].GetComponent<CanvasGroup> ().interactable = false;
        hintUI[7].GetComponent<CanvasGroup> ().alpha = 0f;
        
    }

    #endregion
}