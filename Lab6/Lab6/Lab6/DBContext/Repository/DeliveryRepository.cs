using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.DBContext.Repository
{
    public class DeliveryRepository : IDelivery
    {
        private Internet_SalesContext context;

        public DeliveryRepository(Internet_SalesContext context)
        {
            this.context = context;
        }

        public void AddDeliveryInformation(Delivery delivery)
        {
            context.Deliveries.Add(delivery);
            context.SaveChanges();
        }

        public void ChangeAdressDelivery(Delivery delivery, string newAdress)
        {
            delivery.AddressDelivery = newAdress;
            context.SaveChanges();
        }

        public void ChangeDeliveryInformation(Delivery delivery, string newAdress, DateTime newDateDelivery, decimal newAmount)
        {
            delivery.AddressDelivery = newAdress;
            delivery.DateDelivery = newDateDelivery;
            delivery.Amount = newAmount;
            context.SaveChanges();
        }

        public void DeleteDeliveryInformation(Delivery delivery)
        {
            context.Deliveries.Remove(delivery);
            context.SaveChanges();
        }
    }
}
