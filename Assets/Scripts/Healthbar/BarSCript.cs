using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarSCript : MonoBehaviour
{

    [SerializeField] private Image healthBar;

    private float maxHealth = 200f;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth += 0.05f;
            UpdateHealthbar();
        }
    }
    
    private void UpdateHealthbar()
    {
        healthBar.fillAmount = currentHealth;
    }
}
