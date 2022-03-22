using UnityEngine;

public class LoopListener : MonoBehaviour
{
    private VoiceLineController m_VlController;
    public AudioSource audioSource;
    private int m_SkippedLines = 0;
    [SerializeField] private GameObject group1;
    private void Awake()
    {
        m_VlController = GetComponent<VoiceLineController>();
    }
    public void ReceiveLoopInfo(int loopCount)
    {
        if (loopCount == 0)
        {
            m_SkippedLines = 0;
            m_VlController.voiceLineIndex = 0;
        }
        if (loopCount == 2 | loopCount == 5 | loopCount == 7  )
        {
            //Loop numbers where you want to skip dialog in this loop
            //Is also good for loops where you would want to unlock shortcuts etc
            SkipLineThisLoop();
            group1.SetActive(false);
        }
        if (m_VlController.voiceLineIndex == (loopCount - m_SkippedLines))
        {
            StartNextLine();
        }
    }
    private void SkipLineThisLoop()
    {
        m_SkippedLines++;
    }
    private void StartNextLine()
    {
        m_VlController.PlayNextVoiceLine(audioSource);
    }
}