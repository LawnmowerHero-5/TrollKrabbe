using UnityEngine;

public class LoopListener : MonoBehaviour
{
    private VoiceLineController m_VlController;
    public AudioSource audioSource;
    private int m_SkippedLines = 0;
    [SerializeField] private Transform[] hideLocations;
    [SerializeField] private Transform normalLocation;
    [SerializeField] private GameObject fox;
    private int m_UnhideFoxLoop;

    [SerializeField] private int[] skippedLoops;
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
            HideFox(loopCount);
            return;
        }
        for (int i = 0; i < skippedLoops.Length; i++)
        {
            if (skippedLoops[i] == loopCount)
            {
                SkipNextLine();
            }
            if (-skippedLoops[i] == loopCount-1)
            {
                HideFox(loopCount);
            }
            
        }
        if (m_UnhideFoxLoop == loopCount)
        {
            UnHideFox();
        }
        // if (loopCount == 2|loopCount == 5)//etc all lines that are to be skipped, also enable shortcuts etc here
        // {
        //     SkipNextLine();
        //     HideFox(loopCount);
        //     
        // }
        if (m_VlController.voiceLineIndex == (loopCount-m_SkippedLines-1))
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
    private void HideFox(int loopCount)
    {
        var whichLocation = Random.Range(0, hideLocations.Length);
        fox.transform.position = hideLocations[whichLocation].position;

        m_UnhideFoxLoop = -(loopCount + 1);
    }
    private void UnHideFox()
    {
        fox.transform.position = normalLocation.position;
    }
    
}
