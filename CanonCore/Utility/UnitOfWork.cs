using CanonCore.Database;
//using CanonCore;
//using CanonCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CanonCore.Utility
{

    public class UnitOfWork //: IDisposable
    {
        //create object of UoW in Page_load in (!ispostback) 
        //dispose UoW in Page_Unload
        //for each table create repository and make property for this Repo in UoW (this class)
        #region declarations

        private CanonDBEntities context = new CanonDBEntities();
        //private IHR_lkp_PenaltiesTypesRepo _PenaltiesTypesRepository;
        //private GenericRepository<Sec_lkp_Permissions> _PermissionsRepository;
       

        //private GenericRepository<HR_SalaryComponents_Penalties> _HR_SalaryComponents_PenaltiesRepository;



    

        private bool disposed = false;

        #endregion



        //public IModulesRepo ModulesRepository
        //{
        //    get
        //    {

        //        if (this._ModulesRepository == null)
        //        {
        //            this._ModulesRepository = new ModulesRepo(context);
        //        }
        //        return _ModulesRepository;
        //    }
        //}
 
        //public GenericRepository<HR_lkp_Nationality> HR_lkp_NationalityRepository
        //{
        //    get
        //    {

        //        if (this._HR_lkp_NationalityRepository == null)
        //        {
        //            this._HR_lkp_NationalityRepository = new GenericRepository<HR_lkp_Nationality>(context);
        //        }
        //        return _HR_lkp_NationalityRepository;
        //    }
        //}
       

    }

}
