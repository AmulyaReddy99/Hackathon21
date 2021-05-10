using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public float virusHealth = 5;

    Text TargetText;

    void Start ()
    {
        healthBar.SetMaxHealth(virusHealth);
    }

    public void DecreaseHealth (GameObject virus)
    {
        float newHealth = healthBar.GetCurrentHealth() - 1;
        if (newHealth > 0)
        {
            healthBar.SetHealth(newHealth);
        }
        else
        {
            Destroy(virus);

            TargetText = GameObject.FindWithTag("TargetCount").GetComponent<Text>();
            int targetVal = Int32.Parse(TargetText.text) + 1;
            TargetText.text = targetVal.ToString();

            if (targetVal >= 50)
            {
                FindObjectOfType<GameManager>().CompleteLevel();
            }

        }
    }
}
