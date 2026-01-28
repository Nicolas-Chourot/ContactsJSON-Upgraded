using System.Reflection;
using System.Web.Hosting;
using ContactsJSON.Models;

namespace DAL
{
    public sealed class DB
    {
        #region singleton setup
        private static readonly DB instance = new DB();
        public static DB Instance  { get { return instance; } }
        #endregion

        public static Repository<Contact> Contacts { get; set; } = new Repository<Contact>();
        public static Repository<Town> Towns { get; set; } = new Repository<Town>();

    }
}