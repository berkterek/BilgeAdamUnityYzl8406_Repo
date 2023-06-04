using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] Transform _bodyTransform;
    [SerializeField] float _jumpForce = 100f;
    [SerializeField] float _angleSpeed = 5f;
    [SerializeField] float _positiveAngle = 60f;
    [SerializeField] float _negativeAngle = -80f;

    Rigidbody2D _rigidbody2D;
    bool _isJump;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    //update icinde biz input'larimizi aliriz
    void Update()
    {
        //GetButton => Basma, Basli tutma ve Cekme
        //GetButtonDown => Basma
        //GetButtonUp => Cekme
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Player can jump");
            _isJump = true;
        }

        //bu yapi calismaz hep false'a doner cunku Update her bir frame'de bir calistigi icin bir kere true olucak daha FixedUpdate calismadan _isJump tekrar false olucak bundan dolayi bu kod calismaz
        // _isJump = Input.GetButtonDown("Jump");
        //
        // if (_isJump)
        // {
        //     Debug.Log("Player can jump");
        // }
        //Debug.Log(Time.deltaTime);

        _bodyTransform.eulerAngles += -1f * _angleSpeed * Time.deltaTime * Vector3.forward;
        // float zAngle = _bodyTransform.eulerAngles.z;
        // float maxZAngle = Mathf.Clamp(zAngle,0f, _negativeAngle);
        // _bodyTransform.eulerAngles = new Vector3(0f, 0f, maxZAngle);
    }

    //Fizik islmelerimizi FixedUpdate ile yapariz
    void FixedUpdate()
    {
        //Vector2 directionForce = new Vector2(0f,1f); => kisa yazimi Vector2.up;
        if (_isJump)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(_jumpForce * Time.deltaTime * Vector2.up); //y = 1 / 1*0.15
            _bodyTransform.localEulerAngles = new Vector3(0f, 0f, _positiveAngle);
            _isJump = false;
            Debug.Log("Player is Jumping right now");
        }
    }

    //OnCollissionEnter2D 2d fizik motoru icin calisir ve iki nesne carpistiginda duvar etkisi yarattiginda ilk dokunma icin calir
    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     Debug.Log(nameof(OnCollisionEnter2D));
    // }

    //OnTriggerEnter2D tetiklenen taraf burda player cunku bu method suan player script icinde yazildigi icin bu method'un parametresi Collider2D other ise karsi tarafin bilgisini barindirir yani paramtereyle gelen bilgi karsi tarafin bilgisidir
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(nameof(OnTriggerEnter2D));
        // _gameManager.GameOverProcess();

        //ScoreController bziim player'in score'unu arttirmasina yariyan script'tir. burda yaptigmiz islem carpisma aninda colldier uzerinden o gameobject'in uzerinde ScoreController cek demis olduk if icinde eger score controller null degilse biz uzerinde scorecontroller olan bir game object ile carpismis olduk anlamina gelir ve score'u arttirma yapmamiz gerekir eger null ise biz uzerinde ScoreController olmayan bir game object ile carpismis olduk ve burda ona gore islem yaptirmamiz gerekir.
        ScoreController scoreController = other.GetComponent<ScoreController>();
        if (scoreController != null)
        {
            //score arttir
            //burdaki ornekte biz score'a bir deger atamamamiz lazimdir ki field eger public olursa onceki ornekte oldugu gibi biz deger atayabilir hale getiremis oluruz ki bu encapsulation prensipine aykiridir bunun icin biz field'larimizi private veya protected olarak belirletiz ki disaridan direkt erisim olmasin diye
            //scoreController._score = 50;
            _gameManager.PlayerScore += scoreController.Score;
        }
        else
        {
            _gameManager.GameOverProcess();
        }
    }
}