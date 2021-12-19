using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static bool isAction;


    // Start is called before the first frame update
    void Start()
    {
        isAction = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAction = true;
        }
        else
        {
            isAction = false;
        }
    }
}
