using System;
using System.IO;

namespace Task3
{
    //3. Решить задачу с логинами из предыдущего урока, только логины и пароли 
    //считать из файла в массив. Создайте структуру Account, содержащую Login и Password.

 struct Account
    {
        public string login;
        public string password;

    }


    public class Class1
    {
        
        public static void Authorization()
        {
            int linscount = 0;
            using (StreamReader sr = new StreamReader(@"C:\userlist.txt"))
            {
                while (!sr.EndOfStream)
                {
                    linscount++;
                    sr.ReadLine();
                }
            }

            Account[] accounts = new Account[linscount];

            using (StreamReader sr = new StreamReader(@"C:\userlist.txt"))
            {
                int index = 0;
                while (!sr.EndOfStream)
                {
                    string s=sr.ReadLine();
                    string[] loginarray = s.Split("||");
                    Account account = new Account();
                    account.login = loginarray[0];
                    account.password = loginarray[1];
                    accounts[index] = account;
                }

            }
            //string login = "root";
            //string password = "GeekBrains";
            int count = 0;
            do
            {
                Console.Write("Enter login: ");
                string l = Console.ReadLine();
                Console.Write("Enter password: ");
                string p = Console.ReadLine();

                if (IsLoginAndPasswordValid(l, p, accounts))
                {
                    Console.WriteLine($"Аuthorization passed! ");
                    break;
                }
                else
                {
                    Console.WriteLine($"Authorization failed!");
                    count++;
                }


            } while (count < 3);
        }

        private static bool IsLoginAndPasswordValid(string login, string password, Account[] accounts)
        {
            foreach (Account account in accounts)
            {
                if(account.login == login && account.password == password)
                {
                    return true;
                }
            }

            return false;
        }



    }
}
