using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class VoiceLineController : MonoBehaviour
{
    [SerializeField] private VoiceLine[] voiceLines;

    private static int _voiceLineIndex;

    public void PlayNextVoiceLine(AudioSource audioSource)
    {
        voiceLines[_voiceLineIndex].PlayLine(audioSource);
        _voiceLineIndex++;
    }
}