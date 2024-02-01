using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public CharacterMovement characterMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * 1) * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("delete collided");
        if (other.gameObject.CompareTag("Grass"))
        {
            Destroy(other.gameObject);
        }
    }

}
