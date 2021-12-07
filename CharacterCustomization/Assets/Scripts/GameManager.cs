using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerScore = 0, aiScore = 0;
    public float timer = 120f;
    public Text scoreText;
    public string score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {

            Debug.Log("game over");
        }

        score = playerScore.ToString() + " - " + aiScore.ToString();

        scoreText.text = score.ToString();
    }
}
