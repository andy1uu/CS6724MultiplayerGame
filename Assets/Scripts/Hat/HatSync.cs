using Normal.Realtime;
using UnityEngine;

namespace Hat
{
    public class HatSync : RealtimeComponent<HatSyncModel>
    {
        [SerializeField] public GameObject playerHat;
        [SerializeField] public bool hat;

        public void Awake() => hat = false;

        protected override void OnRealtimeModelReplaced(HatSyncModel previousModel, HatSyncModel currentModel)
        {
            if (previousModel != null)
            {
                previousModel.hatDidChange -= HatDidChange;
            }

            if (currentModel != null)
            {
                if (currentModel.isFreshModel)
                    currentModel.hat = hat;

                UpdateHat();

                currentModel.hatDidChange += HatDidChange;
            }

        }

        private void HatDidChange(HatSyncModel hatSyncModel, bool value)
        {
            UpdateHat();
        }

        private void UpdateHat()
        {
            hat = model.hat;

            if (model.hat)
            {
                playerHat.SetActive(true);
                Debug.Log("Hat is on");
            }
            else
            {
                playerHat.SetActive(false);
                Debug.Log("Hat is off");
            }
        }

        public void ToggleHat()
        {
            if (!realtimeView.isOwnedLocallySelf) return;

            hat = !hat;
            model.hat = hat;
        }
    }
}