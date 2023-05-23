using UnityEngine;

public class DrunkItem : AbstractItem
{
    [SerializeField] private float _duration = 2;
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<MovementController>();
        if (player)
        {
            player.SetDrunk(_duration);
            Destroy(gameObject);
        }
    }
}