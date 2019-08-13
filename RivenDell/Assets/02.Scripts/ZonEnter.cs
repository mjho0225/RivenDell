using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//DirIntZon에 진입시 힌트 UI 생성
//진입후 n초 후에 UI가 생성되야한다
//
public class ZonEnter : MonoBehaviour {
    public Collider diz; //충돌 감지할 콜리더

    public float currentTime;

    public float n = 2; //UI 생성까지 걸리는 시간

    [SerializeField] private Canvas[] hintUI;

    #region ---------------------- 배열
    enum UINumber {
        UI1,
        UI2,
        UI3,
        UI4,
        UI5,
        UI6,
        UI7,
        UI8
    }
    #endregion

    UINumber UInumber;

    // Start is called before the first frame update
    void Start () {
        //hintUI = GetComponentsInChildren<Canvas> ();
        //hintUI.SetActive (false);
    }

    private void OnCollisionEnter (Collision coll) {
        //만약 
        if (transform.position.z > coll.transform.position.z) {
            SpawnUI ();
        }
    }

    // Update is called once per frame
    void Update () {
        switch (UInumber) {
            case UINumber.UI1:
                UI1 ();
                break;
            case UINumber.UI2:
                UI2 ();
                break;
            case UINumber.UI3:
                UI3 ();
                break;
            case UINumber.UI4:
                UI4 ();
                break;
            case UINumber.UI5:
                UI5 ();
                break;
            case UINumber.UI6:
                UI6 ();
                break;
            case UINumber.UI7:
                UI7 ();
                break;
            case UINumber.UI8:
                UI8 ();
                break;
        }
    }

    void SpawnUI () {
        currentTime += Time.deltaTime;
        if (currentTime > n) {
            //hintUI.SetActive (true);
            UInumber = UINumber.UI1;
        }
        for (int i = 0; i < hintUI.Length; i++) {
            hintUI[i].gameObject.SetActive (true);
        }
    }

    // void CountNumber () {
    //     for (int i = 0; i < hintUI.Length; i++) {
    //         hintUI[i].gameObject.SetActive (true);
    //     }
    // }

    #region ----------------- UINumber 함수
    public void UI1 () {
        hintUI[0].GetComponent<CanvasGroup> ().interactable = false;
        hintUI[0].GetComponent<CanvasGroup> ().alpha = 0f;
        UInumber = UINumber.UI2;
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