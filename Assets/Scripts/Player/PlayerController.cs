using System;
using UnityEngine;

[RequireComponent(typeof(FloatCapsule))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Input))]
[RequireComponent(typeof(VoiceLineController))]
[RequireComponent(typeof(AudioSource))]

public class PlayerController : MonoBehaviour
{
    private Input m_Input;
    private Movement m_Movement;
    private PlayerCamera m_Camera;
    private FloatCapsule m_FloatCapsule;
    private VoiceLineController _voiceLineController;
    private AudioSource _audioSource;

    private bool _hasCrossedMiddle;

    private void Awake()
    {
        m_FloatCapsule = GetComponent<FloatCapsule>();
        m_Camera = GetComponent<PlayerCamera>();
        m_Movement = GetComponent<Movement>();
        m_Input = GetComponent<Input>();
        _voiceLineController = GetComponent<VoiceLineController>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        //Sets all rotations to 0
        transform.rotation = Quaternion.Euler(0,transform.rotation.y,0);
    }
    private void Update()
    {
        m_Camera.Look(m_Input.lookVector);
        m_FloatCapsule.Jump(m_Input.jumpTrigger);
    }
    private void FixedUpdate() {
        m_Movement.Move(m_Input.moveDirection, m_Input.run);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HalfwayPoint"))
        {
            _hasCrossedMiddle = true;
        }
        else if (other.CompareTag("StoryPoint"))
        {
            _hasCrossedMiddle = false;
            _voiceLineController.PlayNextVoiceLine(_audioSource);
        }
    }
}