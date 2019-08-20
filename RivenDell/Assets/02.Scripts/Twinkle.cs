using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Twinkle : MonoBehaviour
{
    RaycastHit hit;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //나는 텍스트의 알파를 0에서 255까지 왔다갔다 하게 하고싶다.
        //나는 텍스트가 깜빡이게 하고 싶다.
        for(int i=0; i<3; i++)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }


       transform.position = hit.transform.position;//Raycasthit가 맞은 좌표를 가져옴
        
    }
}
