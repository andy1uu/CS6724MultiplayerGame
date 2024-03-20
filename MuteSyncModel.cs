using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RealtimeModel]
public partial class MuteSyncModel
{
    [RealtimeProperty(1, true, true)] public bool _mute;
}
