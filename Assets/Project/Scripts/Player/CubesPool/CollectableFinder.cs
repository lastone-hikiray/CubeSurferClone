using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableFinder : MonoBehaviour
{
    [SerializeField] private CubesPool pool;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Collectable collectable))
        {
            other.gameObject.SetActive(false);
            pool.AddCube();
        }
    }
}
