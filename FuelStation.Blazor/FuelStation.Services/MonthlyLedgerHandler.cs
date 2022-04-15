using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Services
{
    public class MonthlyLedgerHandler
    {
        private MonthlyLedger _monthlyLedger;
        public MonthlyLedgerHandler(MonthlyLedger monthlyLedger)
        {
            _monthlyLedger = monthlyLedger;
        }
        //public async Task Calculate(List<Transaction> transactions, List<Employee> employees, List<Item> items, List<TransactionLine> transactionLines, decimal rentCost)
        //{
        //    _monthlyLedger.Income = await CalculateIncome(transactions);
        //    _monthlyLedger.Expenses = await CalculateExpenses(employees, items, transactions, transactionLines, rentCost);
        //    _monthlyLedger.Total = _monthlyLedger.Income - _monthlyLedger.Expenses;
        //}
        public async Task<decimal> CalculateIncome(List<Transaction> transactions)
        {
            decimal transactionsIncome = 0;
            int year = int.Parse(_monthlyLedger.Year);
            int month = int.Parse(_monthlyLedger.Month);
            foreach (Transaction t in transactions)
            {
                if (t.Date.Year == year && t.Date.Month == month)
                {
                    transactionsIncome += t.TotalValue;
                }
            }
            return transactionsIncome;
        }
        public async Task<decimal> CalculateExpenses(List<Employee> employees, List<Item> items, List<Transaction> transactions, List<TransactionLine> transactionLines,decimal rentCost)
        {
            decimal salaryExpenses = 0;
            int year = int.Parse(_monthlyLedger.Year);
            int month = int.Parse(_monthlyLedger.Month);
            foreach (Employee e in employees)
            {
                if (e.HireDateStart.Year <= year && e.HireDateEnd.Year > year
                    && e.HireDateStart.Month <= month && e.HireDateEnd.Month > month)
                {
                    double workMonths = (e.HireDateStart - e.HireDateEnd).Days / 30.0;
                    salaryExpenses += e.Sallary * (decimal)workMonths;
                }
            }
            decimal itemCostExpenses = 0;
            foreach (var trans in transactions)
            {
                if (trans.Date.Year == year && trans.Date.Month == month)
                {
                    List<TransactionLine> currentLines = transactionLines.FindAll(x => x.TransactionID == trans.ID);
                    foreach (var lines in currentLines)
                    {
                        decimal currentCost = items.Find(x => x.ID == lines.ItemID).Cost;
                        itemCostExpenses += currentCost * lines.Quantity;
                    }
                }
            }
            return salaryExpenses + itemCostExpenses + rentCost;
        }

    }
}
