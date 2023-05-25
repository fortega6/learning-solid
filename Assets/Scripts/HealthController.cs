﻿using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HealthController : MonoBehaviour, IDamageReceiver, IHealReceiver
{
    [SerializeField] private Animator       _animator;
    [SerializeField] private PlayerHud      _playerHud;
    [SerializeField] private int            _initialHealth = 100;
    
    
    private int _currentHealth;

    public void Reset()
    {
        _currentHealth = _initialHealth;
        _playerHud.SetHealth(_currentHealth.ToString());
        _animator.SetBool("IsDeath", false);
    }

    public void ReceiveDamage(int quantity)
    {
        UpdateHealth(quantity);
        UpdateHUD();

        if (PlayerIsDead())
        {
            SetGameOver();
        }
    }


    private void UpdateHealth(int quantity)
    {
        _currentHealth -= quantity;
    }

    private void UpdateHUD()
    {
        _playerHud.SetHealth(_currentHealth.ToString());
    }

    private bool PlayerIsDead()
    {
        return _currentHealth <= 0;
    }

    private void SetGameOver()
    {
        /* Is not a good idea to use singletons patter to do that because this makes it difficult to test,
                     but for the purpose of this course will be enough. In future courses we will see how to improve it using MVVM pattern */
        GameEventListener.Instance.OnPlayerDeath();
        _animator.SetBool("IsDeath", true);
    }
    public void Heal(int quantityToHeal)
    {
        // Check that the health is in the limits
        _currentHealth = math.min(_currentHealth + quantityToHeal, _initialHealth);
        _playerHud.SetHealth(_currentHealth.ToString());
    }
}
