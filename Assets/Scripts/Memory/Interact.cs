using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public GameObject Text;
    public UnityEvent interactAction;

    private void Start()
    {
        Text.SetActive(false);
    }

    private void Update()
    {
        if (isInRange) // if we're in range to interact
        {
            if (Input.GetKeyDown(interactKey)) // And player presses the key
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Text.SetActive(true);
            isInRange = true;
            Debug.Log("Player is in range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Text.SetActive(false);
            isInRange = false;
            Debug.Log("Player now not in range");
        }
    }
}
