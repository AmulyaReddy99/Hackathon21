using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform virus;

    void LateUpdate ()
    {
        Vector3 newPosition = virus.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, virus.eulerAngles.y, 0f);
    }
}
