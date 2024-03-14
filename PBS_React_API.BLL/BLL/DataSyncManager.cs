using PBS_React_API.BLL.Interface;
using PBS_React_API.DAL.DAL;
using PBS_React_API.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBS_React_API.BLL.BLL
{
    public class DataSyncManager : IDataSyncManager
    {
        private readonly IDataSyncRepository _dataRepository;

        public DataSyncManager(IDataSyncRepository dataRepository)
        {

            _dataRepository = dataRepository;
        }
        public DataSet GET_AUTOCOMPLETE_DATA_QUICK()
        {
            try
            {
                DataSet ds = _dataRepository.GET_AUTOCOMPLETE_DATA_QUICK();
                return ds;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable GET_AUTOCOMPLETE_DATA(DataSet ds, string SerText)
        {

            try
            {
                DataTable dt = new DataTable();
                DataView dv = new DataView();
                dv.Table = ds.Tables[0]; ;

                string likeQuery = "'%%'", likeQueryAuthorNameBn = "'%%'", likeQueryPublisherNameBN = "'%%'", likeQueryNameBN = "'%%'", likeQueryKeyword = "'%%'";

                if (!string.IsNullOrEmpty(SerText))
                {
                    var replaceSearchText = SerText.Replace("'", "");
                    var splitData = replaceSearchText.Split(" ");
                    likeQuery = string.Format("'%{0}%'", string.Join("%' AND name LIKE '%", splitData.Where(s => s != "")));
                    likeQueryKeyword = string.Format("'%{0}%'", string.Join("%' AND SearchingKeyword LIKE '%", splitData.Where(s => s != "")));
                    likeQueryNameBN = string.Format("'%{0}%'", string.Join("%' AND NameBN LIKE '%", splitData.Where(s => s != "")));
                    likeQueryAuthorNameBn = string.Format("'%{0}%'", string.Join("%' AND AuthorNameBn LIKE '%", splitData.Where(s => s != "")));
                    likeQueryPublisherNameBN = string.Format("'%{0}%'", string.Join("%' AND PublisherNameBN LIKE '%", splitData.Where(s => s != "")));
                }


                dv.RowFilter = "(name like " + likeQuery + ") or (NameBN like " + likeQueryNameBN + ") or (AuthorNameBn like " + likeQueryAuthorNameBn + ") or (PublisherNameBN like " + likeQueryPublisherNameBN + ") or (SearchingKeyword like " + likeQueryKeyword + ")" ;
               
                if (dv.Count > 0)
                {
                    dt = dv.ToTable().Rows.Cast<System.Data.DataRow>().Take(20).CopyToDataTable();

                }
                else
                {
                    dt = dv.ToTable();
                }



                return dt;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
         public DataTable Get_Search_Data(DataSet ds,string SerText)
        {

            try
            {

                DataView dv = new DataView();
                dv.Table = ds.Tables[0];
                SerText = SerText.Replace("ndprsnt", "&");
                string likeQuery = "'%%'", likeQueryAuthorNameBn = "'%%'", likeQueryPublisherNameBN = "'%%'", likeQueryNameBN = "'%%'", likeQueryKeyword = "'%%'";

                if (!string.IsNullOrEmpty(SerText))
                {
                    var replaceSearchText = SerText.Replace("'", "");
                    var splitData = replaceSearchText.Split(" ");
                    likeQuery = string.Format("'%{0}%'", string.Join("%' AND name LIKE '%", splitData.Where(s => s != "")));
                    likeQueryKeyword = string.Format("'%{0}%'", string.Join("%' AND SearchingKeyword LIKE '%", splitData.Where(s => s != "")));
                    likeQueryNameBN = string.Format("'%{0}%'", string.Join("%' AND NameBN LIKE '%", splitData.Where(s => s != "")));
                    likeQueryAuthorNameBn = string.Format("'%{0}%'", string.Join("%' AND AuthorNameBn LIKE '%", splitData.Where(s => s != "")));
                    likeQueryPublisherNameBN = string.Format("'%{0}%'", string.Join("%' AND PublisherNameBN LIKE '%", splitData.Where(s => s != "")));
                }


                dv.RowFilter = "(name like " + likeQuery + ") or (NameBN like " + likeQueryNameBN + ") or (AuthorNameBn like " + likeQueryAuthorNameBn + ") or (PublisherNameBN like " + likeQueryPublisherNameBN + ") or (SearchingKeyword like " + likeQueryKeyword + ")" ;
               
                return dv.ToTable();


            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
    }
}
