using System.Linq;
using SpaceShipWars2D.Abstracts.Patterns;
using SpaceShipWars2D.Controllers;
using SpaceShipWars2D.Enums;
using UnityEngine;

namespace SpaceShipWars2D.Managers
{
    public class SoundManager : SingletonMonoObject<SoundManager>
    {
        [SerializeField] OneShotSoundPlayerController[] _oneShotSounds;

        protected override void Awake()
        {
            base.Awake();
            _oneShotSounds = GetComponentsInChildren<OneShotSoundPlayerController>();
        }

        //FirstOrDefault bir linq method'tur ve bunu kullabilmemiz icin System.Linq dosya yoluna ihtiyacimiz vardir bu yontem bizim icin yazilmis hazir bir method'tur ve yazimi normal methodlardan farklidir onrgin first or default su anlama gelir bana ilk buldugnu don veya default degeri class icin default deger null'dir struct icin ise 0'dir cunku sturct'lar null olamaz 
        public void PlayWithName(SoundName soundName)
        {
            //burdak x class'in kendisi temsil eder => ile lampda yazimi yapmis oluyoruz ve x.SoundName listin veya dizinin icinde class referenasini temsil eder soundName ise method ile gelen paratreyi temsil eder
            _oneShotSounds.FirstOrDefault(x => x.SoundName == soundName).Play();

            //usttekinin kisa yazimini yapmis olduk lampda kod yazimi ile
            // foreach (OneShotSoundPlayerController x in _oneShotSounds)
            // {
            //     if(x.SoundName == soundName) x.Play();
            // }
        }
    }
}

