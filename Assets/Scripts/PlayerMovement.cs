using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

	public Rigidbody rb;

	public float forwardForce = 8000f;
	public float sidewaysForce = 100f;

	public GameManager gameManager; 

	[SerializeField]
	private float speed = 10f;

	public float rotateSpeed = 10f;

	private Vector3 movement;
	private float rotation;

	Text InfectedText;
	Text TargetText;

	public HealthBar healthBar;

	void Update()
	{
		movement.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		rotation = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
	}

	void FixedUpdate()
	{
		transform.Translate(movement, Space.Self);
		transform.Rotate(0f, rotation, 0f);
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.gameObject.layer == 8)
		{
			Debug.Log("Infected");

			InfectedText = GameObject.FindWithTag("Infected").GetComponent<Text>();
			int infectedVal = Int32.Parse(InfectedText.text.Replace("Infected: ", "")) + 1;
			InfectedText.text = "Infected: " + infectedVal;

			TargetText = GameObject.FindWithTag("TargetCount").GetComponent<Text>();
			int targetVal = Int32.Parse(TargetText.text) - 1;
			TargetText.text = targetVal.ToString();

			if (infectedVal >= targetVal)
            {
				gameManager.CompleteLevel();
			}

			healthBar.SetHealth(healthBar.GetCurrentHealth() + 1);
		}
	}
}