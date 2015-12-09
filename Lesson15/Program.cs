using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lesson15
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            //включение и выключение через 5 секунд
            //включение через Thread, выключение через Timer

            //Fridge Zanussi = new Fridge(false, FridgeModes.normal);
            //while (true)
            //{
            //    Console.Clear();
            //    Console.WriteLine(Zanussi.Info() + "\n");
            //    Console.WriteLine("Доступные действия: ");
            //    Console.WriteLine("1 - включить холодильник");
            //    Console.WriteLine("2 - выключить холодильник");
            //    Console.WriteLine("3 - нормальный режим");
            //    Console.WriteLine("4 - северный режим");
            //    Console.WriteLine("5 - южный режим");
            //    Console.WriteLine("e - завершить программу");

            //    char key = Console.ReadKey().KeyChar;

            //    switch (key)
            //    {
            //        case '1':

            //            Thread t = new Thread(new ThreadStart(Zanussi.On));
            //            Thread.Sleep(5000);
            //            t.Start();
            //            //Zanussi.On();
            //            break;
            //        case '2':

            //            TimerCallback tm = new TimerCallback(Zanussi.Off);
            //            Timer tt = new Timer(tm, 0, 5000, 0);
            //            //Zanussi.Off();

            //            break;
            //        case '3':
            //            Zanussi.Normal();
            //            break;
            //        case '4':
            //            Zanussi.North();
            //            break;
            //        case '5':
            //            Zanussi.South();
            //            break;

            //        case 'e':
            //        case 'у':
            //            return;
            //    }
            //}


            //2
            // распараллеливание двух foreach в два Task'а для ускорения подсчета

            int[] firstArr = new int[10000000];
            int[] secondArr = new int[10000000];

            Random ran = new Random(); // Объект для генерации случайных чисел

            for(int i = 0; i <firstArr.Length; i++) // Заполнение массива случайными значениями в диапазоне от 1 до 100
                {
            firstArr[i] = ran.Next(1, 100);
            secondArr[i] = ran.Next(1, 100);
                  }

            long firstArrSum = 0; // Сумма первого массива
            long secondArrSum = 0; // Сумма второго массива

            Stopwatch sw = new Stopwatch(); // Объект для подсчета времени выполнения подсчета
            sw.Start();

            //foreach(int item in firstArr) // Подсчет суммы элементов первого массива
            //      {
            //firstArrSum += item;
            //      }

            //foreach(int item in secondArr) // Подсчет суммы элементов второго массива
            //      {
            //secondArrSum += item;
            //      }


            //вызов метода с параметрами через лямбда-выражение
            Task<long> t1 = new Task<long>(() => Sum(firstArr));
            t1.Start();

            Task<long> t2 = new Task<long>(() => Sum(secondArr));
            t2.Start();

            //Console.ReadKey();

            //ожидание окончания выполнения сразу всего массива задач
            //т.е. Main продолжает работать
            Task.WaitAll(t1, t2);

            sw.Stop();

            Console.WriteLine("Сумма элементов первого массива: " + t1.Result);
            Console.WriteLine("Сумма элементов второго массива: " + t2.Result);
            Console.WriteLine("Время выполнения подсчета: " + sw.ElapsedMilliseconds + " миллисекунд");


        }

        //статический метод для подсчета - передаем массив интов, получаем лонг
        static long Sum (int [] arrs){

            long arrSum = 0;

            foreach (int item in arrs) // Подсчет суммы элементов массива
            {
                arrSum += item;
            }
            return arrSum;

        }

    }
}
