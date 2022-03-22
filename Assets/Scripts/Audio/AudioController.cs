using UnityEngine;

namespace Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private WalkAudio groundWalk;
        [SerializeField] private WalkAudio waterWalk;
        [SerializeField] private WalkAudio rockWalk;
        [SerializeField] private float audioFrequency = 0.5f;

        private float audioTimer;

        public void PlayWalkAudio(Vector3 moveSpeed, AudioSource audioSource, Transform playerPosition)
        {
            if (Time.time < audioTimer) return;
            if (Mathf.Abs(moveSpeed.x) <= 0.1f || Mathf.Abs(moveSpeed.z) <= 0.1f) return;

            audioTimer = Time.time + audioFrequency;

            RaycastHit raycast;
            Physics.Raycast(playerPosition.position, Vector3.down, out raycast);

            if (raycast.collider.CompareTag("Ground"))
            {
                groundWalk.PlayRandomAudio(audioSource);
            }
            else if (raycast.collider.CompareTag("Water"))
            {
                waterWalk.PlayRandomAudio(audioSource);
            }
            else if (raycast.collider.CompareTag("Rock"))
            {
                rockWalk.PlayRandomAudio(audioSource);
            }
        }
    }
}