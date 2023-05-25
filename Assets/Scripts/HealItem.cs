using UnityEngine;

public class HealItem : AbstractItem
{
    [SerializeField] private int _healQuantity;

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<IHealReceiver>();
        if (player != null)
        {
            player.Heal(_healQuantity);
            Destroy(gameObject);
        }

    }
}
