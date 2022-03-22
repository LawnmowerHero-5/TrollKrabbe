using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]

    public class BirdSounds : MonoBehaviour
    {
        [SerializeField] private WalkAudio birdSound;

        private AudioSource _audioSource;
        private float timer;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Time.time <= timer) return;

            birdSound.PlayRandomAudio(_audioSource);
            timer = Time.time + Random.Range(30f, 60f);
        }
    }
}