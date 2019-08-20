using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMoveCtrl : MonoBehaviour
{
    float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        var dirF = transform.forward * Time.deltaTime * speed;
        transform.Translate(dirF, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
