using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStation.Blazor.Shared;
using FuelStation.Model;

namespace FuelStation.Services
{
    public class TransactionServices
    {
        public decimal sum = 0.0m;
        public bool gotFuel = false;

        public TransactionServices()
        {

        }
        public async Task<decimal> CalculateNetValue(decimal qty, decimal itemPrice)
        {
            if (qty <= 0) throw new ArgumentException("Quantity cannot be a negative or zero number.");
            if (itemPrice <= 0) throw new ArgumentException("Item price cannot be a negative or zero number.");
            return qty * itemPrice;
        }
        public async Task<decimal> CalculateDiscountValue(decimal netValue, decimal discountValue)
        {
            if (netValue <= 0) throw new ArgumentException("Net value cannot be a negative or a zero number.");
            if (discountValue < 0) throw new ArgumentException("Discount cannot be a negative number.");
            return netValue * discountValue;
        }
        public async Task<decimal> CalculateTotalValue(decimal netValue, decimal discountValue)
        {
            if (netValue <= 0) throw new ArgumentException("Net value cannot be a negative or a zero number.");
            if (discountValue < 0) throw new ArgumentException("Discount cannot be a negative number.");
            return netValue - discountValue;
        }
        public async Task<decimal> TransactionTotalValue(List<TransactionLineViewModel> transactionLineTotalValue)
        {
            foreach (var item in transactionLineTotalValue)
            {
                sum += item.TotalValue;
            }
            return sum;
        }
        public async Task<decimal> ApplyDiscount(decimal netValue, decimal totalValue, List<TransactionLineViewModel> transactionLine)
        {
            if (totalValue < 0) throw new ArgumentException("Total value cannot be a negative number.");
            if (netValue <= 0) throw new ArgumentException("Net value cannot be a negative or zero number.");
            foreach (var line in transactionLine)
            {
                gotFuel = line.Item?.ItemType == ItemType.Fuel;
            }
            if (netValue >= 20 && gotFuel == true)
            {
                return totalValue - totalValue * (decimal)0.1;
            }
            return totalValue;
        }
        public async Task<bool> CheckFuel(List<TransactionLine> transactionLine)
        {
            foreach (var line in transactionLine)
            {
                if (line.Item?.ItemType == ItemType.Fuel)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> AcceptingCard(decimal totalValue)
        {
            if (totalValue < 0) throw new ArgumentException("Total value cannot be a negative number");
            if (totalValue <= 50) return true;

            return false;

        }
    }
}
