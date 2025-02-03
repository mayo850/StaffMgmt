using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GrantStaffManagement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ppulate Grant Dropdown on page load
                GrantDropdown.DataSource = PopulateGrantDropdown();
                GrantDropdown.DataBind();
            }
        }

        protected void GrantDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //enable Staff Active Dropdown when a grant is selected
            StaffActiveDropdown.Enabled = true;
        }

        protected void StaffActiveDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //populate Staff List based on selected grant and staff active status
            string grantName = GrantDropdown.SelectedValue;
            string staffActiveStatus = StaffActiveDropdown.SelectedValue;

            StaffList.DataSource = PopulateStaffList(grantName, staffActiveStatus);
            StaffList.DataBind();
        }

        protected void StaffList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string staffName = StaffList.SelectedValue;
            string grantName = GrantDropdown.SelectedValue;

            var staffDetails = GetStaffDetails(staffName, grantName);

            NameField.Text = staffDetails["StaffName"];
            StartDateField.Text = staffDetails["StartDate"];
            EndDateField.Text = staffDetails["EndDate"];
            EmailField.Text = staffDetails["Email"];
            CertificationDateField.Text = staffDetails["CertificationDate"];
        }

        private Dictionary<string, string> GetStaffDetails(string staffName, string grantName)
        {
            Dictionary<string, string> staffDetails = new Dictionary<string, string>();

            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GrantStaffDB"].ConnectionString))
            {
                connection.Open();
                string query = @"
                    SELECT s.StaffName, sga.StartDate, sga.EndDate, s.Email, s.CertificationDate 
                    FROM Staff s
                    JOIN StaffGrantAssignment sga ON s.StaffID = sga.StaffID
                    JOIN GrantInfo g ON sga.GrantID = g.GrantID
                    WHERE s.StaffName = @StaffName AND g.GrantName = @GrantName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StaffName", staffName);
                    command.Parameters.AddWithValue("@GrantName", grantName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            staffDetails["StaffName"] = reader["StaffName"].ToString();
                            staffDetails["StartDate"] = reader["StartDate"].ToString();
                            staffDetails["EndDate"] = reader["EndDate"] == DBNull.Value ? "Active" : reader["EndDate"].ToString();
                            staffDetails["Email"] = reader["Email"].ToString();
                            staffDetails["CertificationDate"] = reader["CertificationDate"].ToString();
                        }
                    }
                }
            }

            return staffDetails;
        }

        //db helper mmethods
        private List<string> PopulateGrantDropdown()
        {
            List<string> grants = new List<string>();

            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GrantStaffDB"].ConnectionString))
            {
                connection.Open();
                string query = "SELECT GrantName FROM GrantInfo";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            grants.Add(reader["GrantName"].ToString());
                        }
                    }
                }
            }

            return grants;
        }

        private List<string> PopulateStaffList(string grantName, string staffActiveStatus)
        {
            List<string> staffList = new List<string>();

            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GrantStaffDB"].ConnectionString))
            {
                connection.Open();
                string query = @"
                    SELECT s.StaffName 
                    FROM Staff s
                    JOIN StaffGrantAssignment sga ON s.StaffID = sga.StaffID
                    JOIN GrantInfo g ON sga.GrantID = g.GrantID
                    WHERE g.GrantName = @GrantName 
                      AND (@StaffActiveStatus = 'Yes' AND sga.EndDate IS NULL 
                           OR @StaffActiveStatus = 'No' AND sga.EndDate IS NOT NULL)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GrantName", grantName);
                    command.Parameters.AddWithValue("@StaffActiveStatus", staffActiveStatus);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            staffList.Add(reader["StaffName"].ToString());
                        }
                    }
                }
            }

            return staffList;
        }
    }
}