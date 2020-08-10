namespace Tennis
{
    class TennisGame : ITennisGame
    {
        private int player1Score = 0;
        private int player2Score = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1Score += 1;
            else
                player2Score += 1;
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
            if (minusResult == 1) score = "Advantage player1";
            else score = "Advantage player2";

            return score;
        }

        private string DisplayWinner(int player1Score, int player2Score)
        {
            string score;
            int minusResult = player1Score - player2Score;
            if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";

            return score;
        }

        public string GetScore()
        {
            string score = "";
            if (player1Score == player2Score)
            {
                score = ScoreTied(player1Score);
            }
            else if (player1Score >= 4 || player2Score >= 4)
            {
                if (player1Score - player2Score == 1 || player1Score - player2Score == -1)
                    score = ScoreAdvantage(player1Score, player2Score);
                else
                    score = DisplayWinner(player1Score, player2Score);
            }
            else
            {
                score = ScoreStandard(player1Score, player2Score, score);
            }
            return score;
        }
    }
}

