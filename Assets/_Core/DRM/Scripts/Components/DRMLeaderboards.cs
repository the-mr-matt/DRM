// =================================
//      (C) Winglett 2020
// =================================

using System.Threading.Tasks;

namespace Winglett.DRM
{
    public abstract class DRMLeaderboards : DRMComponent
    {
        public abstract Task SubmitScore(string leaderboardID, int score);
        public abstract Task<LeaderboardEntry> GetUserScore(string leaderboardID);
        public abstract Task<LeaderboardEntry[]> GetAllScores(string leaderboardID);
    }

    public class LeaderboardEntry
    {
        public int score;
        public int rank;
        public string id;
    }
}