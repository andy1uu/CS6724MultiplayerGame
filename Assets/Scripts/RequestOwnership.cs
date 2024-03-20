using Normal.Realtime;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RequestOwnership : MonoBehaviour
{
    [SerializeField] private RealtimeView realtimeView;
    [SerializeField] private RealtimeTransform realtimeTransform;
    [SerializeField] private XRGrabInteractable xRGrabInteractable;

    private void OnEnable() => xRGrabInteractable.selectEntered.AddListener(RequestObjectOwnership);

    private void OnDisable() => xRGrabInteractable.selectEntered.RemoveListener(RequestObjectOwnership);

    private void RequestObjectOwnership(SelectEnterEventArgs args)
    {
        realtimeView.RequestOwnership();
        realtimeTransform.RequestOwnership();
    }
}
