using Datalayer.INTERFACE;
using DOT.VIEW_MODEL;
using ENTITIES.DBCONTEXT;
using ENTITIES.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.d_CLASS
{
    public class Datalayer_class : IDatalayer
    {
        private readonly dbcontext _dbcontext;
        public Datalayer_class(dbcontext dbContext)
        {
            _dbcontext = dbContext;
        }
        public  async Task<object> GET()
        {
           /* var Get_Details =   _dbcontext.TBM_regiter.ToList();
            var Get_details1 = _dbcontext.TBM_Regiter_STUD.ToList();*/
            var result =( from ans in _dbcontext.TBM_regiter
                         join anss in _dbcontext.TBM_Regiter_STUD on
                         ans.R_ID equals anss.stud_ID
                         select new View
                         {
                             E_ID=anss.E_ID,
                             stud_ID=anss.stud_ID,
                             Gender=anss.Gender,
                             NAME=ans.NAME,
                             Address=ans.Address,
                             Age=ans.Age,
                             PH_number=ans.PH_number,
                             R_ID=ans.R_ID

                         }).ToList();
           
                 return result;
        }
        public  async Task<object> POST(View details)
        {
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    var post = new regiter()
                    {
                        NAME = details.NAME,
                        Age = details.Age,
                        Address = details.Address,
                        PH_number = details.PH_number,
                        R_ID = details.R_ID,
                    };
                      _dbcontext.TBM_regiter.Add(post);
                    _dbcontext.SaveChanges();
                    var emp = new Regiter_STUD()
                    {
                       stud_ID=details.stud_ID,
                        E_ID = details.E_ID,
                        Gender= details.Gender,
                        R_ID = post.R_ID,
                     };
                  
                    _dbcontext.TBM_Regiter_STUD.Add(emp); 
                    _dbcontext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
            return details;
         }
        public async Task<object> PUT(View   details)
        {
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    var put =  _dbcontext.TBM_regiter.Find(details.R_ID);
                    if (put != null)
                    {
                        put.NAME = details.NAME;
                        put.Age = details.Age;
                        put.Address = details.Address;
                        put.PH_number = details.PH_number;
                        _dbcontext.SaveChanges();
                    }
                    var put1 =  _dbcontext.TBM_Regiter_STUD.Find(details.stud_ID);
                    if (put1 != null)
                    {

                        put1.E_ID = details.E_ID;
                        put1.Gender = details.Gender;

                        _dbcontext.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                }
            }
            return details;
        }
        public async Task<object> DELETE(int id)
        {
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    var put = _dbcontext.TBM_Regiter_STUD.Find(id);
                    if (put != null)
                    {
                        _dbcontext.Remove(put);
                        _dbcontext.SaveChanges();
                       
                    }
                    var put1 = _dbcontext.TBM_regiter.Find(id);
                    if (put1 != null)
                    {

                        _dbcontext.Remove(put1);
                        _dbcontext.SaveChanges();
                       
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                }
            }
            return  id;
            
        }
      

    }
}
