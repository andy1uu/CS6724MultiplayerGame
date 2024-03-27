using Normal.Realtime;
using UnityEngine;

namespace RightHand
{
    public class RightHandSync : RealtimeComponent<RightHandSyncModel>
    {
        [SerializeField] public GameObject rightHandModel;
        [SerializeField] public GameObject rightHandCube;
        [SerializeField] public bool rightHand;

        public void Awake() => rightHand = true;

        protected override void OnRealtimeModelReplaced(RightHandSyncModel previousModel, RightHandSyncModel currentModel)
        {
            if (previousModel != null)
            {
                previousModel.rightHandDidChange -= RightHandDidChange;
            }

            if (currentModel != null)
            {
                if (currentModel.isFreshModel)
                    currentModel.rightHand = rightHand;

                UpdateRightHand();

                currentModel.rightHandDidChange += RightHandDidChange;
            }

        }

        private void RightHandDidChange(RightHandSyncModel rightHandSyncModel, bool value)
        {
            UpdateRightHand();
        }

        private void UpdateRightHand()
        {
            rightHand = model.rightHand;

            if (model.rightHand)
            {
                rightHandModel.SetActive(true);
                rightHandCube.SetActive(false);
                Debug.Log("Right Hand is on");
            }
            else
            {
                rightHandModel.SetActive(false);
                rightHandCube.SetActive(false);
                Debug.Log("Right Hand is off");
            }
        }

        public void ToggleRightHand()
        {
            if (!realtimeView.isOwnedLocallySelf) return;

            rightHand = !rightHand;
            model.rightHand = rightHand;
        }
    }
}