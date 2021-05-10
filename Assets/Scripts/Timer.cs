using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	public float timeValue = 90;
	public float maxTime = 90;
	Text timerText;

	void Update()
	{
		timerText = GameObject.FindWithTag("Timer").GetComponent<Text>();
		if (timeValue > 0)
		{
			timeValue -= Time.deltaTime;
		}
		else
		{
			timeValue = 0;
			if (SceneManager.GetActiveScene().name.Contains("Human"))
				FindObjectOfType<GameManager>().CompleteLevel();
			else
				FindObjectOfType<GameManager>().EndGame();
		}
		DisplayTime(timeValue);
	}

	void DisplayTime(float timeToDisplay)
	{
		float minutes = Mathf.FloorToInt(timeToDisplay / 60);
		float seconds = Mathf.FloorToInt(timeToDisplay % 60);
		timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}

	public float GetMaxTime()
    {
		return maxTime;
    }
}
