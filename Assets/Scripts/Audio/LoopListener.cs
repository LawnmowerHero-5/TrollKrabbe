using UnityEngine;

public class LoopListener : MonoBehaviour
{
    private VoiceLineController m_VlController;
    public AudioSource audioSource;
    private void Awake()
    {
        m_VlController = GetComponent<VoiceLineController>();
    }
    public void ReceiveLoopInfo(int loopCount)
    {
        if (loopCount == 1 )
        {
            
        }
    }
    private void StartNextLine()
    {
        m_VlController.PlayNextVoiceLine(audioSource);
    }
    
}
