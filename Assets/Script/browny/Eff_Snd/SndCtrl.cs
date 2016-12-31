using UnityEngine;
using System.Collections;

public class SndCtrl : MonoBehaviour
{

    static AudioSource BGM, Effloop, Effonce;
    //
    void Awake()
    {
    }
    // Use this for initialization
    void Start()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.loop = true;

        Effloop = gameObject.AddComponent<AudioSource>();
        Effloop.loop = true;

        Effonce = gameObject.AddComponent<AudioSource>();
        Effonce.loop = false;

        BGM.volume = .7f;
    }

    public static void addEffonce(string sndName, string folderName = "eff/")
    {
        AudioClip effect = (AudioClip)Resources.Load(folderName + sndName, typeof(AudioClip));
        Effonce.PlayOneShot(effect);
    }


    public static void addEffonceDelay(string sndName, float _delay = 0, string folderName = "eff/")
    {
        Effonce.Stop();
        Effonce.clip = (AudioClip)Resources.Load(folderName + sndName, typeof(AudioClip));
        Effonce.PlayDelayed(_delay);

    }

    public static void addVoconce(string sndName, string folderName = "voc/")
    {
        AudioClip effect = (AudioClip)Resources.Load(folderName + sndName, typeof(AudioClip));
        Effonce.PlayOneShot(effect);
    }


    public static void addEffloop(string sndName, string folderName = "eff/")
    {
        Effloop.Stop();
        Effloop.clip = (AudioClip)Resources.Load(folderName + sndName, typeof(AudioClip));
        Effloop.Play();
    }

    public static void stoploopEff() { if (Effloop != null) Effloop.Stop(); }

    public static void stoponeEff() { if (Effonce != null) Effonce.Stop(); }

    public static void playBGM(string bgmName, string folderName = "bgm/")
    {
        Effloop.Stop();
        BGM.clip = (AudioClip)Resources.Load(folderName + bgmName);
        BGM.Play();
    }

}
