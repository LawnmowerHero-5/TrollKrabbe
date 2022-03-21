using UnityEngine;

[CreateAssetMenu(fileName = "VoiceLine", menuName = "Rødhette/VoiceLine", order = 0)]
public class VoiceLine : ScriptableObject
{
    [SerializeField] private AudioClip line;

    public void PlayLine(AudioSource audioSource)
    {
        audioSource.PlayOneShot(line);
    }
}