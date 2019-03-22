using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpExam.Models
{
    public class MyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Actvty> Activities {get;set;}
        public DbSet<Participation> Participations {get;set;}
    }

    public class LoginUser
    {
        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}
    }

    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name must only contain letters!")]
        public string FirstName {get;set;}

        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name must only contain letters!")]
        public string LastName {get;set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Password must contain at least 1 letter, 1 number, and 1 special character!")]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        public List<Participation> AttendedActs {get;set;} //The list of Activities that a User is attending
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        [NotMapped]
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirmation")]
        public string Confirm {get;set;}
    }

    public class Actvty
    {
        [Key]
        public int ActivityId {get;set;}

        [Required]
        [MinLength(2, ErrorMessage="Title must be 2 characters or longer!")]
        public string Title {get;set;}

        [Required]
        [MinLength(10, ErrorMessage="Description must be 10 characters or longer!")]
        public string Description {get;set;}

        [Required]
        [FutureDateTime]
        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime ActivityDate {get;set;}

        // [Required]
        // [Display(Name = "Time:")]
        // public DateTime ActivityTime {get;set;}

        [Required]
        [Display(Name = "Duration")]
        public int ActDuration {get;set;}

        [Required]
        public string ActUnit {get;set;}

        public int PlannerId {get;set;} //The UserId of the User (in session) who created the Activity
        public List<Participation> ActivityAttendees {get;set;} //The list of Users who are attending this Activity
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }

    public class FutureDateTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (((DateTime)value) <= DateTime.Now)
            {
                return new ValidationResult("Only dates/times in the future are allowed!");
            }
            return ValidationResult.Success;
        }
    }

    public class Participation
    {
        [Key]
        public int ParticipationId {get;set;}
        public int UserId {get;set;}
        public int ActivityId {get;set;}
        public User User {get;set;}
        public Actvty Activity {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }

    public class IndexViewModel
    {
        public LoginUser LogUser {get;set;}
        public User RegUser {get;set;}
    }
}