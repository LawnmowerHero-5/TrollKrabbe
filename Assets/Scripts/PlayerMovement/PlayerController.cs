using UnityEngine;
namespace PlayerMovement
{
    [RequireComponent(typeof(FloatCapsule))]
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Input))]
    public class PlayerController : MonoBehaviour
    {
        private Input m_Input;
        private Movement m_Movement;
        private PlayerCamera m_Camera;
        private FloatCapsule m_FloatCapsule;

        public SceneManager sceneManager;

        private void Awake()
        {
            m_FloatCapsule = GetComponent<FloatCapsule>();
            m_Camera = GetComponent<PlayerCamera>();
            m_Movement = GetComponent<Movement>();
            m_Input = GetComponent<Input>();
        }
        private void Start()
        {
            //Sets all rotations to 0
            transform.rotation = Quaternion.Euler(0,transform.rotation.y,0);
            sceneManager = new SceneManager();
        }
        private void Update()
        {
            if (sceneManager.gameIsPaused)
            {
                m_Camera.Look(m_Input.lookVector);
            }
            m_FloatCapsule.Jump(m_Input.jumpTrigger);
        }
        private void FixedUpdate() {    
            m_Movement.Move(m_Input.moveDirection, m_Input.run);
        }
    }
}
