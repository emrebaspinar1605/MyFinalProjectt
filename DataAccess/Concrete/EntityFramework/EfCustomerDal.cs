﻿using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepository<Customer, NorthwindContext>,ICustomerDal
    {

    }
}
