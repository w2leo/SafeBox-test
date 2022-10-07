using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox
{
    public class SafeBox
    {

        bool[,] data;
        public int Size { get; private set; }

        public SafeBox()
        {

        }

        public SafeBox(int size)
        {
            this.Size = size;
            data = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    data[i, j] = false; // or true;
                }
            }
        }

        public bool GetData(int x, int y)
        {
            return data[x, y];
        }

        public void ChangeValue(int x, int y)
        {
            if (x < Size && y < Size)
            {
                for (int i = 0; i < Size; i++)
                {
                    data[i, y] = !data[i, y];
                    data[x, i] = !data[x, i];
                }
                data[x,y] = !data[x, y]; 
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
                x = random.Next(Size);
                y = random.Next(Size);
                ChangeValue(x, y);
            }
        }
    }
}
