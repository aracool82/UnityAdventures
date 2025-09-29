using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace _Project24_25.NavMesh2
{
    public class AudioManager : MonoBehaviour
    {
        private const string OnMusic = "Music On";
        private const string OffMusic = "Music Off";
        
        private const string OnSound = "Sound On";
        private const string OffSound = "Sound Off";
        
        [SerializeField] private Button _buttonOnOffMusic;
        [SerializeField] private TMP_Text _textMusic;
        
        [SerializeField] private Button _buttonOnOffSound;
        [SerializeField] private TMP_Text _textSound;
        
        [SerializeField] private AudioMixer _mixer;
        
        private AudioHandler _audioHandler;
        
        private bool _isPessedMusicButoon = false;
        private bool _isPessedSoundButoon = false;
        
        private void Awake()
        {
            _audioHandler = new AudioHandler(_mixer);

            ClickButtonOnOffMusic();
            ClickButtonOnOffSound();
        }

        public void ClickButtonOnOffMusic()
        {
            _isPessedMusicButoon = !_isPessedMusicButoon;

            if (_isPessedMusicButoon)
            {
                PlayMusic();
                _textMusic.text = OnMusic;
            }
            else
            {
                StopMusic();
                _textMusic.text = OffMusic;
            }
        }

        public void ClickButtonOnOffSound()
        {
            _isPessedSoundButoon = !_isPessedSoundButoon;

            if (_isPessedSoundButoon)
            {
                PlaySound();
                _textSound.text = OnSound;
            }
            else
            {
                StopSound();
                _textSound.text = OffSound;
            }
        }
        
        private void PlayMusic()
            =>_audioHandler.OnMusic();
        
        private void StopMusic()
            =>_audioHandler.OffMusic();
        
        
        private void PlaySound()
            =>_audioHandler.OnSound();
        
        private void StopSound()
            =>_audioHandler.OffSound();
    }
}