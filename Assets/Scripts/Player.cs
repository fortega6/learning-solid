using DefaultNamespace;
using UnityEngine;

/* Controls the player movement and player health */
public class Player : MonoBehaviour
{
    [SerializeField] private HealthController _healthController;
    [SerializeField] private MovementController _movementController;
    private void Awake()
    {
        _movementController.Configure(new RegularMovable(), new DrunkMovable());
    }

    public void Reset()
    {
        _movementController.Reset();
        _healthController.Reset();
    }
}
