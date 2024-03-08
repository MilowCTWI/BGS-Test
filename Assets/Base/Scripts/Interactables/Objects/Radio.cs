using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Interactable
{
    [SerializeField]
    private AudioSource _music;
    [SerializeField]
    private GameObject _musicNotes;

    private void Start()
    {
        if (PlayerPrefs.GetInt("PlayMusic", 1) == 1)
        {
            _musicNotes.SetActive(true);
            _music.Play();
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();

        if (_music.isPlaying)
        {
            _musicNotes.SetActive(false);
            _music.Stop();
            PlayerPrefs.SetInt("PlayMusic", 0);
        }
        else
        {
            _musicNotes.SetActive(true);
            _music.Play();
            PlayerPrefs.SetInt("PlayMusic", 1);
        }
    }
}
