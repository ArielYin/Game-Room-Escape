using UnityEngine;
using System.Collections;
using System.Collections.Generic; //Generic collection namespace

public class AudioManager : MonoBehaviour
{
    public AudioClip[] AudioClipArray; //clip array
    public static float AudioBackgroundVolumns = 1F; //background volume
    public static float AudioEffectVolumns = 1F; //sound effect volume

    private static Dictionary<string, AudioClip> _DicAudioClipLib; //audio clip library
    private static AudioSource[] _AudioSourceArray; //audio source array
    public static AudioSource _AudioSource_BackgroundAudio; //background sound
    public static AudioSource _AudioSource_AudioEffectA; //audio effectA
    public static AudioSource _AudioSource_AudioEffectB; //audio effectB

    /// <summary>
    /// audio loading
    /// </summary>
    void Awake()
    {
        //audioclip
        _DicAudioClipLib = new Dictionary<string, AudioClip>();
        foreach (AudioClip audioClip in AudioClipArray)
        {
            _DicAudioClipLib.Add(audioClip.name, audioClip);
        }
        //prossing
        _AudioSourceArray = this.GetComponents<AudioSource>();
        _AudioSource_BackgroundAudio = _AudioSourceArray[0];
        _AudioSource_AudioEffectA = _AudioSourceArray[1];
        _AudioSource_AudioEffectB = _AudioSourceArray[2];

        //get volume
        if (PlayerPrefs.GetFloat("AudioBackgroundVolumns") >= 0)
        {
            AudioBackgroundVolumns = PlayerPrefs.GetFloat("AudioBackgroundVolumns");
            _AudioSource_BackgroundAudio.volume = AudioBackgroundVolumns;
        }
        if (PlayerPrefs.GetFloat("AudioEffectVolumns") >= 0)
        {
            AudioEffectVolumns = PlayerPrefs.GetFloat("AudioEffectVolumns");
            _AudioSource_AudioEffectA.volume = AudioEffectVolumns;
            _AudioSource_AudioEffectB.volume = AudioEffectVolumns;
        }
    }//Start_end

    /// <summary>
    /// background
    /// </summary>
    /// <param name="audioClip">audio edit</param>
    public static void PlayBackground(AudioClip audioClip)
    {
        //avoid replace background
        if (_AudioSource_BackgroundAudio.clip == audioClip)
        {
            return;
        }
        //the background volume
        _AudioSource_BackgroundAudio.volume = AudioBackgroundVolumns;
        if (audioClip)
        {
            _AudioSource_BackgroundAudio.clip = audioClip;
            _AudioSource_BackgroundAudio.Play();
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayBackground()] audioClip==null !");
        }
    }

    //play background
    public static void PlayBackground(string strAudioName)
    {
        if (!string.IsNullOrEmpty(strAudioName))
        {
            PlayBackground(_DicAudioClipLib[strAudioName]);
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayBackground()] strAudioName==null !");
        }
    }

    /// <summary>
    /// play effect
    /// </summary>
    /// <param name="audioClip">sound effect edit</param>
    private static void PlayAudioEffectA(AudioClip audioClip)
    {
        //process the audio effect
        _AudioSource_AudioEffectA.volume = AudioEffectVolumns;

        if (audioClip)
        {
            _AudioSource_AudioEffectA.clip = audioClip;
            _AudioSource_AudioEffectA.Play();
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayAudioEffectA()] audioClip==null ! Please Check! ");
        }
    }

    /// <summary>
    /// play sound effectA
    /// </summary>
    /// <param name="audioClip">audio edit</param>
    private static void PlayAudioEffectB(AudioClip audioClip)
    {
        //play audioeffect
        _AudioSource_AudioEffectB.volume = AudioEffectVolumns;

        if (audioClip)
        {
            _AudioSource_AudioEffectB.clip = audioClip;
            _AudioSource_AudioEffectB.Play();
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayAudioEffectB()] audioClip==null ! Please Check! ");
        }
    }

    /// <summary>
    /// soundA
    /// </summary>
    /// <param name="strAudioEffctName">name</param>
    public static void PlayAudioEffectA(string strAudioEffctName)
    {
        if (!string.IsNullOrEmpty(strAudioEffctName))
        {
            PlayAudioEffectA(_DicAudioClipLib[strAudioEffctName]);
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayAudioEffectA()] strAudioEffctName==null ! Please Check! ");
        }
    }

    /// <summary>
    /// effectB
    /// </summary>
    /// <param name="strAudioEffctName">name</param>
    public static void PlayAudioEffectB(string strAudioEffctName)
    {
        if (!string.IsNullOrEmpty(strAudioEffctName))
        {
            PlayAudioEffectB(_DicAudioClipLib[strAudioEffctName]);
        }
        else
        {
            Debug.LogWarning("[AudioManager.cs/PlayAudioEffectB()] strAudioEffctName==null ! Please Check! ");
        }
    }

    /// <summary>
    /// change background volume
    /// </summary>
    /// <param name="floAudioBGVolumns"></param>
    public static void SetAudioBackgroundVolumns(float floAudioBGVolumns)
    {
        _AudioSource_BackgroundAudio.volume = floAudioBGVolumns;
        AudioBackgroundVolumns = floAudioBGVolumns;
        //Data persistence
        PlayerPrefs.SetFloat("AudioBackgroundVolumns", floAudioBGVolumns);
    }

    /// <summary>
    /// change sound effect volume
    /// </summary>
    /// <param name="floAudioEffectVolumns"></param>
    public static void SetAudioEffectVolumns(float floAudioEffectVolumns)
    {
        _AudioSource_AudioEffectA.volume = floAudioEffectVolumns;
        _AudioSource_AudioEffectB.volume = floAudioEffectVolumns;
        AudioEffectVolumns = floAudioEffectVolumns;
        //Data persistence
        PlayerPrefs.SetFloat("AudioEffectVolumns", floAudioEffectVolumns);
    }
}