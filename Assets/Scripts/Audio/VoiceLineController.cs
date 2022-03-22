using UnityEngine;

public class VoiceLineController : MonoBehaviour
{
    [SerializeField] private VoiceLine[] voiceLines;

    public int voiceLineIndex;

    public void PlayNextVoiceLine(AudioSource audioSource)
    {
        voiceLines[voiceLineIndex].PlayLine(audioSource);
        voiceLineIndex++;
    }
}
