using UnityEngine;

public class ScoreController : MonoBehaviour
{
    //SerializeFiled bizim private veya protected olan bir field'imizi ayni zamanda inspector uzerinde de erisileblir hale gelirmesidir boylelikle inspector'un gucunu kullanabliriz
    [SerializeField] int _minScore = 1;
    [SerializeField] int _maxScore = 1;
    [SerializeField] int _score = 1;

    //property kisa yazimi
    public int Score => _score;

    //property uzun yazimi
    // public int Score
    // {
    //     get
    //     {
    //         return _score;
    //     }
    // }  

    void Start()
    {
        _score = Random.Range(_minScore, _maxScore);
    }

    //method uzun yazimi
    // public int GetScore()
    // {
    //     return _score;
    // }
    
    //method kisa yazimi
    //public int GetScore() => _score;
}