using PlayerMovement;
using UnityEngine;
namespace MainMenu
{
    public class Reset : MonoBehaviour
    {
        private GameObject player;
        [SerializeField] private Transform MainMenuLookPoint;
        [SerializeField] private LoopCounter.LoopCounter m_LoopCounter;
        private PlayerCamera m_Camera;

        private Rigidbody rb;
        private void Awake()
        {
            player=GameObject.FindGameObjectWithTag("Player");
            rb = player.GetComponent<Rigidbody>();
            m_Camera = player.GetComponent<PlayerCamera>();

        }
        void Start()
        {
            ResetPlayer();
            ResetLoop();
        }
        private void ResetPlayer()
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            player.transform.position = MainMenuLookPoint.position;
            player.transform.rotation = MainMenuLookPoint.rotation;

            m_Camera.enabled = false;
        }

        private void ResetLoop()
        {
            m_LoopCounter.Reset();
        }
    }
}
