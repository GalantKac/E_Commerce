using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProductLibrary.Entities.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Payment Recived")]
        PaymentRecived,
        [EnumMember(Value = "Payment Failed")]
        PaymentFailed
    }
}
