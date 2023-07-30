using UnityEngine;

namespace Platformer2D.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Item Data Container", menuName = "Bilge Adam/Data Container/Item Data Container")]
    public class ItemDataContainer : ScriptableObject
    {
        [SerializeField] string _itemName;
        [SerializeField] Sprite _itemSprite;
        [SerializeField] GameObject _prefab;

        public string ItemName => _itemName;
        public Sprite ItemSprite => _itemSprite;
        public GameObject Prefab => _prefab;
    }
}