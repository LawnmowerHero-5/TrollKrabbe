using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "VoiceLine", menuName = "Rødhette/VoiceLine", order = 0)]
public class VoiceLine : ScriptableObject
{
    [SerializeField] private AudioClip line;
    [SerializeField] private VoiceLine nextLine;
    [SerializeField] private string subtitle;

    public void PlayLine(AudioSource audioSource, TMP_Text subtitles)
    {
        //if (line == null) return;

        audioSource.clip = line;
        audioSource.Play();

        subtitles.text = subtitle;

        // Thread.Sleep((int) line.length * 1000);
        Thread.Sleep(10000);

        nextLine.PlayLine(audioSource, subtitles);
    }
}