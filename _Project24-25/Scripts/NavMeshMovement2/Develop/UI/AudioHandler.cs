using UnityEngine;
using UnityEngine.Audio;

namespace _Project24_25.NavMesh2
{
    public class AudioHandler
    {
        private const float OffVolumeValue = -80f;
        private const float OnVolumeValue = 0f;

        private const string MusicKey = "MusicVolume";
        private const string SoundKey = "SoundVolume";

        private AudioMixer _audioMixer;


        public AudioHandler(AudioMixer audioMixer)
        {
            _audioMixer = audioMixer;
        }

        public bool IsMusicOn()
            => IsVolumeOn(MusicKey);

        public bool IsSoundOn()
            => IsVolumeOn(SoundKey);

        public void OffMusic()
            => OffVolume(MusicKey);

        public void OnMusic()
            => OnVolume(MusicKey);

        public void OffSound()
            => OffVolume(SoundKey);

        public void OnSound()
            => OnVolume(SoundKey);

        private bool IsVolumeOn(string key)
            => _audioMixer.GetFloat(key, out float volume) && Mathf.Abs(volume - OnVolumeValue) <= 0.1f;

        private void OnVolume(string key)
            => _audioMixer.SetFloat(key, OnVolumeValue);

        private void OffVolume(string key)
            => _audioMixer.SetFloat(key, OffVolumeValue);
    }
}