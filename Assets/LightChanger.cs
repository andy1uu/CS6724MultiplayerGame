using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Normal.Realtime;
using UnityEngine;

public class LightChanger : RealtimeComponent<LightChangerModel>
{
    public Color[] colors;
    private Light spotLight;
    private int currLightIndex = 0;

    private void Awake()
    {
        spotLight = GetComponent<Light>();
    }

    protected override void OnRealtimeModelReplaced(LightChangerModel previousModel, LightChangerModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.colorDidChange -= ColorDidChange;
        }

        if (currentModel != null)
        {
            if(currentModel.isFreshModel)
            {
                currentModel.color = spotLight.color;
            }
            UpdateLightColor();
            currentModel.colorDidChange += ColorDidChange;
        }
    }

    private void ColorDidChange(LightChangerModel model, Color value)
    {
        UpdateLightColor();
    }

    void UpdateLightColor ()
    {
        spotLight.color = model.color;
    }

    public void ChangeColor()
    {
        if(currLightIndex < colors.Length - 1)
        {
            currLightIndex += 1;
        }
        else
        {
            currLightIndex = 0;
        }
        model.color = colors[currLightIndex];
    }
}
