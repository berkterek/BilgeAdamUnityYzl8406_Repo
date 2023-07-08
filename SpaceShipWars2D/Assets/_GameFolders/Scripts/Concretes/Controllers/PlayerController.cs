using SpaceShipWars2D.Abstracts.Combats;
using SpaceShipWars2D.Abstracts.Inputs;
using SpaceShipWars2D.Abstracts.Movements;
using SpaceShipWars2D.Combats;
using SpaceShipWars2D.Inputs;
using SpaceShipWars2D.Movements;
using SpaceShipWars2D.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class PlayerController : MonoBehaviour,IEntityController
    {
        [SerializeField] Sprite[] _sprites;
        [SerializeField] SpriteRenderer _spriteRenderer;
        [SerializeField] PlayerStatsSO _playerStats;

        IMover _mover;
        IMovementBorder _movementBorder;
        IInputReader _inputReader;
        IAnimationController _animation;
        IFireHandler _fireHandler;

        void OnValidate()
        {
            if (_spriteRenderer == null) _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        void Awake()
        {
            _inputReader = new InputReaderNormal();
            _mover = new MoveWithTranslate(new MovementData()
            {
                Transform = this.transform,
                MovementStats = _playerStats
            });
            _movementBorder = new MovementBorderForTransform(this.transform);
            _animation = new PlayerAnimationWithSprite(new PlayerAnimationWithSpriteData()
            {
                Sprites = _sprites,
                SpriteRenderer = _spriteRenderer
            });
            _fireHandler = new FireHandler(new FireData()
            {
                Transform = this.transform,
                AttackStats = _playerStats
            });
        }

        void Update()
        {
            _mover.Tick(_inputReader.Direction);
            _movementBorder.Tick();
            _animation.Tick(_inputReader.Direction.x);
            _fireHandler.Tick();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }

        void LateUpdate()
        {
            _animation.LateTick();
        }
    }

    public interface IEntityController
    {
        Transform transform { get; }
    }
}