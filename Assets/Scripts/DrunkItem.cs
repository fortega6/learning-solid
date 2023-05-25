using UnityEngine;

public class DrunkItem : AbstractItem
{
    [SerializeField] private float _time;

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<MovementController>();

        if (IsPlayer(player))
        {
            ApplyDrunk(player);
        }
    }

    private void ApplyDrunk(MovementController player)
    {
        player.SetDrunk(_time);
        Destroy(gameObject);
    }

    private bool IsPlayer(MovementController player)
    {
        return player != null;
    }
}