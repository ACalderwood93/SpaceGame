using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceGame.Helpers
{
    public static class ScoreManager
        {
        static int _score = 0;
        public static int Score { get { return _score; } set { _score = value; } }

        public static int IncrementScore(int i)
        {
            _score += i;
            return _score;


        }
    }
}
