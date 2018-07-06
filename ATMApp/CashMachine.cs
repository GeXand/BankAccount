using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp
{
    class CashMachine
    {
        public CashMachine()
        {
            hund = 10;
            fidd = 10;
            twen = 10;
            tens = 10;
            fivs = 10;
            ones = 10;
        }

        public String restock()
        {
            String msg = "Machine balance: \n $100 - 10 \n $150 - 10 \n $20 - 10 \n $10 - 10 \n $5 - 10 \n $1 - 10 \n";
            hund = 10;
            fidd = 10;
            twen = 10;
            tens = 10;
            fivs = 10;
            ones = 10;
            return msg;
        }

        public String withdraw(int amt)
        {
            String msg = "";
            int amtup = amt;
            if (amt > 1860)
            {
                msg = "Failure: Insufficient Funds";
            }
            else if (amt <= 0)
            {
                msg = "Failure: Invalid Amount";
            }
            else
            {
                int one = amtup % 5;
                amtup -= one;
                int fiv = (amtup % 10) / 5;
                amtup -= fiv * 5;
                int ten = (amtup % 20) / 10;
                amtup -= ten * 10;
                int twe = (amtup % 50) / 20;
                amtup -= twe * 20;
                int fif = (amtup % 100) / 50;
                amtup -= fif * 50;
                int hun = amtup / 100;

                if (hun > hund || fif > fidd || twe > twen || ten > tens || fiv > fivs || one > ones)
                {
                    msg = "Failure: Insufficient Funds" + "\n";
                }
                else
                {
                    msg = "Success: Dispensed $" + amt + "\n" + "Machine balance: \n";

                    hund -= hun;
                    msg += "$100 - " + hund + "\n";

                    fidd -= fif;
                    msg += "$50 - " + fidd + "\n";

                    twen -= twe;
                    msg += "$20 - " + twen + "\n";

                    tens -= ten;
                    msg += "$10 - " + tens + "\n";

                    fivs -= fiv;
                    msg += "$5 - " + fivs + "\n";

                    ones -= one;
                    msg += "$1 - " + ones + "\n";
                }
            }
            return msg;
        }

        public String check(String denom)
        {
            String msg = "";
            String[] denoms = denom.Split(' ');
            int[] stock = new int[denoms.Length];
            for (int i = 0; i < stock.Length; i++)
            {
                switch (denoms[i])
                {
                    case "$1":
                        stock[i] = ones;
                        break;
                    case "$5":
                        stock[i] = fivs;
                        break;
                    case "$10":
                        stock[i] = tens;
                        break;
                    case "$20":
                        stock[i] = twen;
                        break;
                    case "$50":
                        stock[i] = fidd;
                        break;
                    case "$100":
                        stock[i] = hund;
                        break;
                }
            }

            for (int i = 0; i < stock.Length; i++)
            {
                msg += denoms[i] + " - " + stock[i] + "\n";
            }

            return msg;
        }

        public static void Main(string[] args)
        {
            CashMachine egg = new CashMachine();
            bool on = true;
            Console.WriteLine("Welcome to the Cash Machine! Enter a command to begin:");
            Console.WriteLine("R - Restocks the cash machine");
            Console.WriteLine("W <dollar amount> - Withdraws amount from the cash machine");
            Console.WriteLine("I <denominations> - Displays the number of bills in that denomination present in the cash machine");
            Console.WriteLine("Q - Quit the application");

            while (on)
            {
                String command = Console.ReadLine();
                if (command[0] == 'W')
                {
                    Console.WriteLine(egg.withdraw(Int32.Parse(command.Substring(3, command.Length - 3))));
                }
                else if (command[0] == 'I')
                {
                    Console.WriteLine(egg.check(command.Substring(2, command.Length - 2)));
                }
                else if (command[0] == 'R')
                {
                    Console.WriteLine(egg.restock());
                }
                else if (command[0] == 'Q')
                {
                    on = false;
                }
                else
                {
                    Console.WriteLine("Failure: Invalid Command" + "\n");
                }
                Console.WriteLine("Please enter another command or quit the application:");
            }
        }

        private int hund;
        private int fidd;
        private int twen;
        private int tens;
        private int fivs;
        private int ones;
    }
}
