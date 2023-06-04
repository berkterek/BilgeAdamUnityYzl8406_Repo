using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public EnemyController Prefab;
    //Range attribute bize inspector uzerinde degerlerle oynammaizi saglan bir slider cikarir
    [Range(3f,10f)]
    public float _maxSpawnTime = 5f;
    [Range(0.1f,3f)]
    public float _minSpawnTime = 1f;
    public float _minMaxYBorder = 2f;

    float _currentTime = 0f;
    float _randomNumber = 0f;

    void Start()
    {
        SetRandomTimeAndSetCurrentTimeToZero();
    }

    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _randomNumber)
        {
            //Instantiate method bizden bir prefab ister ve bu prefab'in bu method clone'unu olusturur
            //clone olusturmak 0'dan olusturmaktan daha performanslidir bu yuzden prefab uzerinden clone yaratiriz
            //bizim kullandigmiz method ikinci paramtre olarak pozisyon ister
            //bizim kullandiigmiz yontem ucuncu parametre olarak rotation ister burdaki quaternion.identity ise bize Vector3.zero ile ayni isi yapar yani 0,0,0,0 sonucunu verir
            Vector3 enemyRandomYPosition = new Vector3(transform.position.x, Random.Range(-_minMaxYBorder, _minMaxYBorder), 0f);
            Instantiate(Prefab, enemyRandomYPosition, Quaternion.identity);
            SetRandomTimeAndSetCurrentTimeToZero();
        }
    }

    private void SetRandomTimeAndSetCurrentTimeToZero()
    {
        _currentTime = 0f;
        _randomNumber = Random.Range(_minSpawnTime, _maxSpawnTime);
    }
}
