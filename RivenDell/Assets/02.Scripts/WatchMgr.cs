using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class WatchMgr : MonoBehaviour
{
    public GameObject WatchUI; //시계 UI
    public Transform handPivot; //시침분침 피봇

    
    public GameObject target; // 태양 타겟

    int angle; //각도
    int sunMask;

    float i; // 화살표 숫자

    public Slider[] m_ArrowSlider; // 화살표 배열

    float rayLength = 100f;
    float currTime; //현재시간

    Ray ray;
    RaycastHit hit; //레이힛

    enum SliderNumber
    {
        Slider_G,
        Slider_R,
        Slider_B
    }
    SliderNumber SN;

    // Start is called before the first frame update
    void Start()
    {
        
        WatchUI = GetComponentInChildren<Canvas>().gameObject;
        WatchUI.SetActive(false);

        sunMask = LayerMask.GetMask("SUN");
        //시침의 방향 랜덤생성(12개)
        //HandPivot의 Rotation의 Y값을 1~12까지의 12개 값에 30을 곱해 360도 단위로 만든다.

        angle = UnityEngine.Random.Range(1, 12); //12 개의 시간 방향 중 랜덤하게 1개

        handPivot.localEulerAngles = new Vector3(0, 0, angle * 30);
        

    }

    // Update is called once per frame
    void Update()
    {
        switch (SN)
        {
            case SliderNumber.Slider_G :
                Slider_G();
                break;
            case SliderNumber.Slider_R:
                Slider_R();
                break;
            case SliderNumber.Slider_B:
                Slider_B();
                break;
        }

        for (i = 0; i < m_ArrowSlider.Length; i++) ;

        currTime += Time.deltaTime;


        Vector3 dir = target.transform.position - handPivot.transform.position;

        // float dot = Vector3.Dot(handPivot.localEulerAngles, dir);

        //if (Mathf.Approximately(a,b))
        // {
        //     m_ArrowSlider[1].gameObject.SetActive(true);
        //     currTime = 0;
        //     Slider_R();
        // }
        
        ray = new Ray(handPivot.position, handPivot.up);
        Debug.DrawRay(handPivot.position, handPivot.up, Color.red);
        if (Physics.Raycast(ray ,out hit, rayLength,sunMask))
        {            
            Debug.Log("검출하였습니다.");


        }
        
    }

    

    //시계 트리거 엔터 되면 UI 오픈
    private void OnTriggerEnter(Collider coll)
    {
       
        if (coll.CompareTag("RIGHTHAND"))
        {
            
            Debug.Log("들어와썽!");
            WatchUI.SetActive(true);
            m_ArrowSlider[0].gameObject.SetActive(true);
            currTime = 0;
            
            coll.enabled = false;
        }
    }
    void Slider_G()
    {
        m_ArrowSlider[0].value = currTime;
        
        if (currTime > 1)
        {
            currTime = 1;

        }
    }
    private void Slider_R()
    {       
            m_ArrowSlider[1].value = currTime;

            if (currTime > 1)
            {
                currTime = 1;

            }
    }
    private void Slider_B()
    {
        
    }

}
