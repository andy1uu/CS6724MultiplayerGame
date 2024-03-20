using UnityEngine;

namespace RightHand
{
    [RealtimeModel]
    public partial class RightHandSyncModel
    {
        [RealtimeProperty(1, true, true)] public bool _rightHand;
    }
}
