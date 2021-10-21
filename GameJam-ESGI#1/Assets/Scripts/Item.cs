using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isLootable = true;

    public void FixedUpdate() {
        if (!GameManager.Instance.Running) return;
        transform.position += transform.right * (GameManager.Instance.itemSpeed * Time.fixedDeltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Despawn"))
        {
            Destroy(gameObject);
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            if (isLootable) {
                GameManager.Instance.AddPoint(1);
            }
            else {
                GameManager.Instance.TakeDamage(1);
            }
            Destroy(gameObject);
        }
    }
}
