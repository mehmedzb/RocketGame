using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilattor : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 movementVector;
    [Range (0,1)] public float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startPosition = gameObject.transform.position ;

    }

    void Update()
    {
        float cycles = Time.time / period ;
        const float tau = Mathf.PI * 2; // pi * 2 birim cemberin cevresi.
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2f; // -1 olmaması için 1 ekliyoruz daha sonrada 2 olmaması için 2 ye bölüyoruz.


        Vector3 offset = movementVector * movementFactor;
        transform.position = startPosition + offset;
    }
}
