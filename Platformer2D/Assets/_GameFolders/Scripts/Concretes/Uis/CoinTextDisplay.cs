using TMPro;
using UnityEngine;

namespace Platformer2D.Uis
{
    public class CoinTextDisplay : MonoBehaviour
    {
        [SerializeField] TMP_Text _text;

        void OnValidate()
        {
            if (_text == null) _text = GetComponent<TMP_Text>();
        }
        
        
    }    
}

