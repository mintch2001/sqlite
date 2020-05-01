using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;


namespace SQL1
{
    class DataAccess
    {
      public static void CreateTable ()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=customers.db")) //เชื่อมต่อกับไฟล์ DataBase
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " + //สร้างตารางขึ้นมาหากยังไม่มี
                                      "EXISTS customers (Number INTEGER," + //ตารางชื่อ customers โดนในตารางจะมีฟิลด์ที่ชื่อ Number เเละ Name
                                      "Name NVACHAR(50) NULL)";

                SqliteCommand sqliteCommand = new SqliteCommand(tableCommand, db);
                sqliteCommand.ExecuteReader();
            }
        }
        public static void AddData(string inputText)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=customers.db")) //เชื่อมต่อกับไฟล์ DataBase
            {
                db.Open();

                SqliteCommand sqliteCommand = new SqliteCommand();
                sqliteCommand.Connection = db; //เชื่อมค่อ Command เข้ากับไฟล์ DataBase ที่เราตั้งไว้

                sqliteCommand.CommandText = "INSERT INTO customers VALUES (1, @Name)"; //ทำการใส่ข้อมูลลงไปในตารางที่ชื่อว่า customers
                sqliteCommand.Parameters.AddWithValue("@Name", inputText); //ไว้สำหรับรับข้อมูลที่ผู้ใช้ต้องกรอก
                //เติม @ เพื่อไม่ให้คำสั่ง SQL ที่ผู้ใช้กรอกเข้ามาทำงานเพื่อป้องกันผู้ไม่หวังดี

                sqliteCommand.ExecuteReader();

                db.Close();
            }
        }
        public static List<string> ShowDetail()
        {
            List<string> data = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=customers.db"))
            {
                db.Open();

                SqliteCommand Name = new SqliteCommand("SELECT Name from customers",db); //ทำการหยิบข้อมูลที่อยู่ในช่อง Name ออกมา
                SqliteCommand Number = new SqliteCommand("SELECT Number from customers", db); //ทำการหยิบข้อมูลที่อยู่ในช่อง Number ออกมา

                //ทำการแปลงข้อมูลที่หยิบออกมาให้สามารถนำไปใช้ต่อได้
                SqliteDataReader nameData = Name.ExecuteReader(); 
                SqliteDataReader NumberData = Number.ExecuteReader();

                // Read() จะทำการส่งค่่า True กลับมาในกรณีที่ยังมีเเถวเหลืออยู่ และจะกลายเป็น False เมื่อบนนณทัดนั้นว่าง
                while (nameData.Read() && NumberData.Read())
                {
                    data.Add(NumberData.GetString(0) + " " + nameData.GetString(0));
                }
                db.Close();
            }
            return data;
        }
    
    }
}
