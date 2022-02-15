using MaterialTestTracker.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MaterialTestTracker
{
    class DataBaseHelper
    {
        private readonly MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;" +
                "username=root;password=;database=construction_material_test_tracker");

        public void InputData(MainInfoOfReportModel report)
        {
            connection.Open();

            string day, month, year;
            day = report.Date.ToString().Substring(0, 2);
            month = report.Date.ToString().Substring(3, 2);
            year = report.Date.ToString().Substring(6, 4);
            string date = year + "." + month + "." + day;

            MySqlCommand command = new MySqlCommand("INSERT INTO `basic_data`(`protocol_number`," +
                " `laboratory_manager`, `material`, `indicators`, `customer`, `number_of_contract`, `date`) "
                + $"VALUES ({report.ProtocolNumber}, '{report.FirstAndSecondName}', '{report.Material}', '{report.Indicators}'," +
                $" '{report.Customer}', '{report.NumberOfContractWithCustomer}', '{date}')", connection);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public Dictionary<string, string> GetData(MainInfoOfReportModel report)
        {
            connection.Open();

            MySqlCommand command1 = new MySqlCommand("SELECT `protocol_number`, `laboratory_manager`, `material`," +
                    " `indicators`, `customer`, `number_of_contract`, `date`" +
                $" FROM `basic_data` WHERE `protocol_number` = {report.ProtocolNumber}", connection);

            MySqlDataReader reader = command1.ExecuteReader();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (reader.Read())
            {
                dictionary.Add("protocol", reader[0].ToString());
                dictionary.Add("name", reader[1].ToString());
                dictionary.Add("material", reader[2].ToString());
                dictionary.Add("indicators", reader[3].ToString());
                dictionary.Add("customer", reader[4].ToString());
                dictionary.Add("contract", reader[5].ToString());
                dictionary.Add("date", reader[6].ToString());
            }

            connection.Close();

            return dictionary;
        }
    }
}
