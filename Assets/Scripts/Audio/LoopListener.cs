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
    
    //LastLine
    private AudioClip[] LastLines;
    
    private void Awake()
    {
        m_VlController = GetComponent<VoiceLineController>();
    }
    public void ReceiveLoopInfo(int loopCount)
    {
        print("loopCount = " + loopCount + ",  unHideFox = " + m_UnhideFoxLoop);
        if (loopCount == 0)
        {
            m_VlController.voiceLineIndex = 0;
            m_SkippedLines = 0;
            // HideFox(loopCount);
            return;
        }
        for (int i = 0; i < skippedLoops.Length; i++)
        {
            if (skippedLoops[i] == loopCount)
            {
                SkipNextLine();
                print(i +" skipped loop = " + loopCount);
            }
            if (-skippedLoops[i] == loopCount-1)
            {
                print("Hid Fox");
                HideFox(loopCount);
            }
            if (loopCount == skippedLoops[skippedLoops.Length]-1)
            {
                
            }
            
        }
        if (m_UnhideFoxLoop == loopCount)
        {
            print("UnHid Fox");
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

        m_UnhideFoxLoop = loopCount-1;
    }
    private void UnHideFox()
    {
        fox.transform.position = normalLocation.position;
    }
    private void LastLine()
    {
        //play first part of the dialog
        audioSource.PlayOneShot(LastLines[0]);
        //after audio clip length play other half,
        //then animate a fade to black
        //after second audio clip is finsished,
        //run Reset in the Reset script.
        
    }
    
}
