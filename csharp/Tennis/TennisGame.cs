namespace Tennis
{
    class TennisGame : ITennisGame
    {
        Player player1;
        Player player2;

        // Labels for scoring
        public enum Scores
        {
            Love,
            Fifteen,
            Thirty,
            Forty,
            All,
            Advantage,
            Deuce,
            Win
        }

        public TennisGame(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void WonPoint(Player player)
        {
            if (player.name == player1.name)
                player1.score += 1;
            else
                player2.score += 1;
        }

        private string ScoreTied(int player1Score)
        {
            if (player1Score < 3) return ((Scores)player1Score).ToString() + '-' + Scores.All;
            else return Scores.Deuce.ToString();
        }

        private string ScoreStandard(int player1Score, int player2Score, string score)
        {
            int tempScore = 0;
            for (int i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = player1Score;
                else { score += "-"; tempScore = player2Score; }
                score += ((Scores)tempScore).ToString();
            }
            return score;
        }

        private string ScoreAdvantage(int player1Score, int player2Score)
        {
            int minusResult = player1Score - player2Score;
            if (minusResult == 1) return Scores.Advantage + " " + player1.name;
            else return Scores.Advantage + " " + player2.name;
        }

        private string DisplayWinner(int player1Score, int player2Score)
        {
            int minusResult = player1Score - player2Score;
            if (minusResult >= 2) return Scores.Win + " for " + player1.name;
            else return Scores.Win + " for " + player2.name;
        }

        public string GetScore()
        {
            string score = "";
            if (player1.score == player2.score)
            {
                score = ScoreTied(player1.score);
            }
            else if (player1.score >= 4 || player2.score >= 4)
            {
                if (player1.score - player2.score == 1 || player1.score - player2.score == -1)
                    score = ScoreAdvantage(player1.score, player2.score);
                else
                    score = DisplayWinner(player1.score, player2.score);
            }
            else
            {
                score = ScoreStandard(player1.score, player2.score, score);
            }
            return score;
        }
    }
}

