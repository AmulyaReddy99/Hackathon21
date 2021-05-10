using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnVirus : MonoBehaviour
{
	public GameObject virus;
	public Transform player;
	public int virusCount = 50;

	public List<GameObject> viruses = new List<GameObject>();

	int minX = -95;
	int maxX = 145;
	int minZ = -60;
	int maxZ = 195;

	void Start ()
    {
		for (int i = 0; i < virusCount; i++)
		{
			// Spawn a virus
			Vector3 pos = new Vector3(Random.Range(minX, maxX), 0.0f, Random.Range(minZ, maxZ));
			GameObject newVirus = Instantiate(virus, pos, Quaternion.identity, transform);
			viruses.Add(newVirus);
		}
	}

	void Update ()
    {
		for (int i = 0; i < virusCount; i++)
		{
			viruses[i].GetComponent<NavMeshAgent>().destination = player.position;
		}
	}

	public int GetVirusCount ()
    {
		return virusCount;
    }
}
