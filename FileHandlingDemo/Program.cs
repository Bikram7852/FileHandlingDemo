using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;

namespace FileHandlingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ans;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Create \n2. Read \n3. Append \n4. Read After Append \n5. Exit");
                Console.WriteLine("Enter Your Choice: ");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        CreateFile();
                        break;
                    case 2:
                        ReadFile();
                        break;
                    case 3:
                        AppendFile();
                        break;
                    case 4:
                        ReadFile();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("Do you want to continue?");
                ans = Console.ReadLine();
            } 
            while (ans=="Yes" || ans == "yes" || ans == "Y" || ans == "y");
        }

        private static void AppendFile()
        {
            string path = "Person.txt";
            FileStream fs = null;
            StreamWriter streamWriter = null;
            if (File.Exists(path))
            {
                try
                {
                    fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                    streamWriter = new StreamWriter(fs);

                    Console.WriteLine("Enter Pincode");
                    string Pincode = Console.ReadLine();
                    
                    streamWriter.WriteLine("Person Pincode: 400001");
                    Console.WriteLine("File Updated Successfully...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    streamWriter.Flush();
                    streamWriter.Close();
                    streamWriter.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
            }
            else
            {
                Console.WriteLine("File not found...");
            }
        }

        private static void ReadFile()
        {
            string path = "Person.txt";
            FileStream fs = null;
            StreamReader streamReader = null;
            if (File.Exists(path))
            {
                try
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    streamReader = new StreamReader(fs);
                    string data = streamReader.ReadToEnd();
                    Console.WriteLine(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    streamReader.Close();
                    streamReader.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
            }
            else
            {
                Console.WriteLine("File not found...");
            }
        }

        private static void CreateFile()
        {
            string path = "Person.txt";
            FileStream fs = null;
            StreamWriter streamWriter = null;
            
            try
            {
                fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                streamWriter = new StreamWriter(fs);

                Console.WriteLine("Enter Name");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter Address");
                string Address = Console.ReadLine();
                Console.WriteLine("Enter City");
                string City = Console.ReadLine();
                Console.WriteLine("Enter Country");
                string Country = Console.ReadLine();

                streamWriter.WriteLine($"Person Name: {Name}");
                streamWriter.WriteLine($"Person Address: {Address}");
                streamWriter.WriteLine($"Person City: {City}");
                streamWriter.WriteLine($"Person Country: {Country}");
                Console.WriteLine("File Created Successfully...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                streamWriter.Flush();
                streamWriter.Close();
                streamWriter.Dispose();
                fs.Close();
                fs.Dispose();
            }
        }
    }
}
