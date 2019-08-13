using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBehaviour : MonoBehaviour
{
    public static ButtonBehaviour Instance;
    //스크립트가 활성화 될때마다호출된다. Start함수보다 먼저 호출됨.
    //이벤트의 연결 또는 코루틴을 가동시킬때 주로 사용
    void OnEnable(){
        //LaserController 에서 OnLaserEnter 이벤트가 발생했을때 이 스크립트의 LaserEnter 이벤트를 발생시켜줘
        LaserController.OnLaserEnter += this.LaserEnter;
        LaserController.OnLaserExit += this.LaserExit;
    }

    //연결된 이벤트를 해제
    void OnDisable()
    {
        // LaserController 에서 OnLaserExit 이벤트가 발생했을때 이 스크립트의 LaserEnter 이벤트를 취소시켜줘
        //(LaserExit 이벤트를 발생시켜줘)
        LaserController.OnLaserEnter -= this.LaserEnter;
        LaserController.OnLaserExit -= this.LaserExit;
    }

//LaserController 에 정의된 OnLaserEnter 이벤트가 발생했을때 호출할 함수
    public void LaserEnter(GameObject obj){
        if(obj == this.gameObject){
            ExecuteEvents.Execute(this.gameObject
                                    , new PointerEventData(EventSystem.current)
                                    , ExecuteEvents.pointerEnterHandler);
        }
    }

    public void LaserExit(){
        ExecuteEvents.Execute(this.gameObject
                                    , new PointerEventData(EventSystem.current)
                                    , ExecuteEvents.pointerExitHandler);
    }
}
