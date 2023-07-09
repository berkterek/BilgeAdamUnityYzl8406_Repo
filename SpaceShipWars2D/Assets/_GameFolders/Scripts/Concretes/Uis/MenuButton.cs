using SpaceShipWars2D.Managers;

namespace SpaceShipWars2D.Uis
{
    public class MenuButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.Menu();
        }
    }
}