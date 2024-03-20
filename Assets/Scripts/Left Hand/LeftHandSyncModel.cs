using UnityEngine;

namespace LeftHand
{
    [RealtimeModel]
    public partial class LeftHandSyncModel
    {
        [RealtimeProperty(1, true, true)] public bool _leftHand;
    }
}
