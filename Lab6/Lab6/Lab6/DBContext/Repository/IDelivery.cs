using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.DBContext.Repository
{
    public interface IDelivery
    {
        void AddDeliveryInformation(Delivery delivery);
        void DeleteDeliveryInformation(Delivery delivery);
        void ChangeAdressDelivery(Delivery delivery, string newAdress);
        void ChangeDeliveryInformation(Delivery delivery, string newAdress, DateTime newDateDelivery, decimal newAmount);
    }
}
