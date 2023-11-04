using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score = 0;

    public static GameManager instance;

    PlayerMovement player;

    bool gameOver = false;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = new PlayerMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
