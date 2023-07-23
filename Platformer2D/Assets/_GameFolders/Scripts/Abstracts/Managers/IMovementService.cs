namespace Platformer2D.Abstracts.Managers
{
    public interface IMovementService
    {
        void Tick();
        void FixedTick();
        void LateTick();
    }

    public interface IPlayerMoveService : IMovementService
    {
        void ResetJumpCounter();
    }
}