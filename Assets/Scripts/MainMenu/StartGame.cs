using PlayerMovement;
using UnityEngine;
namespace MainMenu
{
    public class StartGame : MonoBehaviour
    {
        public Transform startPosition;
        private GameObject player;
        private PlayerCamera m_Camera;
        private Rigidbody rb;
        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            rb = player.GetComponent<Rigidbody>();
            m_Camera = player.GetComponent<PlayerCamera>();
        }
        public void StartTheGame()
        {
            SetPlayerPosition();
            m_Camera.enabled = true;
            //Put what you want to be called when the start button is pressed here
        }
        private void SetPlayerPosition()
        {
            player.transform.position = startPosition.position;
            player.transform.rotation = startPosition.rotation;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotationX;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        }
    }
}
