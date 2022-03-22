using TMPro;
using UnityEngine;

public class VoiceLineController : MonoBehaviour
{
    [SerializeField] private VoiceLine[] voiceLines;

    private static int _voiceLineIndex;

    public void PlayNextVoiceLine(AudioSource audioSource, TMP_Text subtitles)
    {
        voiceLines[_voiceLineIndex].PlayLine(audioSource, subtitles);
        _voiceLineIndex++;
    }
}