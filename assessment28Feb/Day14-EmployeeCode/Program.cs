namespace OopsDemo
{
    public enum VDepartment
    {
        Accounts,Sales,IT
    }
    #region person-class
    class Person
    {
        //data members
        string personname = string.Empty;//never make a data member public
        //data member is also called field

        //methods
        public void SetName(string name)
        {
            personname = name;
        }
        public void GetName()
        {
            Console.WriteLine($"{personname}");
        }

        //PROPERTIES\\


        private int age;

        public int Age
        {
            get { return age; }
            set { 
                if(value>0 && value <100) { age = value; }

            }
        }
        //autoimplemented property
        public int Mobile { get; set; }
        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }


    }
#endregion
    #region partial class
    //partial class Person : Object
    //{
    //    public void Display2()
    //    {
    //        Console.WriteLine("Display2");
    //    }
    //}
    #endregion
    internal class Employee
    {
        int id;
        public void SetId(int id)
        {
            this.id = id;
        }
        public void GetId()
        {
            Console.WriteLine($"ID:{id}");
        }

        public string Name { get; set; }
        private VDepartment department;
        public VDepartment Department { get; set; }
        private int salary;
        
        public int Salary
        {
            get { return salary; }
            set { 
                if(value>50000 && value < 90000)
                salary = value; }
        }



    }
    internal class Program 
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.Name = "Nitin";
            emp.Salary = 75000;
            emp.SetId(101);
            emp.GetId();
            emp.Department = VDepartment.Sales;
            Console.WriteLine($"Employee Name: {emp.Name}");
            Console.WriteLine($"Salary: {emp.Salary}");
            Console.WriteLine($"Department: {emp.Department}");
            

            
        }
    }
}
