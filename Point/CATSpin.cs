using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    using System;
    using System.Threading;

    public class CATSpin
    {
        private string[] frames;
        private int delay;

        public CATSpin(string[] frames, int delay = 100)
        {
            this.frames = frames;
            this.delay = delay;
        }

        public void Spin()
        {
            Console.Clear();
            int currentFrame = 0;

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(frames[currentFrame]);
                currentFrame = (currentFrame + 1) % frames.Length;
                Thread.Sleep(delay);
            }
        }
    }

}
