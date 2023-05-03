using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip effectSound;
    public void playSound()
    {
        SoundManager.Instance.PlaySFX(effectSound);

    }
}
