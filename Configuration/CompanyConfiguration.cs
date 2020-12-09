using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuggestorCodeFirstAPI.Models;

namespace SuggestorCodeFirstAPI.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
 {
 builder.HasData
 (
 new User
 {
 ID = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
 FirstName = "Sudam",
 LastName = "Yasodya",
 Password = "123",
 DOB = "1996/07/27",
 Address = "N0:198/3, Airport Road, Minuwangoda",
 Email = "gdsudam@gmail.com",
 Contact = "0715510491",
 Role = "Admin"
 },
 new User
 {
     ID = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991871"),
     FirstName = "Sudama",
     LastName = "Yasodyaa",
     Password = "1234",
     DOB = "1996/07/28",
     Address = "N0:198/3, Airport Road, Minuwangoda, Gampaha",
     Email = "gdsudam@gmail.com.com",
     Contact = "0112294169",
     Role = "Customer"
 },
 new User
 {
     ID = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991875"),
     FirstName = "Rasmi",
     LastName = "Duli",
     Password = "123123",
     DOB = "1997/03/31",
     Address = "N0:198/3, Airport Road, Malabe",
     Email = "rasmi@gmail.com",
     Contact = "071556223",
     Role = "ServiceProvider"
 }
 );
 }
}
}
