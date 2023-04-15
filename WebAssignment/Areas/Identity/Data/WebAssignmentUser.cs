using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebAssignment.Areas.Identity.Data;

// Add profile data for application users by adding properties to the WebAssignmentUser class
public class WebAssignmentUser : IdentityUser
{


    public int UsernameChangeLimit { get; set; } = 10;

    public byte[]? ProfilePicture;
  


}

