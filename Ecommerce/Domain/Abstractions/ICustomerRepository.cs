﻿using Ecommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Abstractions
{
    public interface ICustomerRepository:IRepository<Customer>
    {

    }
}
