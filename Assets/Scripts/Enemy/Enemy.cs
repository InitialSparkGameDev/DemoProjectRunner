using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");

        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            Debug.Log("Player Hit");
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
