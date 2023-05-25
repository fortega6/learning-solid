using UnityEngine;

public class DrunkItem : AbstractItem
{
    [SerializeField] private float _time;

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<MovementController>();
        if (player != null)
        {
            player.SetDrunk(_time);
            Destroy(gameObject);
        }
    }
}