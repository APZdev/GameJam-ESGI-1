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
            Destroy(gameObject);
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Player") && isLootable) {
            GameManager.Instance.AddPoint(1);
            Destroy(gameObject);
        }
    }
}
