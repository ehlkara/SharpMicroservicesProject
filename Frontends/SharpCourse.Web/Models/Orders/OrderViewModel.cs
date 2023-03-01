using System;
namespace SharpCourse.Web.Models.Orders
{
	public class OrderViewModel
	{
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }

        // address doesnt need to payment history
        //public AddressDto Address { get; set; }
        public string BuyerId { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; }
    }
}

