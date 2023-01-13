using Dapper;
using Employeemodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL
{
    public class StateRepository
    {
        public List<ContryModel> GetContryList()
        {
            StateCityViewModel list = new StateCityViewModel();
            string sql = "select * from CountryMaster";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var db = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.Text);
                list.ContryModelList = db.Read<ContryModel>().ToList();
            }
            return list.ContryModelList;
        }

        public List<StateModel> GetStateList(int ContryId)
        {
            StateCityViewModel list = new StateCityViewModel();
            string sql = "select * from StateMaster where ContryId ="+ ContryId;
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var db = conn.QueryMultiple(sql, new
                {
                    ContryId = ContryId
                }, commandType: CommandType.Text);
                list.StateModelList = db.Read<StateModel>().ToList();
            }
            return list.StateModelList;
        }

        public List<CityModel> GetCityList(int StateId)
        {
            StateCityViewModel list = new StateCityViewModel();
            string sql = "select * from CityMaster where StateId = "+StateId;
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var db = conn.QueryMultiple(sql, new
                {
                    StateId = StateId
                }, commandType: CommandType.Text) ;
                list.CityModelList = db.Read<CityModel>().ToList();
            }
            return list.CityModelList;
        }
    }
}

