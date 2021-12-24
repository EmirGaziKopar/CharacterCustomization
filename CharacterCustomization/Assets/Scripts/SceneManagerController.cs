using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void changeScene2()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
