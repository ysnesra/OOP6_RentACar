using Core.Utilities.Results;
using Entities.Concrete.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);

        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);      //tek bir araç kiralama detayını getirir       
        IDataResult<List<Rental>> GetRentalByCustomer(int customerId);  //Müşteriye göre arackiralama bilgisini getirir 
        IDataResult<List<RentalDetailDto>> GetRentalDetails();    //Rental-Customer-Car Join
    }
}
