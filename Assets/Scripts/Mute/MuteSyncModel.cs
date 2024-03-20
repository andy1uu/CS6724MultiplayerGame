using UnityEngine;

namespace Mute
{
    [RealtimeModel]
    public partial class MuteSyncModel
    {
        [RealtimeProperty(1, true, true)] public bool _mute;
    }
}
