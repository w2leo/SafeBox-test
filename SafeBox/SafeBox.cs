using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox
{
    public class SafeBox
    {
        int size;
        bool[,] data;

        public SafeBox()
        {

        }

        public SafeBox(int size)
        {
            this.size = size;
            data = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    data[i, j] = false; // or true;
                }
            }
        }

        public void ChangeValue(int x, int y)
        {
            if (x < size && y < size)
            {
                for (int i = 0; i < size; i++)
                {
                    data[i, y] = !data[i, y];
                    data[x, i] = !data[x, i];
                }
            }
        }

        public bool CheckResult()
        {
            bool firsElement = data[0, 0];
            foreach (var e in data)
            {
                if (e != firsElement)
                {
                    return false;
                }
            }
            return true;
        }

        public void MixSafeBox(int iterations)
        {
            Random random = new Random();
            int x, y;
            for (int i = 0; i < iterations; i++)
            {
                x = random.Next(size);
                y = random.Next(size);
                ChangeValue(x, y);
            }
        }

    }
}
