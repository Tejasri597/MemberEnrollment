
using System;
using System.ComponentModel.DataAnnotations;


namespace MemberEnrollment.Model

{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty.ToString();

        [Required]
        public DateTime Birthdate { get; set; }
    }
}

