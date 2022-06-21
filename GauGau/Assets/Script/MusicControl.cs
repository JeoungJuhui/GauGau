using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicControl : MonoBehaviour
{
    static AudioSource audioSource;
    static AudioSource BGMaudioSource;

    GameControl gameControl;

    static bool BGMplay = false;

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

    //volume
    public float volume;
    public float BGMvolume;

    //Slider
    Slider musicSlider;
    Slider BGMSlider;

    BGMPlay bGMPlay;
    EffectPlay effectPlay;

    // Start is called before the first frame update



    public abstract class SoundCommand
    {
        public abstract void SetClip(AudioClip audioClip, AudioClip currentAudio,int stage );
        public virtual void StopClip() 
        {
            BGMaudioSource.Stop();
            BGMplay = false;
        }
       
    }
    public class BGMPlay : SoundCommand
    {
        public override void SetClip(AudioClip audioClip, AudioClip currentAudio, int stage)
        {
            if(currentAudio!=audioClip)
            {
                if (BGMplay)
                    base.StopClip();
             
                BGMaudioSource.clip = audioClip;
                BGMaudioSource.loop = true;
                BGMaudioSource.Play();
            }
        }
    }

    public class EffectPlay : SoundCommand
    {
        public override void SetClip(AudioClip audioClip, AudioClip currentAudio=null, int stage=0)
        {
            audioSource.clip = audioClip;
            audioSource.loop = false;
            audioSource.Play();
        }
    }

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        BGMaudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        gameControl = gameObject.GetComponent<GameControl>();

        BGMSlider = GameObject.Find("BGMSlider").GetComponent<Slider>();
        musicSlider = GameObject.Find("musicSlider").GetComponent<Slider>();
        musicSlider.value = 1.0f;
        BGMSlider.value = 1.0f;

        bGMPlay = new BGMPlay();
        effectPlay = new EffectPlay();

    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicSlider.value;
        BGMaudioSource.volume = BGMSlider.value;

        //더 간략하게 방법. 리스트 형식으로 BGM저장, 스테이지에 따라 플레이
        switch (gameControl.stage)
        {
            case 1:
                if (!BGMplay)
                {
                    bGMPlay.SetClip(Stage1, BGMaudioSource.clip, gameControl.stage);
                    BGMplay = true;
                }
                break;

            case 2:
                if(BGMaudioSource.clip!=Stage2)
                {
                    bGMPlay.SetClip(Stage2, BGMaudioSource.clip, gameControl.stage);
                }
                break;

            case 3:
                if (BGMaudioSource.clip != Stage3)
                {
                    bGMPlay.SetClip(Stage3, BGMaudioSource.clip, gameControl.stage);
                }
                break;
        }

    }

    public void GetCoinSound()
    {
        effectPlay.SetClip(CoinSound);
    }
    public void HurtSound()
    {
        effectPlay.SetClip(whine);
    }
    public void BarkSound()
    {
        effectPlay.SetClip(Bark);
    }
    public void BiteSound()
    {
        effectPlay.SetClip(Growl);
    }

    public void GameClearSound()
    {
        effectPlay.SetClip(ClearSound);
    }
    public void GameOverSound()
    {
        effectPlay.SetClip(OverSound);
    }



}
