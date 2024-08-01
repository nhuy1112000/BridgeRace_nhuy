using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : UICanvas
{
    public void PlayButton()
    {
        UIManager.Instance.OpenUI<GamePlay>();
        LevelManager.Instance.OnPlay();
        Close(0);
        
    }
}
