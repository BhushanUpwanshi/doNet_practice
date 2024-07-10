namespace StudentManagement.Models
{
    public class Student
    {
        /*Student_ID
2. Student_Name
3. Student_Email Id
4. Mobile_number
5. Student_Address
6. admission_date
7. fees
8. Status(e.g.Active/Inactive)*/
        public int Student_ID { get; set; }
        public string Student_Name { get; set; }
        public string Student_Email { get; set; }
        public double Mobile_number { get; set; }
        public string Student_Address {  get; set; }
        public DateTime admission_date { get; set; }
        public double fees { get; set; }
        public string status { get; set; }
        /*
         create table Student (Student_ID int Auto_increment, Student_Name varchar(50),
         Student_Email varchar(50),
         Mobile_number double,Student_Address varchar(100),admission_date date,fees double,status varchar(20),
        primary key (Student_ID));
         */

    }
}
