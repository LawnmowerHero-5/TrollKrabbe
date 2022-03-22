using UnityEngine;
namespace MainMenu
{
    public class StartGame : MonoBehaviour
    {
        public Transform startPosition;
        public GameObject player;

        private SceneManager sceneManager;
        
        [SerializeField]private GameObject mainMenu;
        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        public void StartTheGame()
        {
            SetPlayerPosition();
            mainMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;       
            Cursor.visible = false;
            //Put what you want to be called when the start button is pressed here
        }
        
        private void SetPlayerPosition()
        {
            player.transform.position = startPosition.position;
            player.transform.rotation = startPosition.rotation;
        }
    }
}
