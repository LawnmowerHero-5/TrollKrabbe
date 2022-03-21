
using UnityEngine;
namespace MainMenu
{
    public class Reset : MonoBehaviour
    {
        private GameObject player;
        [SerializeField]private GameObject mainMenu;
        [SerializeField] private Transform MainMenuLookPoint;
        [SerializeField] private LoopCounter.LoopCounter m_LoopCounter;
       

        private Rigidbody rb;
        private void Awake()
        {
            player=GameObject.FindGameObjectWithTag("Player");
            rb = player.GetComponent<Rigidbody>();
            

        }
        void Start()
        {
            mainMenu.SetActive(true);
            ResetPlayer();
            ResetLoop();
        }
        private void ResetPlayer()
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            player.transform.position = MainMenuLookPoint.position;
            player.transform.rotation = MainMenuLookPoint.rotation;

           
        }

        private void ResetLoop()
        {
            m_LoopCounter.Reset();
        }
    }
}
