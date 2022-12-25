namespace z_Resources._1._Algorithhms_4th_Edition_by_Robert_Sedgewick__Kevin_Wayne
{
    public static class BinarySearchAlgorithm
    {
        private static int BinarySearch(int key, int[] arr)
        {
            int low = 0;
            int hight = arr.Length - 1;

            while (low <= hight)
            {
                var mid = low + (hight - low) / 2;

                if (key < arr[mid]) hight = mid - 1;
                else if (key > arr[mid]) low = mid + 1;
                else return mid;
            }
            return -1;
        }

        public static int BinarySearch(this int[] arr, int key)
        {
            return BinarySearch(key, arr);
        }
    }
}
