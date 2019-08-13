using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class LaserController : MonoBehaviour {
    //나는 먼저 접속하는녀석을 왼손컨트롤러로 하고싶다

    //연결된 컨트롤러를 저장할 변수
    public SteamVR_Input_Sources hand;

    //왼손 컨트롤러
    public SteamVR_Input_Sources lefthand = SteamVR_Input_Sources.LeftHand;
    //오른손 컨트롤러
    public SteamVR_Input_Sources righthand = SteamVR_Input_Sources.RightHand;

    //접속한 컨트롤러
    public SteamVR_Behaviour_Pose pose;
    //트리거 버튼 클릭의 액션값
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    

    //동적으로 생성할 라인랜더러
    private LineRenderer line;

    public float maxDistance = 10.0f;

    //라인의 기본색
    public Color color = Color.blue;
    public Color clockedColor = Color.green;

    //Raycast 변수
    private RaycastHit hit;
    private Transform tr;

    private GameObject currButton;
    private GameObject prevButton;

    //Flower Prefab
    private GameObject flower;

    //델리게이트 선언부
    #region
    //LaserEnter
    public delegate void LaserEnterHandler (GameObject obj);
    public static event LaserEnterHandler OnLaserEnter;

    //LaserExit
    public delegate void LaserExitHandler ();
    public static event LaserExitHandler OnLaserExit;
    #endregion

    //Pointer 객체를 저장할 변수
    public Transform pointer;

    //Teleport 대상 객체
    public Transform target;

    // Start is called before the first frame update
    void Start () {
        //접속한 컨트롤러가 왼손/오른손인지 판별
        pose = GetComponent<SteamVR_Behaviour_Pose> ();
        hand = pose.inputSource;

        tr = GetComponent<Transform> ();

        flower = Resources.Load<GameObject> ("Flower");

    }

    void Update () {
        if (Physics.Raycast (tr.position, tr.forward, out hit, maxDistance)) {
            line.SetPosition (1, new Vector3 (0, 0, hit.distance));

            currButton = hit.collider.gameObject;

            //버튼일경우에만 실행
            if (hit.collider.gameObject.layer == 8 && hand == SteamVR_Input_Sources.RightHand) {

                if (currButton != prevButton) {

                    //모든 버튼에게 포커스아웃 이벤트를 전달(이벤트 생성, 발생)
                    OnLaserExit ();
                    //현재 가리키고 있는 버튼정보를 포함한 이벤트를 모두 전달
                    OnLaserEnter (hit.collider.gameObject);

                    prevButton = currButton;
                }

                //트리거 버튼 클릭의 이벤트를 처리
                if (trigger.GetStateDown (hand)) {
                    ExecuteEvents.Execute (currButton, new PointerEventData (EventSystem.current), ExecuteEvents.pointerClickHandler);
                }
            }
        }
    }
}