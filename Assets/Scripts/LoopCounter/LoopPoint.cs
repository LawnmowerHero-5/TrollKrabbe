using UnityEngine;
namespace LoopCounter
{
    public class LoopPoint : MonoBehaviour
    {
        [SerializeField] private bool isLoopEndPoint;
        private LoopCounter m_Counter;

        private void Awake()
        {
            m_Counter = GetComponentInParent<LoopCounter>();
        }
        private void OnTriggerEnter(Collider other)
        {
            m_Counter.RetrieveLoopPoint(isLoopEndPoint);
        }
    }
}
