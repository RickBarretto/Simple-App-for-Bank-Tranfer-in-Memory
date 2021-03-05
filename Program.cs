using System;
using System.Collections.Generic;

namespace AplicacaoBancaria
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            string userOption = GetUserOption();
            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        CreateAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }

            Console.WriteLine("[!] - Turning off!\nPress Enter!");
            Console.ReadLine();
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("What do you want?");
            Console.WriteLine("[1] - Accounts List ");
            Console.WriteLine("[2] - Create Accounts ");
            Console.WriteLine("[3] - Transfer ");
            Console.WriteLine("[4] - Withdraw ");
            Console.WriteLine("[5] - Deposit ");
            Console.WriteLine("[X] - Exit ");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }

        private static void CreateAccount()
        {
            Console.WriteLine();
            Console.WriteLine("[+] - Type 1 to Physical Account or 2 to Juridic Account: ");
            int inputAccountType = int.Parse(Console.ReadLine());

            Console.WriteLine("[+] - Write the user name:");
            string inputName = Console.ReadLine();

            Console.WriteLine("[+] - Write the initial balance: ");
            double inputAccountBalance = double.Parse(Console.ReadLine());

            Console.WriteLine("[+] - Write the initial credit: ");
            double inputAccountCredit = double.Parse(Console.ReadLine());

            Conta newAccount = new Conta(tipoConta: (TipoConta)inputAccountType,
                                        saldo: inputAccountBalance,
                                        credito: inputAccountCredit,
                                        nome: inputName );

            listContas.Add(newAccount); 
        }

        private static void ListAccounts()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("[!] - No accounts.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.WriteLine("[#{0}] - {1}", i, conta);
            }
        }

        private static void Transfer()
        {
            Console.WriteLine("Write the account's number origin.");
            int origin = int.Parse(Console.ReadLine());

            Console.WriteLine("Write the account's number target.");
            int target = int.Parse(Console.ReadLine());

            Console.WriteLine("Write the Cash value.");
            int cash = int.Parse(Console.ReadLine());

            listContas[origin].Transferir(cash, listContas[target]);
        }

        private static void Withdraw()
        {
            Console.WriteLine("Write the account's number");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Write the Cash value.");
            int cash = int.Parse(Console.ReadLine());

            listContas[number].Sacar(cash);
        }

        private static void Deposit()
        {
            Console.WriteLine("Write the account's number");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Write the Cash value.");
            int cash = int.Parse(Console.ReadLine());

            listContas[number].Depositar(cash);
        }


    }
}
