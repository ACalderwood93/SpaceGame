using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceGame.Helpers
{
    public static class TimeManager
    {
        public static double time;
        public static bool stillPlaying = true;

        public static void Update()
        {
            if (stillPlaying)
            {
                time += cManager.deltaTime;
                
            }

        }
        public static void Stop()
        {

            stillPlaying = false;
        }

    }
}
