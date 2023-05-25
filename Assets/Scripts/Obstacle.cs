using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _damageWillCause = 10;
    [SerializeField] private float _movementSpeed  = 3;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * (_movementSpeed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<IDamageReceiver>();
        if (player != null)
        {
            // Add damage and destroy the object
            player.ReceiveDamage(_damageWillCause);
            Destroy(gameObject);
        }
        else
        {
            // only destroy the object, is not a player
            Destroy(gameObject);
        }
    }
}
