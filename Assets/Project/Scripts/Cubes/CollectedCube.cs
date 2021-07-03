using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CollectedCube : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private CubesPool pool;
    private WaitForSeconds waitFourSeconds = new WaitForSeconds(4);

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    public void Init(CubesPool pool, Vector3 localPosition,Quaternion localRotation, Transform parent)
    {
        this.pool = pool;
        transform.SetParent(parent);
        transform.localPosition = localPosition;
        transform.localRotation = localRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Wall>(out Wall wall))
        {
            pool.RemoveCube(this);
        }
    }

    public IEnumerator AfterRemove(Action<CollectedCube> callback)
    {
        m_rigidbody.velocity = Vector3.zero;
        yield return waitFourSeconds;
        gameObject.SetActive(false);
        callback?.Invoke(this);
    }
}
