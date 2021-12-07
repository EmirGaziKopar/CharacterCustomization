using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeController : MonoBehaviour
{

    [SerializeField] GameObject inputControllerGameObject;

    InputController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = inputControllerGameObject.GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(controller.weightt, controller.heightt, transform.localScale.z);
        Debug.Log("degerler: " + controller.weightt + " " + controller.heightt);
    }
}
