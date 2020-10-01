// =================================
//      (C) Winglett 2020
// =================================

namespace Winglett.DRM
{
    public abstract class DRMLeaderboards : DRMComponent
    {
        public abstract void SubmitScore(string leaderboardID, int score);
        public abstract LeaderboardEntry GetUserScore(string leaderboardID);
        public abstract LeaderboardEntry[] GetAllScores(string leaderboardID);
    }

    public class LeaderboardEntry
    {
        public int score;
        public int rank;
        public string id;
    }
}