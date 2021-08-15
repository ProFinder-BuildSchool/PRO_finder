using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRO_finder.Models.DBModel;
using PRO_finder.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PRO_finder.Service
{
    public class WorksService
        {

            public List<Works> getWorkItem()
            {
                using (ProFinderContext context = new ProFinderContext())
                {
                    List<Works> worksList = context.Works.ToList();

                    return worksList;

                }
            }


        }
}