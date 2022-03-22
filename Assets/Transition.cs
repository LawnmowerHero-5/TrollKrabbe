using System;
using UnityEngine;

public class Transition : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private bool play;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    private void PlayTransition()
    {
        _animator.Play("Transition");
    }

    private void StopTransition()
    {
        _animator.Play("Static");
    }
}
