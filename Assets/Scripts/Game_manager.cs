using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_manager : MonoBehaviour
{

    private SFXManager sfxManager;

    private BGMManager bgmManager;


    void Awake()

    {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
    }

    public void DeathMario()
    {
        sfxManager.DeathSound();
        bgmManager.StopBGM();
    }



    public void DeathGoomba(GameObject goomba)
    {

        //Funcion matar Goombas
        Animator goombaAnimator;

        //variable para el script del goomba
        Enemigos goombaScript;

        //variable para el collider 
        BoxCollider2D goombaCollider;

        //Asignamos la variable
        goombaScript = goomba.GetComponent<Enemigos>();
        goombaAnimator = goomba.GetComponent<Animator>();
        goombaCollider = goomba.GetComponent<BoxCollider2D>();

        //cambiamos a la animacion de muerte
        goombaAnimator.SetBool("Goomba_death", true);

        //cambiamos la variable del goomba a false
        goombaScript.isAlive = false;

        goombaCollider.enabled = false;

        //destruimos el goomba
        Destroy(goomba, 0.3f);

        // llamamos la funcion de sonido muerte gomba
        sfxManager.GoombaSound();

    }

    public void Catchcoin(GameObject Coin)
    {
        Animator coinAnimator;
        BoxCollider2D coinCollider;
        //valor asignado
        coinCollider = Coin.GetComponent<BoxCollider2D>();
        coinAnimator = Coin.GetComponent<Animator>();
        sfxManager.CoinSound();
    }

    public void CatchFlag(GameObject Bandera)
    {
        BoxCollider2D BanderaCollider;
        //valor asignado
        BanderaCollider = Bandera.GetComponent<BoxCollider2D>();
        sfxManager.BanderaSound();
        SceneManager.LoadScene("FINAL");
    }

    public void BanderaVictoria (GameObject bandera)
    {
        BoxCollider2D banderaCollider;

        banderaCollider = bandera.GetComponent<BoxCollider2D>();

        sfxManager.CogerBandera();
    }


}
