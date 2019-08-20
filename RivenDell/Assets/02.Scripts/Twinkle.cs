using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Twinkle : MonoBehaviour
{

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //나는 게임오브젝트의 알파를 0에서 255까지 왔다갔다 하게 하고싶다.
        text = GetComponent<Text>();
        float changeAlpha = text.color.a;
        changeAlpha--;
        
        
    }
}
