using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UpdateDeactiveCollectable();
        }
    }

     public void UpdateDeactiveCollectable()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(Random.Range(-8.60f, 9), 0.52f, Random.Range(-8.5f, 8));
    }
}
