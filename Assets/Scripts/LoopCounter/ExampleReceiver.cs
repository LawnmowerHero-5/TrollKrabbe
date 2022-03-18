using UnityEngine;
namespace LoopCounter
{
    public class ExampleReceiver : MonoBehaviour
    {
        //This is not to be in the final build
        //It's here only as documentation on how to implement
        //and as a example on how it was implemented
        public void ReceiveLoopInfo(int loopCount)
        {
            switch (loopCount)
            {
                //Checks if the loop just finished, Example, just met the fox
                case > 0:
                    print("Loop " + loopCount + " Finished");
                    break;
                //Checks if its in the middle of the loop, it's essentially loopCount.5
                //This is only necessary if you want to have actions if you want anything to happen at the halfwayPoint
                case < 0:
                    print("Midway on Loop Nr." + -loopCount);
                    break;
            }
        }
    }
}
