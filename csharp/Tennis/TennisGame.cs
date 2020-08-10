namespace Tennis
{
    class TennisGame : ITennisGame
    {
        Player player1;
        Player player2;

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
            string score;
            switch (player1Score)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;

            }
            return score;
        }

        private string ScoreStandard(int player1Score, int player2Score, string score)
        {
            int tempScore = 0;
            for (int i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = player1Score;
                else { score += "-"; tempScore = player2Score; }
                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }

            return score;
        }

        private string ScoreAdvantage(int player1Score, int player2Score)
        {
            string score;
            int minusResult = player1Score - player2Score;
            if (minusResult == 1) score = "Advantage " + player1.name;
            else score = "Advantage " + player2.name;

            return score;
        }

        private string DisplayWinner(int player1Score, int player2Score)
        {
            string score;
            int minusResult = player1Score - player2Score;
            if (minusResult >= 2) score = "Win for " + player1.name;
            else score = "Win for " + player2.name;

            return score;
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

