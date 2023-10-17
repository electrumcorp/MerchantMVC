using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchantMVC.Repositories.Base;
using MerchantMVC.Models;
using MerchantMVC.ViewModels;
namespace MerchantMVC.Repositories
{
    public class PermissionRepository: Repository<Permission>,IPermissionRepository
    {
        private readonly EbaseDBContext ebaseDBContext = null;
        public PermissionRepository(EbaseDBContext context): base(context)
        {
            ebaseDBContext = context;
        }

        public UserLoginModel AuthenticateUser(string username,string password)
        {
            UserLoginModel userModel = null;
            int id =0;

            
            Permission permissionMdl = null;
            Employee emp = null;
            try
            {
                permissionMdl = ebaseDBContext.Permissions.Where(u => u.UserName.Equals(username) && u.Password.Equals(password)).SingleOrDefault();
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

            }
            //permissionMdl=ebaseDBContext.Permissions.Where(u => u.UserName.Equals(username) && u.Password.Equals(password)).SingleOrDefault(); ;
            if (permissionMdl != null)
            {
                id = (int)permissionMdl.Id;
                if (id!=0)
                {
                    //string strId = id.ToString();
                    //if(strId.Length>4)
                    //{
                    //    id = Convert.ToInt32(strId.Substring(strId.Length - 4));
                    //}
                }
                userModel = new UserLoginModel();

                userModel.IsValidUser = true;
                userModel.username = permissionMdl.UserName;
                userModel.CategoryId = (int)permissionMdl.CategoryId;
                userModel.Id =(int) permissionMdl.Id;
               
                 emp = ebaseDBContext.Employees.Where(c => c.Id == (int)permissionMdl.Id).FirstOrDefault();
                if(emp!=null)
                {
                    userModel.EmployeeId = emp.EmployeeId;
                    userModel.FullName = string.Concat(emp.FirstName,' ',emp.LastName);

                }
                Category catMdl = ebaseDBContext.Categories.Where(ct => ct.CategoryId == permissionMdl.CategoryId).FirstOrDefault();
                userModel.CategoryName = catMdl.CategoryName;
                userModel.CategoryId = catMdl.CategoryId;
                switch (catMdl.CategoryId)
                {
                    case 57://merchant
                            {

                                var us = ebaseDBContext.Merchants.Where(l => l.MerchantId == id)
                                    .SingleOrDefault();
                                if (string.IsNullOrEmpty(userModel.FullName))
                                {
                                    userModel.FullName = string.Concat(us.MFname, " ", us.MLname);
                                }

                                userModel.LocationID = us.MerchantId;
                                break;
                            }
                    case 58://location
                        {

                            var us = ebaseDBContext.Locations.Where(l => l.LocationId == id)
                                .SingleOrDefault();
                            if(string.IsNullOrEmpty(userModel.FullName))
                            {
                                userModel.FullName = string.Concat(us.LFname, " ", us.LLname);
                            }
                            
                            userModel.LocationID = us.LocationId;
                            break;
                        }
                }
            }
           
            return userModel;

        }
    }
}
