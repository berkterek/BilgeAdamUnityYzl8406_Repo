using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _jumpForce = 100f;
    
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
        Debug.Log(Time.deltaTime);
    }

    //Fizik islmelerimizi FixedUpdate ile yapariz
    void FixedUpdate()
    {
        //Vector2 directionForce = new Vector2(0f,1f); => kisa yazimi Vector2.up;
        if (_isJump)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(_jumpForce * Time.deltaTime * Vector2.up); //y = 1 / 1*0.15
            _isJump = false;
            Debug.Log("Player is Jumping right now");
        }
    }
}