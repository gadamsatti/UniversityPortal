using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UniversityPortal.Models;

namespace UniversityPortal.Helper
{
    public class SuggestionsHelper
    {

        static HttpClient svc = new HttpClient();
        static string baseUrlGrievance = "http://localhost:5003/api/";
        public static async Task<List<SelectListItem>> GetAllGravience()
        {
            List<SelectListItem> graviences = new List<SelectListItem>();
            var ListOfGravience = await svc.GetFromJsonAsync<List<GrievanceModel>>(baseUrlGrievance + "UserGrievance/GetAllGrievanceName");
            foreach (var gravience in ListOfGravience)
            {
                graviences.Add(new SelectListItem { Text = gravience.Type, Value = gravience.GrievanceId.ToString() });
            }
            return graviences;
        }
        public static async Task<List<SelectListItem>> GetAllStatus()
        {
            List<SelectListItem> status = new List<SelectListItem>();
            var ListOfstatusID = await svc.GetFromJsonAsync<List<StatusModel>>(baseUrlGrievance + "UserGrievance/GetAllstatusName");
            foreach (var statusdetails in ListOfstatusID)
            {
                status.Add(new SelectListItem { Text = statusdetails.Status, Value = statusdetails.StatusId.ToString() });
            }
            return status;
        }
    }
}
