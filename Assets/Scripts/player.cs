using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour

{
    //variables para velocidad-fuerza de salto
    public float speed = 5f; 
    public float jumpForce = 10f;
    //variable para saber siestamos en el suelo
    public bool isGorounded;
    //variable para almacenar el movimiento
    float dirX; 

    //variables de componentes
    public SpriteRenderer renderer;
    public Animator _animator;
    Rigidbody2D _lorenabody; 
    private Game_manager gameManager;
    private SFXManager SFXManager;

    

    void Awake()
    {

      //asignamos los componentes de las variables
      _animator = GetComponent<Animator>(); 
      _lorenabody = GetComponent<Rigidbody2D>();
      gameManager = GameObject.Find("Game_manager").GetComponent<Game_manager>();
      SFXManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();

    }



    // Update is called once per frame
    void Update()
    {
      dirX = Input.GetAxisRaw("Horizontal");  

      Debug.Log(dirX);

       /*transform.position += new Vector3(dirX, 0, 0) * speed * Time.deltaTime;*/

      if(dirX == -1)
      {
         renderer.flipX = true; 
         _animator.SetBool("Running", true);
      }
        else if(dirX == 1)
     {
        renderer.flipX = false;
        _animator.SetBool("Running", true);
    }
      else 
      {
        _animator.SetBool("Running", false);
      }

      if(Input.GetButtonDown("Jump") && isGorounded)
      {
        _lorenabody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
        _animator.SetBool("Jumping", true);
      }

  }

  

  void FixedUpdate()
  {
  _lorenabody.velocity = new Vector2(dirX * speed, _lorenabody.velocity .y);

  }

  void OnTriggerEnter2D(Collider2D collider)
  {

    /*if(collider.gameObject.CompareTag("Goombas")){

      Debug.Log("Goomba muerto");

    } */

    if(collider.gameObject.layer == 6){

      Debug.Log("Goomba muerto");
      //llamamos a la funcion DeathGoomba del script Game_manager
      gameManager.DeathGoomba(collider.gameObject);

    }

    if(collider.gameObject.CompareTag("Dead_zone"))
    {

      Debug.Log("Muere");
      gameManager.DeathMario();

    }

     if(collider.gameObject.CompareTag("Monedas"))
     {

    Debug.Log("Moneda cogida");
    Destroy(collider.gameObject);
    SFXManager.CoinSound();

    }  
   if(collider.gameObject.CompareTag("Bandera"))
     {

    Debug.Log("Bandera cogida");

    SFXManager.BanderaSound();

    SceneManager.LoadScene("FINAL");

    }  
  }


   

}
