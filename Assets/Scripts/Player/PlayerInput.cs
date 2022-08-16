using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UnityEvent _moveUp;
    [SerializeField] private UnityEvent _moveDown;

    private PlayerMover _mover;


    private void Start()
    {
       _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
           _moveUp.Invoke();

        if (Input.GetKeyDown(KeyCode.S))
            _moveDown.Invoke();
    }
}
