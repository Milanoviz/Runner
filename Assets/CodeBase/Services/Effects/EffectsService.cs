using System;
using CodeBase.HeroModule;
using UnityEngine;

namespace CodeBase.Services.Effects
{
    public class EffectsService : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _coinsEffect;

        private Hero _hero;

        public void Constructor(Hero hero)
        {
            _hero = hero;
            
            _hero.CollectedCoin += HandlerCollectedCoin;
        }

        private void HandlerCollectedCoin(object sender, EventArgs e)
        {
            PlayCoinsEffect();
        }

        private void PlayCoinsEffect()
        {
            _coinsEffect.transform.position = new Vector3(_hero.transform.position.x, 1, _hero.transform.position.z);
            _coinsEffect.Play();
        }
    }
}