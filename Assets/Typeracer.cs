using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typeracer : MonoBehaviour
{
    public GameObject textObj;
    public GameObject correctTextObj;
    public string CorrectString = "";
    public string writtenText;
    // Start is called before the first frame update
    void Start()
    {
        CorrectString = "hei jeg heter eplemann og jeg har en tann.";
        correctTextObj.GetComponent<TMPro.TextMeshPro>().text = "'" + CorrectString + "'";

        writtenText = GetComponentInChildren<TMPro.TextMeshPro>().text;
    }

    // Update is called once per frame
    void Update()
    {
        ShowText();
        CheckTextIf();
    }

    public void ShowText()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey) && vKey != KeyCode.Return)
            {
                print(vKey);
                if(vKey == KeyCode.Backspace) {
                    GetComponentInChildren<TMPro.TextMeshPro>().text = GetComponentInChildren<TMPro.TextMeshPro>().text.Substring(0, GetComponentInChildren<TMPro.TextMeshPro>().text.Length - 1);
                } else {
                    GetComponentInChildren<TMPro.TextMeshPro>().text += (char)vKey;
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
        string writtenText = GetComponentInChildren<TMPro.TextMeshPro>().text;
        Debug.Log(writtenText.GetType());
        Debug.Log(CorrectString.GetType());
        print(writtenText);
        print(CorrectString);
        //writtenText += " ";
        if (writtenText == CorrectString)
        {
            print("O");
            textObj.GetComponent<TMPro.TextMeshPro>().text = "nice";
        }
    }

    //IEnumerator TimerCheckText()
    //{
    //    yield return new WaitForSeconds(2);
    //    CheckText();
    //}
}
