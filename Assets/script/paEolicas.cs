using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paEolicas : MonoBehaviour
{
    public float giro = 2;

    void Update()
    {
        transform.Rotate(0, 0, giro * Time.deltaTime);
    }
}
