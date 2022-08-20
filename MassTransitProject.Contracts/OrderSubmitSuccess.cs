using System;
using System.Collections.Generic;
using System.Text;

namespace MassTransitProject.Contracts
{
    public interface OrderSubmitSuccess
    {
        Guid id { get; set; }
        DateTime TimeStamp { get; set; }
        string CustomerNumber { get; set; }
    }
}

