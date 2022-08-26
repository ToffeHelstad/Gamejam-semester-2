using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typeracer : MonoBehaviour
{
    public GameObject writeTxt;
    public GameObject textObj;
    public GameObject correctTextObj;
    public string CorrectString = "";
    public string writtenText;
    private bool timerOn;
    public float timer;
    public GameObject timerTxt;
    public GameObject winTxt;
    private bool typeracerOn;
    public GameObject player;

    public GameManager GameManager;
    public GameObject memoryMinigame;
    public AudioSource music;
    public AudioSource musicBackground;

    // Start is called before the first frame update
    void Start()
    {
        CorrectString = "if object equals 10 instantiate new physics raycast input.getkeydown.keycode.c";
        correctTextObj.GetComponent<TMPro.TextMeshPro>().text = "'" + CorrectString + "'";
        // if object equals 10, 

        writtenText = writeTxt.GetComponent<TMPro.TextMeshPro>().text;

        timerOn = true;
        timer = 50;
    }

    // Update is called once per frame
    void Update()
    {
        // Typeracer Start
        if (Input.GetKeyDown(KeyCode.C) && typeracerOn == false) {typeracerOn = true; player.GetComponent<CharacterController>().enabled = false;
            memoryMinigame.GetComponent<Interact>().enabled = false;
            music.Play();
            musicBackground.Stop();
        }
        if (typeracerOn)
        {
            ShowText();
            CheckTextIf();
            Timer();
        }
    }

    public void ShowText()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey) && vKey != KeyCode.Return)
            {
                print(vKey);
                if(vKey == KeyCode.Backspace) {
                    writeTxt.GetComponent<TMPro.TextMeshPro>().text = writeTxt.GetComponent<TMPro.TextMeshPro>().text.Substring(0, writeTxt.GetComponent<TMPro.TextMeshPro>().text.Length - 1);
                } else {
                    writeTxt.GetComponent<TMPro.TextMeshPro>().text += (char)vKey;
                }
                //if (vKey == KeyCode.I)
                //{
                //    StartCoroutine(TimerCheckText());
                //}
            }
        }
    }

    public void CheckTextIf()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckText();
        }
    }

    public void CheckText()
    {
        string writtenText = writeTxt.GetComponent<TMPro.TextMeshPro>().text;
        Debug.Log(writtenText.GetType());
        Debug.Log(CorrectString.GetType());
        print(writtenText);
        print(CorrectString);
        //writtenText += " ";
        // Win
        if (writtenText == CorrectString)
        {
            textObj.GetComponent<TMPro.TextMeshPro>().text = "nice";
            ResetTyperacer();
            GameManager.minigameWon++;
            print(GameManager.minigameWon);
            WinCheck();
        }
    }

    public void Timer()
    {
        if (timerOn)
        {
            timer -= Time.deltaTime;
            timerTxt.GetComponent<TMPro.TextMeshPro>().text = timer.ToString();
        }
        if (timer < 0)
        {
            winTxt.GetComponent<TMPro.TextMeshPro>().text = "Timeout!";
            ResetTyperacer();
        }
    }

    public void ResetTyperacer()
    {
        timerOn = false;
        timer = 10;
        typeracerOn = false;
        player.GetComponent<CharacterController>().enabled = true;
        memoryMinigame.GetComponent<Interact>().enabled = true;
        music.Stop();
        musicBackground.Play();
    }

    public void WinCheck()
    {
        if (GameManager.minigameWon >= 2)
        {
            GameManager.LoadWinScreen();
        }
    }

    //IEnumerator TimerCheckText()
    //{
    //    yield return new WaitForSeconds(2);
    //    CheckText();
    //}
}
