using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarSCript : MonoBehaviour
{

    [SerializeField] private Image healthBar;

    private bool inRange = false;
    public float currentHealth;

    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    public string winText;
    public string loseText;

    public TMP_Text testtodisplayingameworld;

    void Start()
    {
        currentHealth = 0f;
        UpdateHealthbar();
        
    }

    void Update()
    {

        if (inRange && Input.GetKeyDown(KeyCode.Space))
        {
            if (currentHealth < 1f)
            {
                currentHealth += 0.02f;
            }
            else
            {
                currentHealth = 1f;
            }
            UpdateHealthbar();
            timerIsRunning = true;
            
        }
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
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

        testtodisplayingameworld.text = timeRemaining.ToString();

        if(currentHealth==1f && timeRemaining > 0)
        {
            testtodisplayingameworld.text = winText;
        }
        else if (currentHealth < 1 && timeRemaining == 0)
        {
            testtodisplayingameworld.text = loseText;
            ResetHealthBar();

        }

    }
    
    private void UpdateHealthbar()
    {

            healthBar.fillAmount = currentHealth;
        
    }

    private void ResetHealthBar()
    {
        healthBar.fillAmount = 0;
        timeRemaining = 10f;
        currentHealth = 0f;
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

