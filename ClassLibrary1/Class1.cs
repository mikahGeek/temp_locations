using DotNetNuke.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using Accretive.Common.Caching;


namespace ClassLibrary1
{
    public class Class1
    {

        public Class1()
        {
            DotNetNuke.Services.Cache.FBCachingProvider cacheInstance = new DotNetNuke.Services.Cache.FBCachingProvider();
            DotNetNuke.ComponentModel.ComponentFactory.Container = new DotNetNuke.ComponentModel.SimpleContainer();
            DotNetNuke.ComponentModel.ComponentFactory.RegisterComponentInstance<DotNetNuke.Services.Cache.CachingProvider>(cacheInstance);
        }


        public List<Accretive_Locations> GetList()
        {
            string CacheKey = "Accretive.IDM.AccretiveLocations.CacheTable";
            var TempDataTable = new DataTable();

            if (DataCache.GetCache(CacheKey) == null)
            {
                IDataReader dr = (IDataReader)SqlHelper.ExecuteReader("", CommandType.StoredProcedure, "[dbo].[usp_LocationsList]");
                TempDataTable.Load(dr);
                DataCache.SetCache(CacheKey, TempDataTable, CacheObject.GetTimeSpan(CacheObject.CacheLevel.Medium));
            }

            var temp = (DataTable)DataCache.GetCache(CacheKey);
            var collection = (List<Accretive_Locations>)CBO.FillCollection<Accretive_Locations>(temp.CreateDataReader());

            if (temp.Rows.Count == 0)
                AppCache.ClearCache(CacheKey);

            return collection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<Accretive_Locations> GetList_1()
        {
            string CacheKey = "Accretive.IDM.AccretiveLocations.CacheTable";
            DataTable cached = (DataTable)DataCache.GetCache(CacheKey);
            if (cached == null)
            {
                IDataReader dr = (IDataReader)SqlHelper.ExecuteReader("", CommandType.StoredProcedure, "[dbo].[usp_LocationsList]");
                cached = new DataTable();
                cached.Load(dr);
                DataCache.SetCache(CacheKey, cached, CacheObject.GetTimeSpan(CacheObject.CacheLevel.Medium));
            }
            var collection = (List<Accretive_Locations>)CBO.FillCollection<Accretive_Locations>(cached.CreateDataReader());

            if (cached.Rows.Count == 0)
            {
                AppCache.ClearCache(CacheKey);
            }
            return collection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<Accretive_Locations> GetList_2()
        {
            string CacheKey = "Accretive.IDM.AccretiveLocations.CacheTableEx";
            var collection = (List<Accretive_Locations>)DataCache.GetCache(CacheKey);

            if (collection == null || collection.Count == 0)
            {
                // Remove Cache based on Cache Key
                AppCache.ClearCache(CacheKey);
                //Retrieve the Data and place into cache
                IDataReader dr = (IDataReader)SqlHelper.ExecuteReader("", CommandType.StoredProcedure, "[dbo].[usp_LocationsList]");
                DataTable cached = new DataTable();
                cached.Load(dr);
                collection = (List<Accretive_Locations>)CBO.FillCollection<Accretive_Locations>(cached.CreateDataReader());
                DataCache.SetCache(CacheKey, collection, TimeSpan.FromSeconds(120));
            }
            return collection;
        }

    }
}
