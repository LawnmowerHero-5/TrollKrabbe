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
        
        private void Awake()
        {
            player=GameObject.FindGameObjectWithTag("Player");
        }
        
        public void StartGame()
        {
            sceneManager.PauseInMenu();
            mainMenu.SetActive(true);
            ResetPlayer();
            ResetLoop();
        }
        
        public void ResetPlayer()
        {
            sceneManager.PauseInMenu();
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
