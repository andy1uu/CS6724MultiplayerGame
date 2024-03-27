using Normal.Realtime;
using UnityEngine;

namespace LeftHand
{
    public class LeftHandSync : RealtimeComponent<LeftHandSyncModel>
    {
        [SerializeField] public GameObject leftHandModel;
        [SerializeField] public GameObject leftHandCube;
        [SerializeField] public bool leftHand;

        public void Awake() => leftHand = true;

        protected override void OnRealtimeModelReplaced(LeftHandSyncModel previousModel, LeftHandSyncModel currentModel)
        {
            if (previousModel != null)
            {
                previousModel.leftHandDidChange -= LeftHandDidChange;
            }

            if (currentModel != null)
            {
                if (currentModel.isFreshModel)
                    currentModel.leftHand = leftHand;

                UpdateLeftHand();

                currentModel.leftHandDidChange += LeftHandDidChange;
            }

        }

        private void LeftHandDidChange(LeftHandSyncModel leftHandSyncModel, bool value)
        {
            UpdateLeftHand();
        }

        private void UpdateLeftHand()
        {
            leftHand = model.leftHand;

            if (model.leftHand)
            {
                leftHandModel.SetActive(true);
                leftHandCube.SetActive(false);
                Debug.Log("Left Hand is on");
            }
            else
            {
                leftHandModel.SetActive(false);
                leftHandCube.SetActive(false);
                Debug.Log("Left Hand is off");
            }
        }

        public void ToggleLeftHand()
        {
            if (!realtimeView.isOwnedLocallySelf) return;

            leftHand = !leftHand;
            model.leftHand = leftHand;
        }
    }
}