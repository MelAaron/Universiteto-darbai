using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kolis1
{
    public class Kalimas
    {
        public void Burbuliukas(int [] a, int n)
        {
            int j = 0;
            bool bk = true;
            while (bk)
            {
                for (int i = n - 1; i > 0; i--)
                {
                    if(a[n] > a[n - 1])
                    {
                        bk = true;
                        var c = a[n];
                        a[n] = a[n - 1];
                        a[n - 1] = c;
                    }
                }
                j++;
            }
        }

        public void Irinkimas (int[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int max = i;
                for (int j = 0; j < n; j++)
                {
                    if (a[j] >= a[i])
                        max = j;
                }
                if(max != i)
                {
                    var c = a[i];
                    a[i] = a[max];
                    a[max] = a[i];
                }
            }
        }
        public void Burbuliukas(int[] masyvas)
        {
            int j = 0;
            bool bk = true;
            while(bk)
            {
                bk = false;
                for (int i = masyvas.Length; i > 0; i--)
                {
                    if(masyvas[j] > masyvas[i])
                    {
                        bk = true;
                        var c = masyvas[j];
                        masyvas[i] = masyvas[j];
                        masyvas[j] = c;
                    }
                }
                j++;
            }
        }

        public void Isrinkimas (int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int max = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if(a[j] > a[i])
                    {
                        max = j;
                    }
                    if(max != i)
                    {
                        var c = a[i];
                        a[i] = a[max];
                        a[max] = c;
                    }
                }
            }
        }

        public void Bur (int[] a)
        {
            int j = 0;
            bool bk = true;
            while (bk)
            {
                bk = false;
                for (int i = a.Length - 1; i > 0; i--)
                {
                    if(a[j] > a[i])
                    {
                        bk = true;
                        var c = a[j];
                        a[j] = a[i];
                        a[i] = c;
                    }
                }
                j++;
            }
        }

        public void Is(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int max = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if(a[j] > a[i])
                    {
                        max = j;
                    }
                }
                if(max != i)
                {
                    var c = a[max];
                    a[max] = a[i];
                    a[i] = c;
                }
            }
        }
    }
}