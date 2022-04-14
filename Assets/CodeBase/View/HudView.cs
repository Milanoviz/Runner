using System;
using System.Collections;
using CodeBase.HeroModule;
using CodeBase.Services.SceneLoaderService;
using CodeBase.Services.Score;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.View
{
    public class HudView : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private WinWindowView _winWindow;
        [SerializeField] private Animator _animator;
        
        private IScoreService _scoreService;

        public void Constructor(Hero hero, IScoreService scoreService, SceneLoader sceneLoader)
        {
            _scoreService = scoreService;
            _winWindow.Constructor(sceneLoader);
            
            UpdateScore();
            
            hero.LevelCompleted += HandlerLevelCompleted;
            _scoreService.ScoreChanged += HandlerScoreChanged;
        }

        private void HandlerLevelCompleted(object sender, EventArgs e)
        {
            StartCoroutine(nameof(Wining));
        }

        private void HandlerScoreChanged(object sender, EventArgs e)
        {
            UpdateScore();
        }

        private void UpdateScore()
        {
            _scoreText.text = $"Score: {_scoreService.CurrentScore}";
        }

        private IEnumerator Wining()
        {
            yield return new WaitForSeconds(5);
           
            _animator.Play("Show");
            
            yield return new WaitForSeconds(3);
            
            _winWindow.gameObject.SetActive(true);
            _winWindow.Show();
            
        }
    }
}