using DAL;
using Newtonsoft.Json;
using System;
namespace ContactsJSON.Models
{

    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; } = DateTime.Now;
        public int TownId { get; set; } = 0;

        [JsonIgnore] // pour ne pas inclure ce membre dans les enregistrements du fichier Contact.json
        public string Town
        {
            get
            {
                if (TownId == 0)
                    return "Inconnue";
                else
                    return DB.Towns.Get(TownId).Name;
            }
        }

        [JsonIgnore]
        public bool IsBirthDay
        {
            get
                {
                return (Birth.Day == DateTime.Now.Day && Birth.Month == DateTime.Now.Month);
            }
        }

        const string Avatars_Folder = @"/App_Assets/Contacts/";
        const string Default_Avatar = @"no_avatar.png";
        [ImageAsset(Avatars_Folder, Default_Avatar)]
        public string Avatar { get; set; } = Avatars_Folder + Default_Avatar;
    }
}