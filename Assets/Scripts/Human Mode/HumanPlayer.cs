using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanPlayer : MonoBehaviour
{
	public Rigidbody rb;
	public GameManager gameManager;
	public float maxPlayerHealth = 50f;

	[SerializeField]
	private float speed = 10f;

	public float rotateSpeed = 10f;

	private Vector3 movement;
	private float rotation;

	public HealthBar healthBar;

	bool enableGun = false;
	Camera cam;
	Text displayText;

	void Start ()
    {
		healthBar.SetMaxHealth(maxPlayerHealth);
	}

	void Awake ()
    {
		cam = FindObjectOfType<Camera>();
	}

	void Update ()
	{
		movement.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		rotation = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
	}

	void FixedUpdate ()
	{
		if (Input.GetMouseButtonDown(0) && enableGun == true)
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
				if (hit.transform.gameObject.layer == 9)
                {
					GameObject virus = hit.transform.gameObject;
					virus.GetComponent<VirusHealth>().DecreaseHealth(virus);
				}
		}

		transform.Translate(movement, Space.Self);
		transform.Rotate(0f, rotation, 0f);
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.gameObject.layer == 12)
		{
			Debug.Log("G1 completed. Reached medical store");
			displayText = GameObject.FindWithTag("G1").GetComponent<Text>();
			displayText.text = "Goal 1: Get Mask & Sanitizer: Completed";
			healthBar.SetHealth(healthBar.GetCurrentHealth() * 1.2f);
			enableGun = true;
		}

		if (collisionInfo.gameObject.layer == 11)
		{
			Debug.Log("G2 completed. Reached hospital");
			displayText = GameObject.FindWithTag("G2").GetComponent<Text>();
			if (enableGun)
            {
				displayText.text = "Goal 2: Go to vaccination center: Completed";
				FindObjectOfType<GameManager>().CompleteLevel();
			} else
            {
				displayText.text = "Goal 2: Go to vaccination center: Not allowed, wear mask";
			}
		}

		if (collisionInfo.collider.tag == "InfectedPerson")
		{
			healthBar.SetHealth(healthBar.GetCurrentHealth() - 1);
		}
	}
}
