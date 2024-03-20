using System;
using Normal.Realtime;
using TMPro;
using UnityEngine;

namespace Name
{
    public class NameSync : RealtimeComponent<NameSyncModel> 
    {
        [SerializeField] private TextMeshPro _textMeshProText;

        protected override void OnRealtimeModelReplaced(NameSyncModel previousModel, NameSyncModel currentModel)
        {
            base.OnRealtimeModelReplaced(previousModel, currentModel);

            if (previousModel != null) previousModel.nameDidChange -= NameDidChange;

            if (currentModel != null) {

                if (currentModel.isFreshModel) currentModel.name = _textMeshProText.text;

                UpdateName();

                currentModel.nameDidChange += NameDidChange;
            }
        }

        private void UpdateName()
        {
            _textMeshProText.text = model.name;
        }

        private void NameDidChange(NameSyncModel model, string value)
        {
            UpdateName();
        }

        public void SetText(string name)
        {
            model.name = name;
        }
    }
}
