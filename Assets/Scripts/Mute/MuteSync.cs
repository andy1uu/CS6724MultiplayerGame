using System;
using System.Collections;
using System.Collections.Generic;
using Normal.Realtime;
using UnityEngine;

namespace Mute
{
    public class MuteSync : RealtimeComponent<MuteSyncModel>
    {
        [SerializeField] public RealtimeAvatarVoice realtimeAvatarVoice;
        [SerializeField] public SpriteRenderer voiceChatRenderer;
        [SerializeField] public Sprite[] voiceChatSprites;
        [SerializeField] public bool mute;

        public void Awake() => realtimeAvatarVoice = GetComponentInChildren<RealtimeAvatarVoice>();

        protected override void OnRealtimeModelReplaced(MuteSyncModel previousModel, MuteSyncModel currentModel)
        {
            if (previousModel != null)
            {
                previousModel.muteDidChange -= MuteDidChange;
            }

            if (currentModel != null)
            {
                if (currentModel.isFreshModel)
                    currentModel.mute = mute;

                UpdateMute();

                currentModel.muteDidChange += MuteDidChange;
            }

        }

        private void MuteDidChange(MuteSyncModel muteSyncModel, bool value)
        {
            UpdateMute();
        }

        private void UpdateMute()
        {
            mute = model.mute;

            if (model.mute)
            {
                realtimeAvatarVoice.mute = true;
                voiceChatRenderer.sprite = voiceChatSprites[0];
            }
            else
            {
                realtimeAvatarVoice.mute = false;
                voiceChatRenderer.sprite = voiceChatSprites[1];
            }
        }

        public void ToggleVoiceChat()
        {
            if (!realtimeView.isOwnedLocallySelf) return;

            mute = !mute;
            model.mute = mute;
        }
    }
}