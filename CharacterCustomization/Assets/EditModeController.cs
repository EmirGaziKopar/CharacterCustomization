using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditModeController : MonoBehaviour
{
    public static bool isOnEditMode;
    Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle = this.gameObject.GetComponent<Toggle>();
        isOnEditMode = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        isOnEditMode = toggle.isOn;
    }
}
