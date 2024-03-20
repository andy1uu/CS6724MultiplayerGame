using UnityEngine;
using Normal.Realtime;
using UnityEngine.SceneManagement;
using System.Collections;

public class AdditiveSceneLoader : MonoBehaviour
{
    [SerializeField] private Realtime[] realtime;
    [SerializeField] private string roomName;
    [SerializeField] private int sceneIndex;

    private bool isLoading;

    public void LoadScene()
    {
        if (isLoading) return;

        isLoading = true;

        StartCoroutine(LoadSceneAdditive());
    }

    IEnumerator LoadSceneAdditive()
    {
        var loadAsync = SceneManager.LoadSceneAsync(sceneIndex);

        while (loadAsync.isDone) yield return null;

        realtime = FindObjectsOfType<Realtime>();

        foreach (var realTime in realtime)
        {
            if (!realTime.connected) realTime.Connect(roomName);
        }

        isLoading = false;
    }
}