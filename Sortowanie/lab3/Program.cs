using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab3
{
    class Program
    {
        static List<double> bubble(int size, List<double> lista)
        {
            List<double> internalList = new List<double>(lista);
            bool isLeft = false;
            double bufor = 0;
            do
            {
                isLeft = false;
                for (int j = 0; j < size - 1; j++)
                {
                    if (internalList[j] > internalList[j + 1])
                    {
                        isLeft = true;
                        bufor = internalList[j];
                        internalList[j] = internalList[j + 1];
                        internalList[j + 1] = bufor;
                    }
                }
            } while (isLeft);
            return internalList;
        }

        static List<double> select(int size, List<double> lista)
        {
            List<double> internalList = new List<double>(lista);
            double least = 0.0;
            int leastIn = 0;
            for (int i = 0; i < size; i++)
            {
                least = internalList[i];
                leastIn = i;
                for (int j = i; j < size; j++)
                {
                    if (internalList[j] < least)
                    {
                        least = internalList[j];
                        leastIn = j;
                    }

                }
                internalList[leastIn] = internalList[i];
                internalList[i] = least;
            }
            return internalList;
        }

        static void sort(List<double> lista, int left, int right)
        {

            double bufor = 0;
            int i = left;
            int j = right;
            double x = lista[(left + right) / 2];
            do
            {
                while (lista[i] < x)
                    i++;

                while (lista[j] > x)
                    j--;

                if (i <= j)
                {
                    bufor = lista[i];
                    lista[i] = lista[j];
                    lista[j] = bufor;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (left < j) sort(lista, left, j);

            if (right > i) sort(lista, i, right);
        }

        static List<double> quick(int size, List<double> lista)
        {
            List<double> internalList = new List<double>(lista);
            sort(internalList, 0, size - 1);
            return internalList;
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            List<double> list = new List<double>();
            List<double> list1 = new List<double>();
            List<double> list2 = new List<double>();
            List<double> list3 = new List<double>();
            int size = 5000;

            for (int i = 0; i < size; i++)
            {
                double number = random.NextDouble() * 50;
                list.Add(number);
            }

            //foreach(double x in list)
            //Console.Write(x+" ");

            Console.WriteLine("");

            Stopwatch sw = new Stopwatch();

            sw.Start();
            list1 = bubble(size, list);
            sw.Stop();
            //foreach (double x in list1)
            //    Console.Write(x + " ");

            Console.WriteLine("");

            Console.WriteLine("Algortym bąbelkowy. Czas trwania: " + sw.Elapsed.TotalMilliseconds + " milisekund");

            sw = new Stopwatch();
            sw.Start();
            list2 = select(size, list);
            sw.Stop();

            //foreach (double x in list2)
            //    Console.Write(x + " ");

            Console.WriteLine("");

            Console.WriteLine("Algortym wybierania. Czas trwania: " + sw.Elapsed.TotalMilliseconds + " milisekund");

            sw = new Stopwatch();
            sw.Start();
            list3 = quick(size, list);
            sw.Stop();

            // foreach (double x in list3)
            //     Console.Write(x + " ");

            Console.WriteLine("");

            Console.WriteLine("Algortym szybkiego sortowania. Czas trwania: " + sw.Elapsed.TotalMilliseconds + " milisekund");

            Console.ReadLine();

        }
    }
}
