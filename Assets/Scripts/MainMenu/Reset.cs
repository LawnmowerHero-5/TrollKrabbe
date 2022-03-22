
using UnityEngine;
namespace MainMenu
{
    public class Reset : MonoBehaviour
    {
        private GameObject player;
        [SerializeField]private GameObject mainMenu;
        [SerializeField] private Transform MainMenuLookPoint;
        [SerializeField] private LoopCounter.LoopCounter m_LoopCounter;
       
        private SceneManager sceneManager;

        //private Rigidbody rb;
        private void Awake()
        {
            player=GameObject.FindGameObjectWithTag("Player");
            //rb = player.GetComponent<Rigidbody>();
            

        }
        public void StartGame()
        {
            sceneManager.PauseInMenu();
            mainMenu.SetActive(true);
            ResetPlayer();
            ResetLoop();
        }
        private void ResetPlayer()
        {
            //todo: set in pause
            sceneManager.PauseInMenu();
            //rb.constraints = RigidbodyConstraints.FreezePosition;
            player.transform.position = MainMenuLookPoint.position;
            player.transform.rotation = MainMenuLookPoint.rotation;
            Cursor.lockState = CursorLockMode.Confined;             
            Cursor.visible = true;
        }

        private void ResetLoop()
        {
            m_LoopCounter.Reset();
        }
    }
}
