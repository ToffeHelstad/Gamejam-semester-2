using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarSCript : MonoBehaviour
{

    [SerializeField] private Image healthBar;

    private bool inRange = false;
    private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 0f;
        UpdateHealthbar();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth += 0.05f;
            UpdateHealthbar();
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
