using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWalls : MonoBehaviour
{
    [SerializeField]
    float speed = 2;
    void Update()
    {
        transform.Rotate(0, 0f, 2f + speed * Time.deltaTime);
    }
}
