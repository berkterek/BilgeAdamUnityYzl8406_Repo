namespace SpaceShipWars2D.Abstracts.Movements
{
    public interface IAnimationController
    {
        void Tick(float xDirection);
        void LateTick();
    }
}