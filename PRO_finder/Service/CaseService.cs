using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Service
{
    public class caseService
    {
        public List<CaseViewModel> Getcase()
        {
            var repository = new GeneralRepository(new ProFinderContext());


            var result = repository.GetAll<Case>().ToList();


            List<CaseViewModel> List = new List<CaseViewModel>();



            foreach(var i in result)
            {
                List.Add(new CaseViewModel
                {
                    title =i.CaseTitle  ,
                    Price=i.Price,
                    LocationID= (int)i.Location,
                    Description=i.Description


                });
            }


            return List;
        }
    }
}