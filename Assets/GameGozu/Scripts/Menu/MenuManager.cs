using DG.Tweening;
using UnityEngine;

public class MenuManager : MasterManager
{

   

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
