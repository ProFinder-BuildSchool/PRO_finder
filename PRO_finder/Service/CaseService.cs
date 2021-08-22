using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PRO_finder.Service
{
    public class CaseService
    {
        private readonly CaseRepository _CaseRepo;
        private readonly GeneralRepository _repo;


        public CaseService()
        {
           _CaseRepo = new CaseRepository();
           _repo = new GeneralRepository(new ProFinderContext());
        }



        public List<CaseViewModel> Getcase()
        {
            var repository = new GeneralRepository(new ProFinderContext());


            var result = repository.GetAll<Case>().ToList();


            List<CaseViewModel> List = new List<CaseViewModel>();



            foreach(var i in result)
            {
                //var location = repository.GetAll<Locations>().ToList().Where(x => x.LocationID == i.Location).FirstOrDefault().LocationName;
                //List.Add(new CaseViewModel
                //{
                //    title =i.CaseTitle,
                //    Price= (CaseViewModel.PriceEnum)i.Price,
                //    LocationID= (int)i.Location,
                //    Description=i.Description,
                //    LocationName = location
                //});
            }


            return List;
        }

        public List<SelectListItem> getLocationList()
        {
            var repository = new GeneralRepository(new ProFinderContext());
            List<Locations> locationDB = repository.GetAll<Locations>().ToList();
            List<SelectListItem> locationlist = new List<SelectListItem>();
            locationlist.Add(new SelectListItem { Text = "地區" });
            foreach (var item in locationDB)
            {
                locationlist.Add(
                    new SelectListItem { Text = item.LocationName, Value = item.LocationID.ToString() });
            }
            return locationlist;
        }
        public List<CaseViewModel> GetCasesList()
        {
            List<CaseViewModel> CasesList = _CaseRepo.ReadCase().ToList();
            return CasesList;
        }

        public List<SelectListItem> GetToolList()
        {
            var toolList = _repo.GetAll<ToolCategory>();
            List<SelectListItem> toolDropdown = new List<SelectListItem>();
            toolDropdown.Add(new SelectListItem { Text = "選擇擅長工具類別" });
            foreach(var item in toolList)
            {
                toolDropdown.Add(new SelectListItem { Text = item.TalentCategoryName, Value = item.TalentCategoryName});
            }
            return toolDropdown;
        }
    }
}