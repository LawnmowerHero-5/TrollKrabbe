using Audio;
using UnityEngine;
namespace PlayerMovement
{
    [RequireComponent(typeof(FloatCapsule))]
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Input))]
    [RequireComponent(typeof(AudioController))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        private Input m_Input;
        private Movement m_Movement;
        private PlayerCamera m_Camera;
        private AudioSource _audioSource;
        private AudioController _audioController;
        private Rigidbody _rigidbody;

        public SceneManager sceneManager;

        private void Awake()
        {
            m_Camera = GetComponent<PlayerCamera>();
            m_Movement = GetComponent<Movement>();
            m_Input = GetComponent<Input>();
            _audioSource = GetComponent<AudioSource>();
            _audioController = GetComponent<AudioController>();
            _rigidbody = GetComponent<Rigidbody>();
        }
        private void Start()
        {
            //Sets all rotations to 0
            transform.rotation = Quaternion.Euler(0,transform.rotation.y,0);
        }
        private void Update()
        {
            if (sceneManager.gameIsPaused) return;
            m_Camera.Look(m_Input.lookVector);
            _audioController.PlayWalkAudio(_rigidbody.velocity, _audioSource, transform);
        }

        private void FixedUpdate() {
            m_Movement.Move(m_Input.moveDirection, m_Input.run);
        }
    }
}