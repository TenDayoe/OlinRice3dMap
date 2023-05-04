using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance ; 
    [SerializeField]
    private AudioSource SFXSource;
    [SerializeField]
    private AudioSource musicSource; 
    private void Awake(){
        if (Instance == null){
            Instance = this ; 
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void toggleMusic(){
        musicSource.mute = !musicSource.mute;
    }
    public void PlaySFX(AudioClip aclip){
        SFXSource.PlayOneShot(aclip);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
