using System;

namespace CodeBase.Services.Score
{
    public class ScoreService : IScoreService
    {
        public event EventHandler ScoreChanged;
        
        public int CurrentScore => _currentScore;

        private int _currentScore;
        
        public void AddScore(int score)
        {
            _currentScore += score;
            
            OnScoreChanged();
        }

        private void OnScoreChanged()
        {
            ScoreChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}