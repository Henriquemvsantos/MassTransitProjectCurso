using System;
using System.Collections.Generic;
using System.Text;

namespace MassTransitProject.Contracts
{
    public interface OrderSubmitRejected
    {


        Guid id { get; set; }
        DateTime TimeStamp { get; set; }
        string CustomerNumber { get; set; }

        string motivo { get; set; } 
    }
}
