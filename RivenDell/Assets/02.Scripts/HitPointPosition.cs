using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//힛트포인트(엠티오브젝트) 지점에 충돌감지 후 모두 충돌이 되면다음으로
//

public class HitPointPosition : MonoBehaviour
{
    public GameObject[] hitPoints;
    int currPoint = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = GameObject.FindGameObjectsWithTag("HITPOINT");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BigPoint() {
        
        //만약 판넬에 파괴할 것이 없다면 다음판넬로 넘어가라
        if(currPoint == 3)
        {

        }
        //만약 판넬에 파괴할 것이 있다면 모두 없어질때까지
        else
        {
            //1초동안 커지게 하라
            //transform.localScale = new Vector3(0.4f, 0.4f);     
           yield return StartCoroutine(RaiseCircle());
            

            //Destroy(hitPoints[currPoint]);
            hitPoints[currPoint].SetActive(false);

            Debug.Log("파괴!!");
            ++currPoint;
        }
    }

    IEnumerator RaiseCircle()
    {
        Debug.Log("커져라!");
        Vector3 size = new Vector3(0.4f, 0.4f, 0.4f);

        while (hitPoints[currPoint].transform.localScale.x <= size.x)
        {
            hitPoints[currPoint].transform.localScale += Vector3.one * 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void OnRayPointEnter()
    {
        StartCoroutine("BigPoint");
    }
}
