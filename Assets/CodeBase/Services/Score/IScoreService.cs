using System;

namespace CodeBase.Services.Score
{
    public interface IScoreService
    {
        event EventHandler ScoreChanged;
        
        int CurrentScore { get; }
        
        void AddScore(int score);
    }
}