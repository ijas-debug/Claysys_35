using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using System.Security.Policy;

namespace FinalProject.Repository
{
    public class VisaApplication_Repository
    {
        String connectionString = ConfigurationManager.ConnectionStrings["Myconnection"].ToString();



        ///Get All Users <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        public List<VisaApplication> GetAllApplicants()
        {
            List<VisaApplication> ApplicantList = new List<VisaApplication>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SPS_GetAllVisaApplications";
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                DataTable dtUsers = new DataTable();

                connection.Open();
                sqlData.Fill(dtUsers);
                connection.Close();

                foreach (DataRow datarow in dtUsers.Rows)
                {
                    ApplicantList.Add(new VisaApplication
                    {
                        ApplicationID = Convert.ToInt32(datarow["ApplicationID"]),
                        FirstName = datarow["FirstName"].ToString(),
                        LastName = datarow["LastName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(datarow["DateOfBirth"]),
                        EmailID = datarow["EmailID"].ToString(),
                        Phone = datarow["Phone"].ToString(),
                        Address = datarow["Address"].ToString(),
                        ExpectedDateOfArrival = Convert.ToDateTime(datarow["ExpectedDateOfArrival"]),
                        ExpectedDateOfDeparture = Convert.ToDateTime(datarow["ExpectedDateOfDeparture"]),
                        VisaService = datarow["VisaService"].ToString(),
                        Gender = datarow["Gender"].ToString(),
                        TownCityOfBirth = datarow["TownCityOfBirth"].ToString(),
                        CountryOfBirth = datarow["CountryOfBirth"].ToString(),
                        CitizenshipNationalIdNo = datarow["CitizenshipNationalIdNo"].ToString(),
                        Religion = datarow["Religion"].ToString(),
                        EducationalQualification = datarow["EducationalQualification"].ToString(),
                        PassportType = datarow["PassportType"].ToString(),
                        Nationality = datarow["Nationality"].ToString(),
                        PassportNumber = datarow["PassportNumber"].ToString(),
                        PlaceOfIssue = datarow["PlaceOfIssue"].ToString(),
                        DateOfIssue = Convert.ToDateTime(datarow["DateOfIssue"]),
                        DateOfExpiry = Convert.ToDateTime(datarow["DateOfExpiry"]),
                        PassportOrICNo = datarow["PassportOrICNo"].ToString(),
                        PortOfArrival = datarow["PortOfArrival"].ToString(),
                        ReferenceNameInIndia = datarow["ReferenceNameInIndia"].ToString(),
                        ReferenceAddressInIndia = datarow["ReferenceAddressInIndia"].ToString(),
                        ReferencePhone = datarow["ReferencePhone"].ToString(),
                        Photo = datarow["Photo"].ToString(),
                        Status = datarow["Status"].ToString(),
                   
                    });
                }
            }
            return ApplicantList;
        }

        public void UpdateStatus(int applicationId, string status)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SPU_UpdateVisaApplicationStatus";
                command.Parameters.AddWithValue("@ApplicationID", applicationId);
                command.Parameters.AddWithValue("@Status", status);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }



        ///Get All Userss by ID <summary>
        /// Get All Userss by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<VisaApplication> GetApplicantsByID(int id)
        {
            List<VisaApplication> ApplicantList = new List<VisaApplication>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SPS_GetVisaApplicationByID";
                command.Parameters.AddWithValue("@ApplicationID", id);
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                DataTable dtVisaApplications = new DataTable();

                connection.Open();
                sqlData.Fill(dtVisaApplications);
                connection.Close();

                foreach (DataRow datarow in dtVisaApplications.Rows)
                {
                   
                    ApplicantList.Add(new VisaApplication
                    {
                        ApplicationID = Convert.ToInt32(datarow["ApplicationID"]),
                        FirstName = datarow["FirstName"].ToString(),
                        LastName = datarow["LastName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(datarow["DateOfBirth"]),
                        EmailID = datarow["EmailID"].ToString(),
                        Phone = datarow["Phone"].ToString(),
                        Address = datarow["Address"].ToString(),
                        ExpectedDateOfArrival = Convert.ToDateTime(datarow["ExpectedDateOfArrival"]),
                        ExpectedDateOfDeparture = Convert.ToDateTime(datarow["ExpectedDateOfDeparture"]),
                        VisaService = datarow["VisaService"].ToString(),
                        Gender = datarow["Gender"].ToString(),
                        TownCityOfBirth = datarow["TownCityOfBirth"].ToString(),
                        CountryOfBirth = datarow["CountryOfBirth"].ToString(),
                        CitizenshipNationalIdNo = datarow["CitizenshipNationalIdNo"].ToString(),
                        Religion = datarow["Religion"].ToString(),
                        EducationalQualification = datarow["EducationalQualification"].ToString(),
                        PassportType = datarow["PassportType"].ToString(),
                        Nationality = datarow["Nationality"].ToString(),
                        PassportNumber = datarow["PassportNumber"].ToString(),
                        PlaceOfIssue = datarow["PlaceOfIssue"].ToString(),
                        DateOfIssue = Convert.ToDateTime(datarow["DateOfIssue"]),
                        DateOfExpiry = Convert.ToDateTime(datarow["DateOfExpiry"]),
                        PassportOrICNo = datarow["PassportOrICNo"].ToString(),
                        PortOfArrival = datarow["PortOfArrival"].ToString(),
                        ReferenceNameInIndia = datarow["ReferenceNameInIndia"].ToString(),
                        ReferenceAddressInIndia = datarow["ReferenceAddressInIndia"].ToString(),
                        ReferencePhone = datarow["ReferencePhone"].ToString(),
                        Photo = datarow["Photo"].ToString(),
                        Status = datarow["Status"].ToString()
                    });
                }
            }
            return ApplicantList;
        }
        // Update Visa Application
        public bool UpdateVisaApplication(VisaApplication application)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SPU_UpdateVisaApplications", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ApplicationID", application.ApplicationID);
                command.Parameters.AddWithValue("@FirstName", application.FirstName);
                command.Parameters.AddWithValue("@LastName", application.LastName);
                command.Parameters.AddWithValue("@EmailID", application.EmailID);
                command.Parameters.AddWithValue("@Phone", application.Phone);
                command.Parameters.AddWithValue("@Address", application.Address);
                command.Parameters.AddWithValue("@VisaService", application.VisaService);
                command.Parameters.AddWithValue("@CitizenshipNationalIdNo", application.CitizenshipNationalIdNo);
                command.Parameters.AddWithValue("@PassportType", application.PassportType);
                command.Parameters.AddWithValue("@Nationality", application.Nationality);
                command.Parameters.AddWithValue("@PassportNumber", application.PassportNumber);
                command.Parameters.AddWithValue("@PassportOrICNo", application.PassportOrICNo);
                command.Parameters.AddWithValue("@Status", application.Status);
                
                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        ///Delete Product <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteApplicant(int id)
        {
            string result = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SPD_DeleteVisaApplication", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ApplicationID", id);
                command.Parameters.Add("@OUTPUTMESSAGE", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                connection.Open();
                command.ExecuteNonQuery();
                result = command.Parameters["@OUTPUTMESSAGE"].Value.ToString();
                connection.Close();
            }
            return result;
        }

        


    }
}