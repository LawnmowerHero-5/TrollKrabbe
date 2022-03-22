using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityTemplateProjects.Audio
{
    public class VoiceTester : MonoBehaviour
    {
        [SerializeField] private VoiceLineController voiceLineController;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private TMP_Text subtitles;
        private void Update()
        {
            if (Keyboard.current.commaKey.wasPressedThisFrame)
            {
                voiceLineController.PlayNextVoiceLine(audioSource, subtitles);
            }
        }
    }
}