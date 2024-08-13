using System;
using System.Net.Mail;

namespace Module33.AuthenticationService.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public bool FromRussia { get; set; }

        public UserViewModel(User user)
        {
            Id = user.Id;
            FullName = GetFullName(user.Name, user.SurName);
            FromRussia = GetFromRussiaValue(user.Email);
        }


        public string GetFullName(string firstName, string lastName)
        {
            return string.Concat(firstName, " ", lastName);
        }

        public bool GetFromRussiaValue(string email)
        {
            MailAddress mailAddress = new MailAddress(email);

            if (mailAddress.Host.Contains(".ru"))
                return true;
            return false;
        }
    }
}
