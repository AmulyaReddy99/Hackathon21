using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MutateVirus : MonoBehaviour
{

    public GameObject virus;
    public Vector3 offset;

    float timeoutDuration = 5f;
    float timeout = 5f;
    int liveVirusCount = 0;

    Text mutants;

    void Update ()
    {
        if (timeout > 0)
        {
            timeout -= Time.deltaTime;
            return;
        }
        MutateFunction();
        timeout = timeoutDuration;
    }

    public void MutateFunction()
    {
        Vector3 pos = virus.transform.position + offset;
        GameObject newVirus = Instantiate(virus, pos, Quaternion.identity);
        newVirus.GetComponent<PlayerMovement>().enabled = false;
        newVirus.GetComponent<MutateVirus>().enabled = false;
        liveVirusCount += 1;
        mutants = GameObject.FindWithTag("Mutants").GetComponent<Text>();
        mutants.text = "Live Virus Mutants: " + liveVirusCount.ToString();
    }

}
