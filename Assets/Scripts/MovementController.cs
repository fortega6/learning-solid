using System;
using System.Collections;
using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    
    [SerializeField] private Animator       _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
      
    [SerializeField] private float _initialSpeed = 1;

    private float _currentSpeed;

    private IMovable _drunkMovable;
    private IMovable _regularMovable;

    private IMovable _currentMovable;

    private void Awake()
    {
        Reset();
    }

    public void Configure(IMovable regularMovement, IMovable drunkMovement)
    {
        _regularMovable = regularMovement;
        _regularMovable.Configure(_animator, _spriteRenderer, transform);
        _drunkMovable = drunkMovement;
        _drunkMovable.Configure(_animator, _spriteRenderer, transform);
    }

    private void FixedUpdate()
    {
        _currentMovable.DoMove(_currentSpeed);
    }
    
    public void Reset()
    {
        _currentSpeed = _initialSpeed;
        _currentMovable = _regularMovable;
    }

    public void SetSpeed(float newSpeed)
    {
        _currentSpeed = newSpeed;
    }

    public void SetDrunk(float drunkDuration)
    {
        _currentMovable = _drunkMovable;
        StartCoroutine(DisableDrunk(drunkDuration));
    }

    private IEnumerator DisableDrunk(float drunkDuration)
    {
        yield return new WaitForSeconds(drunkDuration);
        _currentMovable = _regularMovable;
    }
}
