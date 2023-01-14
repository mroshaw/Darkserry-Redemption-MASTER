using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaftAppleGames.Debugging
{
    public interface IDebugModule
    {
        abstract string ModuleName();
        abstract void ToggleUI();
        abstract void ShowUI();
        abstract void HideUI();
        abstract void Register(DebugManager debugManager);
    }
}
