using System;
using UnityEngine;
namespace LoopCounter
{
    public class LoopCounter : MonoBehaviour
    {
        private bool m_HasCrossedMid = true;
        public int loopCount = 0;

        public void RetrieveLoopPoint(bool isEndPoint)
        {
            print("isEndPoint = " + isEndPoint);
            if (!isEndPoint & !m_HasCrossedMid)
            {
                m_HasCrossedMid = true;
                gameObject.SendMessage("ReceiveLoopInfo", -loopCount);
                print("Has Crossed Mid = " + m_HasCrossedMid);
            }
            else if (isEndPoint & m_HasCrossedMid)
            {
                m_HasCrossedMid = false;
                loopCount += 1;
                print("loopCount = " + loopCount);
                // Calls the function "ReceiveLoopInfo" with a value of the loopCount, a negative count signifies that it is a halfway point
                // Every script attached to this game object that has a "ReceiveLoopInfo" function will be called.
                // If you want the script to send a message to another gameObject, define which gameObject 
                gameObject.SendMessage("ReceiveLoopInfo", loopCount);
            }
        }
        public void Reset()
        {
            m_HasCrossedMid = true;
            loopCount = 0;
            // Sends a message that the loopCount is 0, so make sure that the script will reset if it receives 0 in LoopInfo
            gameObject.SendMessage("ReceiveLoopInfo", loopCount);
        }
    }
}
