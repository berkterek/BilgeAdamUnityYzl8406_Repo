using SpaceShipWars2D.Enums;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    //RequiredComponent su anlama gelir eger bu class bir game object uzerinde kullaniliyorsa required ile istenen class olmak zorunda demis oluyoruz
    [RequireComponent(typeof(AudioSource))]
    public class OneShotSoundPlayerController : MonoBehaviour
    {
        [SerializeField] SoundName _soundName;
        [SerializeField] AudioSource _audioSource;

        public SoundName SoundName => _soundName;

        void OnValidate()
        {
            if (_audioSource == null)
            {
                _audioSource = GetComponent<AudioSource>();
            }
        }

        public void Play()
        {
            _audioSource.Play();
        }

        public void Stop()
        {
            _audioSource.Stop();
        }
    }    
}

