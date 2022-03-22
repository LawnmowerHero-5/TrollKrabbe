using UnityEngine;

namespace Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private WalkAudio groundWalk;
        [SerializeField] private WalkAudio waterWalk;
        [SerializeField] private WalkAudio rockWalk;

        private float audioTimer;

        public void PlayWalkAudio(float moveSpeed, AudioSource audioSource, Transform playerPosition)
        {
            if (moveSpeed <= 0f) return;
            if (Time.time < audioTimer) return;

            RaycastHit raycast;
            Physics.Raycast(playerPosition.position, Vector3.down, out raycast);

            if (raycast.collider.CompareTag("Ground"))
            {
                groundWalk.PlayRandomAudio(audioSource);
                audioTimer = Time.time + groundWalk.clipLength;
            }
            else if (raycast.collider.CompareTag("Water"))
            {
                waterWalk.PlayRandomAudio(audioSource);
                audioTimer = Time.time + waterWalk.clipLength;
            }
            else if (raycast.collider.CompareTag("Rock"))
            {
                rockWalk.PlayRandomAudio(audioSource);
                audioTimer = Time.time + rockWalk.clipLength;
            }
        }
    }
}