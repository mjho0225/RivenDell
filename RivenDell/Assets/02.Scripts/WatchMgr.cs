using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class WatchMgr : MonoBehaviour
{
    public GameObject WatchUI;
    public Transform handPivot;
    int angle;

    public Slider m_ArrowSlider;

    float currTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
        WatchUI = GetComponentInChildren<Canvas>().gameObject;
        WatchUI.SetActive(false);

        //시침의 방향 랜덤생성(12개)
        //HandPivot의 Rotation의 Y값을 1~12까지의 12개 값에 30을 곱해 360도 단위로 만든다.

        angle = Random.Range(1, 12); //12 개의 시간 방향 중 랜덤하게 1개

        handPivot.localEulerAngles = new Vector3(0, 0, angle * 30);
        

    }

    // Update is called once per frame
    void Update()
    {
        
        currTime += Time.deltaTime;
        
        m_ArrowSlider.value = currTime;
        if(currTime > 1)
        {
            currTime = 1;
            
        }

    }
    //시계 트리거 엔터 되면 UI 오픈
    private void OnTriggerEnter(Collider coll)
    {
       
        if (coll.CompareTag("RIGHTHAND"))
        {
            
            Debug.Log("들어와썽!");
            WatchUI.SetActive(true);

            currTime = 0;
            coll.enabled = false;
        }
    }
}
