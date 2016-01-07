using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using RegulesViaje.Models;
using RegulesViaje.DataBaseContext;

namespace RegulesViaje.Controllers
{
    public abstract class RepositoryController : Controller
    {
        #region Private/protected fields

        //protected readonly IRepositoryContainer _repository;
        protected DataContext db = new DataContext();

        #endregion

        
        #region Constructor

        //protected RepositoryController()
        //{
            //_repository = RepositorySesssion.GetRepository(size, repositoryKey);
        //}

        #endregion


        #region Country actions

        [HttpPost]
        public JsonResult CountryList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                //Thread.Sleep(200);
                //var studentCount = _repository.StudentRepository.GetStudentCount();
                //var students = _repository.StudentRepository.GetStudents(jtStartIndex, jtPageSize, jtSorting);
                
                /*
                 var countryList = from c in db.Countries
                                  select c;
                 */

                //IEnumerable<Country> query = db.Countries.ToList();

                //Filters
                /*if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(p => p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                if (id > 0)
                {
                    query = query.Where(p => p.Id == id);
                }*/

                // Take the count of Country items after filter
                //int countryCount = query.Count();

                //Sorting
                //This ugly code is used just for demonstration.
                //Normally, Incoming sorting text can be directly appended to an SQL query.
                /*if (string.IsNullOrEmpty(jtSorting) || jtSorting.Equals("Name ASC"))
                {
                    query = query.OrderBy(p => p.Name);
                }
                else if (jtSorting.Equals("Name DESC"))
                {
                    query = query.OrderByDescending(p => p.Name);
                }
                else
                {
                    query = query.OrderBy(p => p.Name); //Default!
                }

                List<Country> countriesToReturn =  jtPageSize > 0
                    ? query.Skip(jtStartIndex).Take(jtPageSize).ToList() //Paging
                    : query.ToList(); //No paging
                */

                var countriesToReturn = db.Countries.Where(c => c.Name != "");
                int countryCount = countriesToReturn.Count();

                return Json(new { Result = "OK", Records = countriesToReturn.ToList(), TotalRecordCount = countryCount });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        #endregion

    }
}