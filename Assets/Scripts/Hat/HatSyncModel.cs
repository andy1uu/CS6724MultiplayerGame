using UnityEngine;

namespace Hat
{
    [RealtimeModel]
    public partial class HatSyncModel
    {
        [RealtimeProperty(1, true, true)] public bool _hat;
    }
}
