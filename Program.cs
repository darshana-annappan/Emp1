using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace EmployeeApplication
{
    public class Employee
    {
        public static int EmployeeCount;
        List<string> EmployeeId = new List<string>();
        List<string> EmployeeName = new List<string>();
        List<DateTime> DateOfJoining = new List<DateTime>();
        List<DateTime> DateOfBirth = new List<DateTime>();
        List<string> Email = new List<string>();
        List<string> PhoneNumber = new List<string>();

        //To get employee details.
        void GetDetails()
        {
            Console.WriteLine("How many employee do you want to add?");
            EmployeeCount = int.Parse(Console.ReadLine());
            if (EmployeeCount < 10)
            {
                for (int Index = EmployeeId.Count; Index < EmployeeCount; Index++)
                {
                    Console.WriteLine("Enter employee name {0}", Index + 1);
                    EmployeeName.Add(Console.ReadLine());
                    ValidateName(EmployeeName, Index);
                    Console.WriteLine("Enter employee id {0}", Index + 1);
                    EmployeeId.Add(Console.ReadLine());
                    ValidateId(EmployeeId, Index);
                    Console.WriteLine("Enter employee Date of Birth {0}", Index + 1);
                    DateOfBirth.Add(Convert.ToDateTime(Console.ReadLine()));
                    ValidateDateOfBirth(DateOfBirth, Index);
                    Console.WriteLine("Enter employee Date of Joining {0}", Index + 1);
                    DateOfJoining.Add(Convert.ToDateTime(Console.ReadLine()));
                    ValidateDateOfJoining(DateOfJoining, Index);
                    Console.WriteLine("Enter phone number {0}", Index + 1);
                    PhoneNumber.Add(Console.ReadLine());
                    ValidatePhoneNumber(PhoneNumber, Index);
                    Console.WriteLine("Enter email address {0}", Index + 1);
                    Email.Add(Console.ReadLine());
                    ValidateEmail(Email, Index);
                    Console.WriteLine("***Added Sucessfully****");
                }
            }
            else
            {
                Console.WriteLine("You can add upto 10 employee details");
                GetDetails();
            }
            Choice();

        }

        //Validating Name
        public void ValidateName(List<string> Name, int Index)
        {
            string CheckName = @"[A-Z]{1}[a-zA-z\s]{3,}";
            Regex IsNameValid = new Regex(CheckName);
            if (IsNameValid.IsMatch(Name[Index]))
            {
                //return 0;
            }
            else
            {
                Console.WriteLine("Name must be alphabets.It should have 3 or more charactore");
                Console.WriteLine("Re-enter your Name");
                Name[Index] = Console.ReadLine();
                ValidateName(Name, Index);
            }
        }
        //Validating Employee Id
        public void ValidateId(List<string> Id, int Index)
        {
            string CheckId = @"[ACE]{1}[1-9]{1}[0-9]{3}$";
            Regex IsIdValid = new Regex(CheckId);
            if (IsIdValid.IsMatch(Id[Index]))
            {

            }
            else
            {
                Console.WriteLine("please check your id.Id must start with ACE followed by four digits\n It should not be zero !!");
                Console.WriteLine("Re-enter your Id");
                Id[Index] = Console.ReadLine();
                ValidateId(Id, Index);
            }


        }
        //Validating Employee's date of birth
        public void ValidateDateOfBirth(List<DateTime> DateBirth, int Index)
        {
            int Age;
            Age = DateTime.Now.Subtract(DateBirth[Index]).Days;
            Age = Age / 365;
            if (Age > 18)
            {

            }
            else
            {
                Console.WriteLine("Enter a Valid Date of birth eg:DD/MM/YYYY");
                Console.WriteLine("Re-enter your date of birth ");
                DateBirth[Index] = Convert.ToDateTime(Console.ReadLine());
                ValidateDateOfBirth(DateBirth, Index);
            }


        }
        //Validating date of joining
        public void ValidateDateOfJoining(List<DateTime> DateOfJoining, int Index)
        {
            if (DateOfJoining[Index] < DateTime.Now)
            {

            }
        }
        // Validating Employee's phone number

        public void ValidatePhoneNumber(List<string> Number, int Index)
        {
            string CheckPhoneNumber = "^[6-9]{1}[0-9]{9}$";
            Regex IsValidPhoneNumber = new Regex(CheckPhoneNumber);
            if (IsValidPhoneNumber.IsMatch(Number[Index]))
            {

            }
            else
            {
                Console.WriteLine("Please check your number!.Phone should begin with 6,7,8 and 9 and It should exactly 10 digits.");
                Console.WriteLine("Re-enter your Phone number");
                Number[Index] = Console.ReadLine();
                ValidatePhoneNumber(Number, Index);
            }

        }
        //Validating Employee's Email
        public void ValidateEmail(List<string> Mail, int Index)
        {
            string CheckEmail = "^[a-zA-Z0-9_%.]+@[a-z]+[.][a-z]{2,}$";
            Regex IsValidEmail = new Regex(CheckEmail);
            if (IsValidEmail.IsMatch(Mail[Index]))
            {

            }
            else
            {
                Console.WriteLine("Please check your mail id!  ");
                Mail[Index] = Console.ReadLine();
                ValidateEmail(Mail, Index);
            }


        }
        public void DisplayDetails()
        {
            if (EmployeeCount == 0)
            {
                Console.WriteLine("Please Add employee details!!!");
            }
            for (int Index = 0; Index < EmployeeId.Count; Index++)
            {
                if (EmployeeId[Index] != " ")
                {
                    Console.WriteLine("EmployeeName  {0}:{1}", Index + 1, EmployeeName[Index]);
                    Console.WriteLine("EmployeeId  {0}:{1}", Index + 1, EmployeeId[Index]);
                    Console.WriteLine("DateOfBirth:{0}", DateOfBirth[Index]);
                    Console.WriteLine("DateOfJoining:{0}", DateOfJoining[Index]);
                    Console.WriteLine("PhoneNumber:{0}", PhoneNumber[Index]);
                    Console.WriteLine("Email:{0}", Email[Index]);

                }
            }
            Choice();

        }
        void UpdateDetails()
        {
            if (EmployeeCount == 0)
            {
                Console.WriteLine("Please add employee details");
            }
            else
            {
                Console.WriteLine("Enter the employee Id that you want to update");
                string UserId = Console.ReadLine();

                for (int Index = 0; Index < EmployeeCount; Index++)
                {


                    if (EmployeeId[Index] == UserId)
                    {
                        Console.WriteLine("1.Update Name \n 2.Update DOB \n 3.Update DOJ \n 4.Update Email \n 5.Update Phone number");
                        Console.WriteLine("Enter your choice");
                        int choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                UpdateName(Index);
                                break;
                            case 2:
                                UpdateDOB(Index);
                                break;
                            case 3:
                                UpdateDOJ(Index);
                                break;
                            case 4:
                                UpdateEmail(Index);
                                break;
                            case 5:
                                UpdatePhoneNumber(Index);
                                break;

                            default:
                                Console.WriteLine("Please enter valid choice 1-5");
                                UpdateDetails();
                                break;
                        }


                    }
                }
            }


        }
        void DeleteDetails()
        {
            int CheckId = 1;
            Console.WriteLine("Enter Id which you want to delete");
            string DeleteId = Console.ReadLine();
            for (int Delete = 0; Delete < EmployeeCount; Delete++)
            {
                if (EmployeeId[Delete] == DeleteId)
                {
                    EmployeeId.RemoveAt(Delete);
                    EmployeeName.RemoveAt(Delete);
                    PhoneNumber.RemoveAt(Delete);
                    Email.RemoveAt(Delete);
                    DateOfBirth.RemoveAt(Delete);
                    DateOfJoining.RemoveAt(Delete);
                    Console.WriteLine("****Deleted Sucessfully***");
                    break;
                }



                else
                {
                    CheckId = 0;
                }


                if (CheckId == 0)
                {
                    Console.WriteLine("Please check your Id!!");
                    DeleteDetails();
                }
            }
            Choice();



        }
        void ReadDetails()
        {
            int CheckId = 0;
            string UserChoiceId;

            UserChoiceId = Console.ReadLine();

            for (int Index = 0; Index < EmployeeCount; Index++)
            {

                if (EmployeeId[Index] == UserChoiceId)
                {
                    CheckId = 1;
                    Console.WriteLine("EmployeeName  {0}:{1}", Index + 1, EmployeeName[Index]);
                    Console.WriteLine("EmployeeId  {0}:{1}", Index + 1, EmployeeId[Index]);
                    Console.WriteLine("DateOfBirth {0}:{1}", Index + 1, DateOfBirth[Index]);

                    Console.WriteLine("DateOfJoining{0}:{1}", Index + 1, DateOfJoining[Index]);
                    Console.WriteLine("PhoneNumber:{0}", PhoneNumber[Index]);
                    Console.WriteLine("Email:{0}", Email[Index]);
                    break;


                }


                else
                {
                    CheckId = 0;
                }
            }

            if (CheckId == 0)
            {
                Console.WriteLine("Please check your Id!!!");
                ReadDetails();
            }


            Choice();

        }
        void UpdateName(int Index)
        {
            for (; Index < EmployeeCount; Index++)
            {
                EmployeeName[Index] = Console.ReadLine();
                ValidateName(EmployeeName, Index);
                Console.WriteLine("***Updated Sucessfully****");

            }
            Choice();

        }
        void UpdateDOB(int Index)
        {
            for (; Index < EmployeeCount; Index++)
            {
                DateOfBirth[Index] = Convert.ToDateTime(Console.ReadLine());
                ValidateDateOfBirth(DateOfBirth, Index);
                Console.WriteLine("***Updated Sucessfully****");
            }
            Choice();

        }
        void UpdateDOJ(int Index)
        {
            for (; Index < EmployeeCount; Index++)
            {
                DateOfJoining[Index] = Convert.ToDateTime(Console.ReadLine());
                ValidateDateOfJoining(DateOfJoining, Index);
                Console.WriteLine("***Updated Sucessfully****");

            }
            Choice();

        }
        void UpdateEmail(int Index)
        {
            for (; Index < EmployeeCount; Index++)
            {
                Email[Index] = Console.ReadLine();
                ValidateEmail(Email, Index);
                Console.WriteLine("***Updated Sucessfully****");


            }
            Choice();

        }
        void UpdatePhoneNumber(int Index)
        {
            for (; Index < EmployeeCount; Index++)
            {
                PhoneNumber[Index] = Console.ReadLine();
                ValidatePhoneNumber(PhoneNumber, Index);
                Console.WriteLine("***Updated Sucessfully****");

            }
            Choice();

        }
        public void Choice()
        {
            Console.WriteLine("1.Add employee details \n 2.Display employee details \n 3.Update employee details \n 4.Delete employee details \n 5.Read Employee Details \n 6.Exit");
            Console.WriteLine("Pease enter your choice");
            Console.WriteLine("========================");
            int UserChoice = int.Parse(Console.ReadLine());
            switch (UserChoice)
            {
                case 1:
                    GetDetails();
                    break;
                case 2:
                    DisplayDetails();
                    break;
                case 3:
                    UpdateDetails();
                    break;
                case 4:
                    DeleteDetails();
                    break;
                case 5:
                    ReadDetails();
                    break;
                case 6:
                    Console.WriteLine("**Employee apllication closed successfully!!***");
                    break;

                default:
                    Console.WriteLine("Please enter valid choice 1-6");
                    Choice();
                    break;
            }
        }
    }

    class Program

    {
        public static void Main(string[] args)
        {
            //Creating object for Employee class
            Employee employee = new Employee();
            employee.Choice();
        }
    }
}