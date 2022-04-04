using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

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
        public List<YourSkySearch> GetAllSearchFilter(SearchFilter data)
        {
            List<YourSkySearch> list = new List<YourSkySearch>();
            using (MySqlConnection con = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("YourskySearch", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@course", data.course);
                    cmd.Parameters.AddWithValue("@country", data.country);
                    cmd.Parameters.AddWithValue("@intakes", data.intakes);
                    cmd.Parameters.AddWithValue("@SortColumn", "");
                    cmd.Parameters.AddWithValue("@SortType", "ASC");
                    cmd.Parameters.AddWithValue("@PageNo", data.pageno);
                    cmd.Parameters.AddWithValue("@PageSize", data.pagesize);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            list.Add(new YourSkySearch()
                            {
                                courseid = Convert.ToInt32(dt.Rows[i]["courseid"]),
                                course = dt.Rows[i]["course"].ToString(),
                                after_waiver_fee = dt.Rows[i]["after_waiver_fee"].ToString(),
                                allow_backlogs = dt.Rows[i]["allow_backlogs"].ToString(),
                                application_deadline = dt.Rows[i]["application_deadline"].ToString(),
                                application_fee = dt.Rows[i]["application_fee"].ToString(),
                                application_fee_info = dt.Rows[i]["application_fee_info"].ToString(),
                                apply = dt.Rows[i]["apply"].ToString(),
                                campusid = dt.Rows[i]["campusid"].ToString(),
                                check_list = dt.Rows[i]["check_list"].ToString(),
                                checked_college = dt.Rows[i]["checked_college"].ToString(),
                                cityid = dt.Rows[i]["cityid"].ToString(),
                                clg_commission = dt.Rows[i]["clg_commission"].ToString(),
                                collegeid = dt.Rows[i]["collegeid"].ToString(),
                                college_address = dt.Rows[i]["college_address"].ToString(),
                                college_url = dt.Rows[i]["college_url"].ToString(),
                                commission_detail = dt.Rows[i]["commission_detail"].ToString(),
                                country = dt.Rows[i]["country"].ToString(),
                                countryid = dt.Rows[i]["countryid"].ToString(),
                                country_code = dt.Rows[i]["country_code"].ToString(),
                                course_code = dt.Rows[i]["course_code"].ToString(),
                                course_url = dt.Rows[i]["course_url"].ToString(),
                                dated = dt.Rows[i]["dated"].ToString(),
                                duration = dt.Rows[i]["duration"].ToString(),
                                fee_waiver = dt.Rows[i]["fee_waiver"].ToString(),
                                fee_waiver_message = dt.Rows[i]["fee_waiver_message"].ToString(),
                                intakeid = dt.Rows[i]["intakeid"].ToString(),
                                intakes = dt.Rows[i]["intakes"].ToString(),
                                logo = dt.Rows[i]["logo"].ToString(),
                                keywords = dt.Rows[i]["keywords"].ToString(),
                                mobile_number = dt.Rows[i]["mobile_number"].ToString(),
                                note = dt.Rows[i]["note"].ToString(),
                                notes = dt.Rows[i]["notes"].ToString(),
                                open_intake = dt.Rows[i]["open_intake"].ToString(),
                                open_intakes = dt.Rows[i]["open_intakes"].ToString(),
                                ranking = dt.Rows[i]["ranking"].ToString(),
                                tuition_fee = dt.Rows[i]["tuition_fee"].ToString(),
                                tuition_fee_currency = dt.Rows[i]["tuition_fee_currency"].ToString(),
                                tuition_fee_info = dt.Rows[i]["tuition_fee_info"].ToString()
                                //Country_Id = dt.Rows[i]["Country_Id"].ToString(),
                                //Country_Name = dt.Rows[i]["Country_Name"].ToString(),
                                //Country_Phonecode = dt.Rows[i]["Country_Phonecode"].ToString(),
                                //Country_Sortname = dt.Rows[i]["Country_Sortname"].ToString(),
                                //Country_Currency = dt.Rows[i]["Country_Currency"].ToString(),
                                //Country_Currency_code = dt.Rows[i]["Country_Currency_code"].ToString(),
                                //Country_Currency_symbol = dt.Rows[i]["Country_Currency_symbol"].ToString(),
                                //Country_is_visible = dt.Rows[i]["Country_is_visible"].ToString(),
                                //Intake_Intakeid = dt.Rows[i]["Intake_Intakeid"].ToString(),
                                //Intake_Intake = dt.Rows[i]["Intake_Intake"].ToString(),
                                //Intake_order_wise = dt.Rows[i]["Intake_order_wise"].ToString(),
                                //Intake_season = dt.Rows[i]["Intake_season"].ToString(),
                                //Intake_status = dt.Rows[i]["Intake_status"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
            /* using (MySqlConnection conn = GetConnection())
             {
                 conn.Open();
                 MySqlCommand cmd1 = new MySqlCommand("select * from course", conn);
                 using (var reader = cmd1.ExecuteReader())
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
             } */
            //return list;
        }
        public List<YourSkySearch> GetUniversity()
        {
            List<YourSkySearch> list = new List<YourSkySearch>();
            using (MySqlConnection con = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("YourskyUniversity", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            list.Add(new YourSkySearch()
                            {
                                collegeid = dt.Rows[i]["collegeid"].ToString(),
                                college = dt.Rows[i]["college"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }
        public List<YourSkySearch> GetLocation()
        {
            List<YourSkySearch> list = new List<YourSkySearch>();
            using (MySqlConnection con = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("YourskyLocation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            list.Add(new YourSkySearch()
                            {
                                countryid = dt.Rows[i]["id"].ToString(),
                                country = dt.Rows[i]["name"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }
        public List<YourSkySearch> GetIntakes()
        {
            List<YourSkySearch> list = new List<YourSkySearch>();
            using (MySqlConnection con = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("YourskyIntakes", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            list.Add(new YourSkySearch()
                            {
                                Intake_Intakeid = dt.Rows[i]["intakeid"].ToString(),
                                Intake_Intake = dt.Rows[i]["intake"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }
        public List<YourSkySearch> GetEducationlevel()
        {
            List<YourSkySearch> list = new List<YourSkySearch>();
            using (MySqlConnection con = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("YourskyEducationlevel", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            list.Add(new YourSkySearch()
                            {
                                courseid = int.Parse(dt.Rows[i]["courseid"].ToString()),
                                course = dt.Rows[i]["course"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
