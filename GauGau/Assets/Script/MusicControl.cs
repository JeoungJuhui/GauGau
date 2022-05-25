using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    AudioSource audioSource;
    AudioSource BGMaudioSource;

    GameControl gameControl;

    bool BGMplay = false;

    //BGM
    public AudioClip Stage1;
    public AudioClip Stage2;
    public AudioClip Stage3;

    //DogSound
    public AudioClip Bark;
    public AudioClip Growl;
    public AudioClip whine;

    //Clear/Over

    public AudioClip ClearSound;
    public AudioClip OverSound;

    //Coin

    public AudioClip CoinSound;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        BGMaudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        gameControl = gameObject.GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameControl.stage)
        {
            case 1:
                if (!BGMplay)
                {
                    BGMaudioSource.clip = Stage1;
                    BGMaudioSource.loop = true;
                    BGMaudioSource.Play();
                    BGMplay = true;
                }
                break;

            case 2:
                if(BGMaudioSource.clip!=Stage2)
                {
                    BGMaudioSource.Stop();
                    BGMplay = false;
                }
                if (!BGMplay)
                {
                    BGMaudioSource.clip = Stage2;
                    BGMaudioSource.loop = true;
                    BGMaudioSource.Play();
                    BGMplay = true;
                }
                break;

            case 3:
                if (BGMaudioSource.clip != Stage3)
                {
                    BGMaudioSource.Stop();
                    BGMplay = false;
                }
                if (!BGMplay)
                {
                    BGMaudioSource.clip = Stage3;
                    BGMaudioSource.loop = true;
                    BGMaudioSource.Play();
                    BGMplay = true;
                }
                break;
        }

    }

    public void GetCoinSound()
    {
        audioSource.clip = CoinSound;
        audioSource.loop = false;
        audioSource.Play();
    }
    public void HurtSound()
    {
        audioSource.clip = whine;
        audioSource.loop = false;
        audioSource.Play();
    }
    public void BarkSound()
    {
        audioSource.clip = Bark;
        audioSource.loop = false;
        audioSource.Play();
    }
    public void BiteSound()
    {
        audioSource.clip = Growl;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void GameClearSound()
    {
        audioSource.clip = ClearSound;
        audioSource.loop = false;
        audioSource.Play();
    }
    public void GameOverSound()
    {
        audioSource.clip = OverSound;
        audioSource.loop = false;
        audioSource.Play();
    }



}
