using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HumanBots : MonoBehaviour
{
	public GameObject sanitizer;
	public GameObject mask;
	public GameObject femaleBot;
	public GameObject maleABot;
	public GameObject maleBBot;

	public int femaleCount = 20;
	public int maleACount = 15;
	public int maleBCount = 15;
	public int maskCount = 50;
	public int sanitizerCount = 50;
	public int targetCount = 30;

	public HealthBar healthBar;

	int minX = -95;
	int maxX = 145;
	int minZ = -60;
	int maxZ = 195;

	public List<GameObject> sanitizers = new List<GameObject>();
	public List<GameObject> masks = new List<GameObject>();
	public List<GameObject> femaleBots = new List<GameObject>();
	public List<GameObject> maleABots = new List<GameObject>();
	public List<GameObject> maleBBots = new List<GameObject>();

	int safeCount = 0;
	Text safeText;
	Text targetText;

	void Start()
	{
		GenerateLevel();
		healthBar.SetMaxHealth(sanitizerCount);
	}

	void GenerateLevel()
	{
		targetText = GameObject.FindWithTag("TargetCount").GetComponent<Text>();
		targetText.text = targetCount.ToString();

		for (int i = 0; i < sanitizerCount; i++)
		{
			// Spawn a sanitizer
			Vector3 pos = new Vector3(Random.Range(minX, maxX), 0.0f, Random.Range(minZ, maxZ));
			sanitizers.Add(Instantiate(sanitizer, pos, Quaternion.identity, transform));
		}

		for (int i = 0; i < maskCount; i++)
		{
			// Spawn a mask
			Vector3 pos = new Vector3(Random.Range(minX, maxX), 0.0f, Random.Range(minZ, maxZ));
			masks.Add(Instantiate(mask, pos, Quaternion.identity));
		}

		for (int i = 0; i < femaleCount; i++)
		{
			// Spawn humanBot
			Vector3 pos = new Vector3(Random.Range(minX, maxX), 0.0f, Random.Range(minZ, maxZ));
			GameObject newFemale = Instantiate(femaleBot, pos, Quaternion.identity);
			newFemale.GetComponent<NavMeshAgent>().destination = sanitizers[i].transform.position;
			femaleBots.Add(newFemale);
		}

		for (int i = 0; i < maleACount; i++)
		{
			// Spawn humanBot
			Vector3 pos = new Vector3(Random.Range(minX, maxX), 0.0f, Random.Range(minZ, maxZ));
			GameObject newMaleA = Instantiate(maleABot, pos, Quaternion.identity);
			newMaleA.GetComponent<NavMeshAgent>().destination = sanitizers[i].transform.position; // + femaleCount - 1
			maleABots.Add(newMaleA);
		}

		for (int i = 0; i < maleBCount; i++)
		{
			// Spawn humanBot
			Vector3 pos = new Vector3(Random.Range(minX, maxX), 0.0f, Random.Range(minZ, maxZ));
			GameObject newMaleB = Instantiate(maleBBot, pos, Quaternion.identity);
			newMaleB.GetComponent<NavMeshAgent>().destination = sanitizers[i].transform.position; // + femaleCount + maleACount - 2
			maleBBots.Add(newMaleB);
		}
	}
}
