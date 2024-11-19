using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_1___KlasseBankrekening

{
    public class BankAccount
    {
        // Property
        public decimal CurrentBalance { get; set; }

        // Constructor 
        public BankAccount()
        {
            CurrentBalance = 0;
        }

        // Method Opname()
        public void Withdrawel(decimal amount)
        {
            if (CurrentBalance >= amount)
                CurrentBalance -= amount;
            else
                throw new ArithmeticException();
        }

        // Method Storting()
        public void Deposit(decimal amount)
        {
            CurrentBalance += amount;
        }
    }
}
