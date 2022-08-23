using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarSCript : MonoBehaviour
{

    [SerializeField] private Image healthBar;

    private bool inRange = false;
    public float currentHealth;

    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 0f;
        UpdateHealthbar();
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (inRange && Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth += 0.02f;
            UpdateHealthbar();
        }

        if (timerIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

    }



    private void UpdateHealthbar()
    {
        healthBar.fillAmount = currentHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }
}

