using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace YourSky.Models
{
    public class SearchContext
    {
        public string ConnectionString { get; set; }
        public SearchContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<YourSkySearch> GetAllAlbums()
        {
            List<YourSkySearch> list = new List<YourSkySearch>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from course", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new YourSkySearch()
                        {
                            courseid = Convert.ToInt32(reader["courseid"]),
                            course = reader["course"].ToString(),
                            after_waiver_fee = reader["after_waiver_fee"].ToString(),
                            allow_backlogs = reader["allow_backlogs"].ToString(),
                            application_deadline = reader["application_deadline"].ToString(),
                            application_fee = reader["application_fee"].ToString(),
                            application_fee_info = reader["application_fee_info"].ToString(),
                            apply = reader["apply"].ToString(),
                            campusid = reader["campusid"].ToString(),
                            check_list = reader["check_list"].ToString(),
                            checked_college = reader["checked_college"].ToString(),
                            cityid = reader["cityid"].ToString(),
                            clg_commission = reader["clg_commission"].ToString(),
                            collegeid = reader["collegeid"].ToString(),
                            college_address = reader["college_address"].ToString(),
                            college_url = reader["college_url"].ToString(),
                            commission_detail = reader["commission_detail"].ToString(),
                            country = reader["country"].ToString(),
                            countryid = reader["countryid"].ToString(),
                            country_code = reader["country_code"].ToString(),
                            course_code = reader["course_code"].ToString(),
                            course_url = reader["course_url"].ToString(),
                            dated = reader["dated"].ToString(),
                            duration = reader["duration"].ToString(),
                            fee_waiver = reader["fee_waiver"].ToString(),
                            fee_waiver_message = reader["fee_waiver_message"].ToString(),
                            intakeid = reader["intakeid"].ToString(),
                            intakes = reader["intakes"].ToString(),
                            logo = reader["logo"].ToString(),
                            keywords = reader["keywords"].ToString(),
                            mobile_number = reader["mobile_number"].ToString(),
                            note = reader["note"].ToString(),
                            notes = reader["notes"].ToString(),
                            open_intake = reader["open_intake"].ToString(),
                            open_intakes = reader["open_intakes"].ToString(),
                            ranking = reader["ranking"].ToString(),
                            tuition_fee = reader["tuition_fee"].ToString(),
                            tuition_fee_currency = reader["tuition_fee_currency"].ToString(),
                            tuition_fee_info = reader["tuition_fee_info"].ToString()
                            //Country_Id = reader["Country_Id"].ToString(),
                            //Country_Name = reader["Country_Name"].ToString(),
                            //Country_Phonecode = reader["Country_Phonecode"].ToString(),
                            //Country_Sortname = reader["Country_Sortname"].ToString(),
                            //Country_Currency = reader["Country_Currency"].ToString(),
                            //Country_Currency_code = reader["Country_Currency_code"].ToString(),
                            //Country_Currency_symbol = reader["Country_Currency_symbol"].ToString(),
                            //Country_is_visible = reader["Country_is_visible"].ToString(),
                            //Intake_Intakeid = reader["Intake_Intakeid"].ToString(),
                            //Intake_Intake = reader["Intake_Intake"].ToString(),
                            //Intake_order_wise = reader["Intake_order_wise"].ToString(),
                            //Intake_season = reader["Intake_season"].ToString(),
                            //Intake_status = reader["Intake_status"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
