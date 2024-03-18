using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

[RealtimeModel]
public partial class LightChangerModel
{
    [RealtimeProperty(1, true, true)] private Color _color;
}
