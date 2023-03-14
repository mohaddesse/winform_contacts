using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WinFormMyContact.Repository
{
    internal interface IContactRepositoy
    {
        DataTable SellectAll();
        DataTable SellectRow(int ContactID);
        DataTable Search(string Parameter);
        bool Insert(string FName, string Lname,string Mobile,string Email,int Age);
        bool Update(int ContactID,string FName, string Lname, string Mobile, string Email, int Age);
        bool Delete(int ContactID);

    }
}
