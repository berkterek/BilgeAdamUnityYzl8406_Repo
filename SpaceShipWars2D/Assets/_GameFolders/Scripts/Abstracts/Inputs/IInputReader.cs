using UnityEngine;

namespace SpaceShipWars2D.Abstracts.Inputs
{
    public interface IInputReader
    {
        public Vector2 Direction { get; }
    }
}