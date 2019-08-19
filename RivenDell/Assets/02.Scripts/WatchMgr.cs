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
    public Transform bigWatch;
    public Transform emptyPivot;
    public GameObject finalCanvas;
   
    public GameObject target; // 태양 타겟

    int angle; //각도
    int sunMask;

    float i; // 화살표 숫자
    Vector3 mid;

    public Slider[] m_ArrowSlider; // 화살표 배열

    float rayLength = 1000f;
    float currTime; //현재시간
    

    bool wait = false;
    bool ok = false;
    bool linesun = false;

    private LineRenderer line;

    public Color color = Color.yellow;

    Ray ray;
    RaycastHit hit; //레이힛
    Rigidbody rb;
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
        finalCanvas.SetActive(false);

        sunMask = LayerMask.GetMask("SUN");
        
       
        rb = GetComponent<Rigidbody>();

        LineSun();
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
        mid = handPivot.up + bigWatch.forward;

        //float dot = Vector3.Dot(handPivot.localEulerAngles, dir);
        //Vector3 v = dir - handPivot.localEulerAngles;
        //float m = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;


        Debug.Log("태양의 v값" + dir);
        Debug.Log("12의 값" + bigWatch.forward);
        

        //Debug.Log("m : 각도값" + m);

        //if (Mathf.Approximately(a,b))
        // {
        //     m_ArrowSlider[1].gameObject.SetActive(true);
        //     currTime = 0;
        //     Slider_R();
        // }
        //if (Vector3.Dot(bigWatch.forward, handPivot.up))
        //{

        //}


        ray = new Ray(handPivot.position, handPivot.up);

        
        Debug.DrawRay(emptyPivot.position, mid, Color.blue);
        Debug.DrawRay(handPivot.position, handPivot.up, Color.red);
        //Debug.DrawRay(bigWatch.position, dir, Color.yellow);
        Debug.DrawRay(bigWatch.position, bigWatch.forward, Color.green);
        
        


        //만약 시계 UI가 생성되면 레이캐스트를 쏴라

        if (wait == true)
        {
            WaitRaycast();
            
        }
        /*if(ok == true)
        {
            SumMid();
        }*/
    }
    /*public float GetAngle(handPivot.localEulerAngles, Vector3 vEnd)
    {
        Vector3 v = vEnd - handPivot.localEulerAngles;

        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }*/
    public void LateUpdate()
    {
        if (linesun == true)
        {
            
            line.SetPosition(0, Vector3.zero);
            line.SetPosition(1, transform.InverseTransformPoint(target.transform.position));
        }
    }


    //시계 트리거 엔터 되면 UI 오픈
    public void OnTriggerEnter(Collider coll)
    {
       
        if (coll.CompareTag("RIGHTHAND"))
        {
            wait = true;
            linesun = true;
            Debug.Log("들어와썽!");
            WatchUI.SetActive(true);
            m_ArrowSlider[0].gameObject.SetActive(true);
            currTime = 0;

            //12 개의 시간 방향 중 랜덤하게 1개
            //시침의 방향 랜덤생성(12개)

            angle = UnityEngine.Random.Range(1, 12);

            //HandPivot의 Rotation의 Y값을 1~12까지의 12개 값에 30을 곱해 360도 단위로 만든다.
            handPivot.localEulerAngles = new Vector3(0, 0, angle * 30);

            
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
        m_ArrowSlider[2].value = currTime;

        if (currTime > 1)
            {
                currTime = 1;

            }
    }
    private void Slider_B()
    {
       /* m_ArrowSlider[2].value = currTime;

        if (currTime > 1)
        {
            currTime = 1;

        }*/
    }

    void WaitRaycast()
    {
        if (Physics.Raycast(ray, out hit, rayLength, sunMask))
        {
            
            Debug.Log("검출하였습니다.");
            //시계UI 고정
            if (transform != null)
            {
                transform.parent = transform.parent.parent; // 부모로부터 상속해제 후 부모와 동일
                
                //transform.rotation = Quaternion.Euler(0, target., 0);
                //transform.rotation = Quaternion.identity; // 로테이션값 초기화
                transform.eulerAngles = new Vector3(-93, transform.eulerAngles.y, transform.eulerAngles.z); //태양 방향의 값으로 평면화

                /*rb.constraints = RigidbodyConstraints.FreezeRotationX;
                rb.constraints = RigidbodyConstraints.FreezeRotationY;
                rb.constraints = RigidbodyConstraints.FreezeRotationZ;
                rb.constraints = RigidbodyConstraints.FreezePositionY;*/
            }
            target.GetComponent<Collider>().enabled = false;

            SN = SliderNumber.Slider_R;
            //빨간색화살표 생성
            m_ArrowSlider[1].gameObject.SetActive(true);
            currTime = 0;
            
            m_ArrowSlider[2].gameObject.SetActive(true);
            //SN = SliderNumber.Slider_B;

            //emptyPivot.localRotation = Quaternion.LookRotation(mid);

            //ok = true;

            float Dot = Vector3.Dot(handPivot.up, bigWatch.forward);
            float angle2 = Mathf.Acos(Dot) * Mathf.Rad2Deg;
            //6시 일 때 남쪽은 6시
            if(angle == 6 || angle == 12)
            {
                emptyPivot.localEulerAngles = handPivot.localEulerAngles;
                
            }
            /*//12시 일 때 남쪽은 12시
            else if(angle == 12)
            {
                emptyPivot.localEulerAngles = Vector3.back;
            }*/
            else if(angle > 6 && angle <12){
                emptyPivot.localEulerAngles = new Vector3(0, 0, -angle2 / 2);
            }
            else
            {
                emptyPivot.localEulerAngles = new Vector3(0, 0, angle2 / 2);
            }
            
            Debug.Log("angle2 : " + angle2);
            finalCanvas.SetActive(true);
        }
        
    }

    /*void SumMid()
    {
        //만약 빨간색 일치가 된다면 파란화살표를 생성하라
        //파란색을 중간값에 나타내라
        if (ok == true)
        {
            m_ArrowSlider[2].gameObject.SetActive(true);
            SN = SliderNumber.Slider_B;
            

            Vector3 mid = handPivot.up + bigWatch.forward;

            emptyPivot.localRotation = Quaternion.LookRotation(mid);
            //emptyPivot.localEulerAngles = new Vector3(0, 0, );

            Debug.Log("mid 의 값" + mid);
            Debug.DrawRay(bigWatch.position, mid, Color.blue);
        }
    }*/
    void LineSun()
    {
        
            line = this.gameObject.AddComponent<LineRenderer>();

            line.useWorldSpace = false;
            line.receiveShadows = false;

            line.positionCount = 2;



            line.startWidth = 0.008f;
            line.endWidth = 0.0001f;

            //메터리얼 생성
            Material mt = new Material(Shader.Find("Unlit/Color"));
            mt.color = this.color;

            line.material = mt;
        
        
    }
}
