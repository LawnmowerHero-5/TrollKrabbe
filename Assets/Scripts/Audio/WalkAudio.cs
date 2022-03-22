using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(fileName = "WalkAudio", menuName = "Rødhette/WalkAudio", order = 1)]
    public class WalkAudio : ScriptableObject
    {
        [SerializeField] private AudioClip[] footSteps;

        public float clipLength { get; private set; }

        public void PlayRandomAudio(AudioSource audioSource)
        {
            var audioIndex = Random.Range(0, footSteps.Length);

            audioSource.PlayOneShot(footSteps[audioIndex]);
        }
    }
}