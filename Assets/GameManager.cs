using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int minigameWon;
    // Start is called before the first frame update
    private void Awake()
    {
        print(minigameWon);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            minigameWon = 0;
            print("minigameWon: " + minigameWon);
        }
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene("WinScreen");
    }
}
