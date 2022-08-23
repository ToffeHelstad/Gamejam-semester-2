using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typeracer : MonoBehaviour
{
    public GameObject textObj;
    public GameObject correctTextObj;
    public string CorrectString = "hei";
    // Start is called before the first frame update
    void Start()
    {
        correctTextObj.GetComponent<TMPro.TextMeshPro>().text = "'" + CorrectString + "'";
    }

    // Update is called once per frame
    void Update()
    {
        ShowText();
        CheckText();
    }

    public void ShowText()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
            {
                print(vKey);
                GetComponentInChildren<TMPro.TextMeshPro>().text += (char)vKey;
            }
        }
    }

    public void CheckText()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string writtenText = GetComponentInChildren<TMPro.TextMeshPro>().text;
            Debug.Log(writtenText.GetType());
            Debug.Log(CorrectString.GetType());
            print(writtenText);
            print(CorrectString);
            if (GetComponentInChildren<TMPro.TextMeshPro>().text == CorrectString)
            {
                print("O");
                textObj.GetComponent<TMPro.TextMeshPro>().text = "nice";
            }
        }
    }
}
