using UnityEngine;

public class LoopListener : MonoBehaviour
{
    private VoiceLineController m_VlController;
    public AudioSource audioSource;
    private int m_SkippedLines = 0;
    private void Awake()
    {
        m_VlController = GetComponent<VoiceLineController>();
    }
    public void ReceiveLoopInfo(int loopCount)
    {
        if (loopCount == 0)
        {
            m_VlController.voiceLineIndex = 0;
            m_SkippedLines = 0;
        }
        if (loopCount == 2|loopCount == 5)//etc all lines that are to be skipped, also enable shortcuts etc here
        {
            SkipNextLine();
            
        }
        if (m_VlController.voiceLineIndex == loopCount-m_SkippedLines)
        {
            StartNextLine();
        }
    }
    private void StartNextLine()
    {
        m_VlController.PlayNextVoiceLine(audioSource);
    }
    private void SkipNextLine()
    {
        m_SkippedLines++;
    }
    
}
