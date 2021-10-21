using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isLootable = true;

    public void FixedUpdate()
    {
        transform.position += transform.right * (GameManager.Instance.itemSpeed * Time.fixedDeltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Despawn"))
        {
            Destroy(this.gameObject);
        }
    }
}
