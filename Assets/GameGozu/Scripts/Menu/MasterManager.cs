using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;
using TMPro;
using UnityEngine.InputSystem;

public class MasterManager : MonoBehaviour
{

    [SerializeField] protected float durationFadePanel;
    public static event Action<int> OnChangeScene;

    protected void FadeObject(CanvasGroup canvas, float endValue, float duration, Action action)
    {
        canvas.DOFade(endValue, duration).SetUpdate(true).OnComplete(() => action?.Invoke());

    }



    public void FadePanelIn(CanvasGroup canvas)
    {

        FadeObject(canvas, 1f, durationFadePanel, () =>
        {
            canvas.interactable = true;
            canvas.blocksRaycasts = true;
        });

    }

    public void FadePanelOut(CanvasGroup canvas)
    {
        FadeObject(canvas, 0f, durationFadePanel, () =>
        {
            canvas.interactable = false;
            canvas.blocksRaycasts = false;
        });
    }


    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);

        if (sceneName == "Menu")
        {
            OnChangeScene?.Invoke(0);
        }
        else if (sceneName == "Game")
        {
            OnChangeScene?.Invoke(1);
        }
    }

}
