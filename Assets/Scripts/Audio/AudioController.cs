using UnityEngine;

namespace Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private WalkAudio groundWalk;
        [SerializeField] private WalkAudio waterWalk;
        [SerializeField] private WalkAudio rockWalk;

        private float audioTimer;

        public void PlayWalkAudio(Vector3 moveSpeed, AudioSource audioSource, Transform playerPosition)
        {
            if (moveSpeed != Vector3.zero) return;
            if (Time.time < audioTimer) return;

            RaycastHit raycast;
            Physics.Raycast(playerPosition.position, Vector3.down, out raycast);

            Debug.DrawRay(playerPosition.position, Vector3.down, Color.red);
            print(raycast.distance);
            print(raycast.collider.tag);

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