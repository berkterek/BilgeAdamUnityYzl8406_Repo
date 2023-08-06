using Platformer2D.Abstracts.Uis;
using Platformer2D.Managers;
using UnityEngine;

namespace Platformer2D.Uis
{
    public class ExitButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.ExitGame();
        }
    }
}