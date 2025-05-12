using System;

namespace MusicLibraryBackend.Models
{
    public class PersonalInformation
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int UserModelId { get; set; }
        public UserModel User { get; set; }
    }
} 