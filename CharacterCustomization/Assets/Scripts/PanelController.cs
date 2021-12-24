using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EditModeController.isOnEditMode == false) 
        {
            transform.localScale = new Vector3(0, 0, 0);

        }
        else
        {
            transform.localScale = new Vector3(0.2f, 1, 1);
        }
    }
}
