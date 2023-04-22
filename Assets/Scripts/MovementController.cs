using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private float _speed = 1;

    private float _currentSpeed;

    private bool _isDrunk;

    private IMovement _regularMovement;
    private IMovement _drunkMovement;

    private IMovement _currentMovement;
    
    private void Awake()
    {
        Reset();
    }
    
    public void Configure(IMovement regularMovement, IMovement drunkMovement)
    {
        _regularMovement = regularMovement;
        _regularMovement.Configure(_animator, _spriteRenderer, transform);
        _drunkMovement = drunkMovement;
        _drunkMovement.Configure(_animator, _spriteRenderer, transform);
    }

    private void FixedUpdate()
    {
        _currentMovement.DoMove(_speed);
    }

    public void Reset()
    {
        _currentMovement = _regularMovement;
        _currentSpeed  = _speed;
        _animator.SetBool("IsDeath", false);
    }
    
    public void SetSpeed(float speed)
    {
        _currentSpeed = speed;
    }

    public void SetDrunk(float duration)
    {
        _currentMovement = _drunkMovement;
        StartCoroutine(DisableDrunk(duration));
    }

    private IEnumerator DisableDrunk(float time)
    {
        yield return new WaitForSeconds(time);
        _currentMovement = _regularMovement;
    }
}