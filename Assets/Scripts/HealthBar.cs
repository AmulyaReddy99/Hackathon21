using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth (float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public float GetCurrentHealth ()
    {
        return slider.value;
    }

    public float GetMaxHealth()
    {
        return slider.maxValue;
    }

    public void SetHealth (float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if (SceneManager.GetActiveScene().name.Contains("VirusMode"))
        {
            if (health <= 0)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }
}
