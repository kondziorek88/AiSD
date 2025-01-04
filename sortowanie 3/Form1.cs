namespace sortowanie_3
{
    public partial class Form1 : Form
    {
        int[] array;
        private void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        private void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        private void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);

                Merge(arr, left, middle, right);
            }
        }

        private void Merge(int[] arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int i = 0; i < n1; ++i)
                L[i] = arr[left + i];
            for (int j = 0; j < n2; ++j)
                R[j] = arr[middle + 1 + j];

            int k = left;
            int x = 0, y = 0;
            while (x < n1 && y < n2)
            {
                if (L[x] <= R[y])
                {
                    arr[k] = L[x];
                    x++;
                }
                else
                {
                    arr[k] = R[y];
                    y++;
                }
                k++;
            }

            while (x < n1)
            {
                arr[k] = L[x];
                x++;
                k++;
            }

            while (y < n2)
            {
                arr[k] = R[y];
                y++;
                k++;
            }
        }

        private void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }

        private void CountingSort(int[] arr)
        {
            int max = arr.Max();
            int min = arr.Min();
            int range = max - min + 1;

            int[] count = new int[range];
            int[] output = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i] - min]++;
            }

            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                output[count[arr[i] - min] - 1] = arr[i];
                count[arr[i] - min]--;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = output[i];
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //bubble sort
        {
            int[] arrayCopy = (int[])array.Clone();
            BubbleSort(arrayCopy);

            string displayedArray = string.Join(", ", arrayCopy.Take(15));
            if (arrayCopy.Length > 15)
            {
                displayedArray += "...";  
            }

            
            textBox2.Text = displayedArray;
        }

        private void button2_Click(object sender, EventArgs e) //insert
        {
            int[] arrayCopy = (int[])array.Clone();
            InsertionSort(arrayCopy);

            string displayedArray = string.Join(", ", arrayCopy.Take(15));
            if (arrayCopy.Length > 15)
            {
                displayedArray += "...";
            }

            textBox2.Text = displayedArray;
        }

        private void button3_Click(object sender, EventArgs e)//merge
        {
            int[] arrayCopy = (int[])array.Clone();
            MergeSort(arrayCopy, 0, arrayCopy.Length - 1);

            string displayedArray = string.Join(", ", arrayCopy.Take(15));
            if (arrayCopy.Length > 15)
            {
                displayedArray += "...";
            }

            textBox2.Text = displayedArray;
        }

        private void button4_Click(object sender, EventArgs e)//quick
        {
            int[] arrayCopy = (int[])array.Clone();
            QuickSort(arrayCopy, 0, arrayCopy.Length - 1);

            
            string displayedArray = string.Join(", ", arrayCopy.Take(15));
            if (arrayCopy.Length > 15)
            {
                displayedArray += "...";
            }

            textBox2.Text = displayedArray;
        }

        private void button6_Click(object sender, EventArgs e)//counting
        {
            int[] arrayCopy = (int[])array.Clone();
            CountingSort(arrayCopy);

            string displayedArray = string.Join(", ", arrayCopy.Take(15));
            if (arrayCopy.Length > 15)
            {
                displayedArray += "...";
            }

            textBox2.Text = displayedArray;
        }

        private void button5_Click(object sender, EventArgs e)//tworzenie
        {
            string[] input = textBox1.Text.Split(',');
            array = Array.ConvertAll(input, s => int.Parse(s));
            textBox1.Text = "Tablica utworzona: " + string.Join(", ", array);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e) // losowa tablica
        {
            if (int.TryParse(textBox3.Text, out int arraySize) && arraySize > 0)
            {

                Random random = new Random();
                array = new int[arraySize];
                for (int i = 0; i < arraySize; i++)
                {
                    array[i] = random.Next(1, 1000); // Losowe liczby mniejsze od tysi¹ca
                }
            }

            else
            {
                MessageBox.Show("Podaj poprawn¹ liczbê elementów!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}