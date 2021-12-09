using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Ins;
    public List<AudioSource> audioList;
    void Awake() {
        Ins = this;    
    }
    public void PlaySound(int _sound){
        audioList[_sound].Play();
    }
}
