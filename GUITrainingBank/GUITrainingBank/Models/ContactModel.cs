/* FileName: ContactModel.cs
Project Name: MvcSendMail
Date Created: 9/15/2014PM
Description: Auto-generated
Version: 1.0.0.0
Author:	Lê Thanh Tuấn - Khoa CNTT
Author Email: tuanitpro@gmail.com
Author Mobile: 0976060432
Author URI: http://tuanitpro.com
License: 

*/
using System.ComponentModel.DataAnnotations;
namespace MvcSendMail.Models
{
    /// <summary>
    /// Contact Model
    /// </summary>
    public class ContactModel
    {
        [Display(Name = "Your Name")]
        [Required(ErrorMessage = "Empty fields Name")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Empty fields Email")]
        [DataType(DataType.EmailAddress, ErrorMessage= "Invalid email")]
        public string Email { get; set; }

        [Display(Name = "Object")]
        [Required(ErrorMessage= "Empty fields Object")]
        public string Subject { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}