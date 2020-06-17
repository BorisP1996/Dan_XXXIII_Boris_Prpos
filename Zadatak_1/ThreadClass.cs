using System;
using System.IO;
using System.Threading;

namespace Zadatak_1
{
    class ThreadClass
    {
        /// <summary>
        /// Method contains 4 if clauses and depeneding on thread name certain if is called
        /// </summary>
        /// <param name="t"></param>
        public void DoWork(Thread t)
        {
            //creating relative paths
            string path1 = @"..\..\FileByThread_1.txt";
            string path2 = @"..\..\FileByThread_22.txt";

            //part of the method that will be executed when thread name is "THREAD_1"
            if (t.Name == "THREAD_1")
            {
                //if file already exists, it will be deleted
                if (File.Exists(path1))
                {
                    File.Delete(path1);
                }
                //creating stream writer, true in constructor=> if file does not exist it will be deleted
                StreamWriter sw = new StreamWriter(path1, true);
                //initializing matrix
                int[,] matrix = new int[100, 100];
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        //setting 1 on main diagonal
                        if (i == j)
                        {
                            matrix[i, j] = 1;
                        }
                    }
                }
                //counter used to skip first empty row
                int emptyRow = 0;
                for (int i = 0; i < 100; i++)
                {
                    //first row is skipped,after that sw.write("\n") will take efect
                    //without this "if" file would have first row that would be empty
                    if (emptyRow > 0)
                    {
                        sw.Write("\n");
                    }
                    emptyRow++;
                    for (int j = 0; j < 100; j++)
                    {
                        //dwriting to the file
                        sw.Write("{0}", matrix[i, j]);
                    }
                }
                sw.Close();
            }
            //part of the method that will be executed when thread name is "THREAD_22"
            if (t.Name == "THREAD_22")
            {
                //checking if file exists
                if (File.Exists(path2))
                {
                    File.Delete(path2);
                }
                //creating StreamWriter
                StreamWriter sw = new StreamWriter(path2, true);
                Random rnd = new Random();

                int counter = 0;
                //file has to contain 1000 numbers
                while (counter < 1000)
                {
                    //generating random number and adding to file only if numbeer is odd
                    int i = rnd.Next(0, 10000);
                    if (i % 2 == 1)
                    {
                        sw.WriteLine(i);
                        counter++;
                    }
                }
                sw.Close();
            }
            //part of the method that will be executed when thread name is "THREAD_3"
            if (t.Name == "THREAD_3")
            {
                if (File.Exists(path1))
                {
                    //reading matrix from file
                    StreamReader sr = new StreamReader(path1);
                    string line = "";
                    //until there is empty row reader reads from file and inserts it into line
                    while ((line = sr.ReadLine()) != null)
                    {
                        //displaying line from file
                        Console.WriteLine(line);
                    }
                    sr.Close();
                }
                else
                {
                    Console.WriteLine("File does not exist on specified location.");
                }
            }
            //part of the method that will be executed when thread name is "THREAD_44"
            if (t.Name == "THREAD_44")
            {
                if (File.Exists(path2))
                {
                    StreamReader sr = new StreamReader(path2);
                    int suma = 0;
                    string line = "";
                    //reading lines from file and inserting into string line
                    while ((line = sr.ReadLine()) != null)
                    {
                        //converting string from file to int and adding it into sum
                        suma += Convert.ToInt32(line);
                    }
                    //displaying sum
                    Console.WriteLine("Total sum of numbers from file \"FileByThread_22\" is :{0}", suma);
                }
                else
                {
                    Console.WriteLine("File does not exist on specified location.");
                }
            }
        }
    }
}
