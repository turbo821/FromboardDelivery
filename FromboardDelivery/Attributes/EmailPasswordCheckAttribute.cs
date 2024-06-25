using System;
using System.ComponentModel.DataAnnotations;
using FromboardDelivery.Models;

namespace FromboardDelivery.Attributes
{
    public class EmailPasswordCheckAttribute : ValidationAttribute
    {
        DeliveryContext Context { get; set; }
        public EmailPasswordCheckAttribute(DeliveryContext context) 
        {
            ErrorMessage = "Почта или пароль неверны";
            Context = context;
        }

        public override bool IsValid(object? value)
        {
            Admin? admin = value as Admin;
            if (admin != null)
            {
                Admin? dbAdmin = Context.Admins.FirstOrDefault(a => a.Email == admin.Email && a.Password == admin.Password);
                if (dbAdmin is null) return false;
                
                else return true;
            }
            else return false;
        }
    }
}
