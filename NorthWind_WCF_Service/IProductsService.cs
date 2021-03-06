﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NorthWind_WCF_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductsService" in both code and config file together.
    [ServiceContract]
    public interface IProductsService
    {
        [OperationContract]
        ICollection<Product> GetAllProducts();
    }
}
