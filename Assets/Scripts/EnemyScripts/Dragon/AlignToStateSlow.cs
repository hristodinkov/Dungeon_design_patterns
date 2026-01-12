using UnityEngine;

public class AlignToStateSlow : AlignToState
{
    public AlignToStateSlow(Transform self, Blackboard bb) : base(self, bb)
    {
        bb.rotateSpeed = 60f; 
    }
}
