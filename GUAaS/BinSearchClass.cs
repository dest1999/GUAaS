namespace GUAaS
{
    public static class BinSearchClass
    {
        public static int BinarySearch(int[] arr, int value)
        {// сложность log(n)
            int lowBorder = 0,
                index,
                upBorder = arr.Length - 1;
            
            while (lowBorder <= upBorder)
            {
                index = (lowBorder + upBorder) / 2;
                if (value == arr[index])
                {
                    while (arr[index - 1] == value)
                    {// выдаём ближайший к началу элемент... а не абы-какой
                        index--;
                    }
                    return index;
                }
                else if (value < arr[index])
                {
                    upBorder = index - 1;
                }
                else
                {
                    lowBorder = index + 1;
                }
            }
            return -1;
        }
    }
}