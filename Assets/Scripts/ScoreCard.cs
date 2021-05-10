using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCard : MonoBehaviour
{
    Text safeText;
    public int currentHealth;
    public HealthBar healthBar;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.layer == 8)
        {
            Debug.Log("Collided with Sanitizer ");
            Destroy(collisionInfo.gameObject);
            safeText = GameObject.FindWithTag("Safe").GetComponent<Text>();
            int scoreVal = Int32.Parse(safeText.text.Replace("Safe: ", "")) + 1;
            safeText.text = "Safe: " + scoreVal;
            healthBar.SetHealth(healthBar.GetCurrentHealth() - 1);
        }
    }
}
