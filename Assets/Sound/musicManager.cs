using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class musicManager : MonoBehaviour
{
    public bool musicOn ;
    public Sprite musicOnSprite; 
    public Sprite musicOffSprite; 
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        musicOn = true;
        img.sprite = musicOffSprite;
    }

    public void changeMusicState(){
        if (musicOn == true){
            musicOn = false; 
            img.sprite = musicOnSprite;
            SoundManager.Instance.toggleMusic();
        }else{
            musicOn = true; 
            img.sprite = musicOffSprite;
            SoundManager.Instance.toggleMusic();
        }
    }
}
