using Mute;
using Hat;
using LeftHand;
using RightHand;
using Normal.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Name
{
    public class UpdateAvatar : MonoBehaviour
    {
        [SerializeField] private Button muteButton;
        [SerializeField] private Button hatButton;
        [SerializeField] private Button leftHandButton;
        [SerializeField] private Button rightHandButton;

        private RealtimeAvatarManager _realtimeAvatarManager;
        private RealtimeAvatar _realtimeAvatar;
        private string _localPlayerName;

        private void Awake() => _realtimeAvatarManager = GetComponent<RealtimeAvatarManager>();

        private void OnEnable() => _realtimeAvatarManager.avatarCreated += AvatarCreated;

        private void OnDisable() => _realtimeAvatarManager.avatarCreated -= AvatarCreated;


        private void AvatarCreated(RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar)
        {
            if (isLocalAvatar)
            {
                _realtimeAvatar = avatar;
            }

            muteButton.onClick.AddListener(avatar.GetComponentInChildren<MuteSync>().ToggleVoiceChat);
            hatButton.onClick.AddListener(avatar.GetComponentInChildren<HatSync>().ToggleHat);
            leftHandButton.onClick.AddListener(avatar.GetComponentInChildren<LeftHandSync>().ToggleLeftHand);
            rightHandButton.onClick.AddListener(avatar.GetComponentInChildren<RightHandSync>().ToggleRightHand);
        }

        public void SaveLocalPlayerName(Text nameField)
        {
            _localPlayerName = nameField.text;
            _realtimeAvatar.GetComponentInChildren<NameSync>().SetText(_localPlayerName);
        }

    }
}
