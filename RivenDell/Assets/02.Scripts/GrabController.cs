using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrabController : MonoBehaviour
{
    #region"컨트롤러"
    //연결된 컨트롤러를 저장할 변수
    public SteamVR_Input_Sources hand;

    //왼손컨트롤러
    public SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    //오른손 컨트롤러
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;
    

    //접속한 컨트롤러
    public SteamVR_Behaviour_Pose pose;
    //트리거 버튼 클릭의 액션값
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    //텔레포트 버튼 클릭의 액션값(트랙패드 클릭했을 때)
    public SteamVR_Action_Boolean teleport = SteamVR_Actions.default_Teleport;
    public SteamVR_Action_Boolean grabAction;
    #endregion



    GameObject willObject; //잡으려는 객체
    GameObject grabObject; //잡은 객체

    // Start is called before the first frame update
    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hand = pose.inputSource;

    }

    // Update is called once per frame
    void Update()
    {
        //잡기 버튼 누를때
        if (grabAction.GetLastStateDown(hand))
        {
            if (willObject)
            {
                GrabObject();
            }
        }
        if (grabAction.GetLastStateUp(hand))
        {
            if (grabObject)
            {
                ReleaseObject();
            }
        }
    }
    
    #region"트리거 체크"
    //시작되는순간
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("들어와써");
        SetWillObject(other);
    }
    //충돌중일때
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("충돌중이야");
        SetWillObject(other);
    }
    //충돌끝나는순간
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("충돌끝!");
        if (!willObject)
        {
            return;
        }
        willObject = null;
    }
    #endregion
    
    //충돌중인 객체로 설정
    private void SetWillObject(Collider other)
    {
        if(willObject || !other.GetComponent<Rigidbody>())
        {
            return;
        }
        Debug.Log("너로 정했따!");
        willObject = other.gameObject;
    }

    //잡기
    void GrabObject()
    {
        grabObject = willObject;
        willObject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = grabObject.GetComponent<Rigidbody>();
    }
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }
    void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            grabObject.GetComponent<Rigidbody>().velocity = pose.GetVelocity();
            grabObject.GetComponent<Rigidbody>().angularVelocity = pose.GetAngularVelocity();
        }
        grabObject = null;
    }
}
