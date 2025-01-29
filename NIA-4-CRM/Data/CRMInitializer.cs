using Microsoft.EntityFrameworkCore;
using NIA_4_CRM.Models;
using System;
using System.Diagnostics;

namespace NIA_4_CRM.Data
{
    public class CRMInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CrmContext(
                serviceProvider.GetRequiredService<DbContextOptions<CrmContext>>()))
            {
                try
                {
                    // Seed IndustryTypes
                    if (!context.IndustryTypes.Any())
                    {
                        context.IndustryTypes.AddRange(
                            new IndustryType
                            {
                                IndustryTypeId = 1,
                                Name = "Technology"
                            },
                            new IndustryType
                            {
                                IndustryTypeId = 2,
                                Name = "Healthcare"
                            },
                            new IndustryType
                            {
                                IndustryTypeId = 3,
                                Name = "Finance"
                            },
                            new IndustryType
                            {
                                IndustryTypeId = 4,
                                Name = "Education"
                            },
                            new IndustryType
                            {
                                IndustryTypeId = 5,
                                Name = "Manufacturing"
                            },
                            new IndustryType
                            {
                                IndustryTypeId = 6,
                                Name = "Retail"
                            }
                        );
                        context.SaveChanges();
                    }

                    // Seed Membership Types
                    if (!context.MembershipTypes.Any())
                    {
                        context.MembershipTypes.AddRange(
                            new MembershipType
                            {
                                MembershipTypeId = 1, 
                                MembershipName = "Associate" 
                            },
                            new MembershipType 
                            { 
                                MembershipTypeId = 2, 
                                MembershipName = "Local Industrial" 
                            },
                            new MembershipType 
                            { 
                                MembershipTypeId = 3, 
                                MembershipName = "Non-Local Industrial" 
                            },
                            new MembershipType 
                            { 
                                MembershipTypeId = 4, 
                                MembershipName = "Government & Education, Associate" 
                            },
                            new MembershipType 
                            { 
                                MembershipTypeId = 5, 
                                MembershipName = "Chamber, Associate"
                            }
                        );
                        context.SaveChanges();
                    }

                    // Seed Organizations for Niagara Region, Ontario, Canada
                    if (!context.Organizations.Any())
                    {
                        context.Organizations.AddRange(
                            new Organization
                            {
                                Id = 1,
                                OrgName = "Niagara Region",
                                Website = "https://www.niagararegion.ca",
                                Email = "info@niagararegion.ca",
                                PhoneNumber = "+1-905-682-9201",
                                StreetAddress = "1815 Sir Isaac Brock Way",
                                City = "Thorold",
                                StateProvince = "Ontario",
                                PostalCode = "L2V 4T7",
                                DOI = DateTime.Parse("1970-01-01"),
                                IndustryTypeId = 5 // Government
                            },
                            new Organization
                            {
                                Id = 2,
                                OrgName = "Niagara College Canada",
                                Website = "https://www.niagaracollege.ca",
                                Email = "admissions@niagaracollege.ca",
                                PhoneNumber = "+1-905-735-2211",
                                StreetAddress = "300 Woodlawn Road",
                                City = "Welland",
                                StateProvince = "Ontario",
                                PostalCode = "L3C 7L3",
                                DOI = DateTime.Parse("1967-04-01"),
                                IndustryTypeId = 4 // Education
                            },
                            new Organization
                            {
                                Id = 3,
                                OrgName = "Peninsula Ridge Estate Winery",
                                Website = "https://www.peninsulridge.com",
                                Email = "info@peninsulridge.com",
                                PhoneNumber = "+1-905-563-6900",
                                StreetAddress = "5606 King Street West",
                                City = "Beamsville",
                                StateProvince = "Ontario",
                                PostalCode = "L0R 1B2",
                                DOI = DateTime.Parse("2000-01-01"),
                                IndustryTypeId = 6 // Hospitality
                            },
                            new Organization
                            {
                                Id = 4,
                                OrgName = "Niagara Health",
                                Website = "https://www.niagarahealth.on.ca",
                                Email = "contact@niagarahealth.on.ca",
                                PhoneNumber = "+1-905-378-4647",
                                StreetAddress = "1200 Fourth Avenue",
                                City = "St. Catharines",
                                StateProvince = "Ontario",
                                PostalCode = "L2S 0A9",
                                DOI = DateTime.Parse("2000-01-01"),
                                IndustryTypeId = 2 // Healthcare
                            },
                            new Organization
                            {
                                Id = 5,
                                OrgName = "Marotta Control Systems",
                                Website = "https://www.marotta.ca",
                                Email = "info@marotta.ca",
                                PhoneNumber = "+1-905-643-4700",
                                StreetAddress = "3755 North Service Road",
                                City = "Lincoln",
                                StateProvince = "Ontario",
                                PostalCode = "L0R 1B6",
                                DOI = DateTime.Parse("1967-01-01"),
                                IndustryTypeId = 1 // Manufacturing
                            },
                            new Organization
                            {
                                Id = 6,
                                OrgName = "Niagara Parks Commission",
                                Website = "https://www.niagaraparks.com",
                                Email = "info@niagaraparks.com",
                                PhoneNumber = "+1-905-356-2241",
                                StreetAddress = "7400 Portage Road",
                                City = "Niagara Falls",
                                StateProvince = "Ontario",
                                PostalCode = "L2E 6T2",
                                DOI = DateTime.Parse("1885-01-01"),
                                IndustryTypeId = 4 // Public sector
                            },
                            new Organization
                            {
                                Id = 7,
                                OrgName = "Fallsview Casino Resort",
                                Website = "https://www.fallsviewcasinoresort.com",
                                Email = "info@fallsviewcasinoresort.com",
                                PhoneNumber = "+1-888-325-5788",
                                StreetAddress = "6380 Fallsview Boulevard",
                                City = "Niagara Falls",
                                StateProvince = "Ontario",
                                PostalCode = "L2G 7X5",
                                DOI = DateTime.Parse("2004-06-10"),
                                IndustryTypeId = 6 // Entertainment
                            },
                            new Organization
                            {
                                Id = 8,
                                OrgName = "Niagara Region Public Health",
                                Website = "https://www.niagararegion.ca/health",
                                Email = "publichealth@niagararegion.ca",
                                PhoneNumber = "+1-905-688-8248",
                                StreetAddress = "1815 Sir Isaac Brock Way",
                                City = "Thorold",
                                StateProvince = "Ontario",
                                PostalCode = "L2V 4T7",
                                DOI = DateTime.Parse("1965-01-01"),
                                IndustryTypeId = 2 // Healthcare
                            },
                            new Organization
                            {
                                Id = 9,
                                OrgName = "The Niagara Farmers Market",
                                Website = "https://www.niagarafarmersmarket.com",
                                Email = "contact@niagarafarmersmarket.com",
                                PhoneNumber = "+1-905-682-1325",
                                StreetAddress = "3430 Portage Road",
                                City = "Niagara Falls",
                                StateProvince = "Ontario",
                                PostalCode = "L2J 2K9",
                                DOI = DateTime.Parse("1963-06-01"),
                                IndustryTypeId = 6 // Retail
                            },
                            new Organization
                            {
                                Id = 10,
                                OrgName = "Niagara Wine Festival",
                                Website = "https://www.niagarawinefestival.com",
                                Email = "info@niagarawinefestival.com",
                                PhoneNumber = "+1-905-688-0212",
                                StreetAddress = "8 King Street",
                                City = "St. Catharines",
                                StateProvince = "Ontario",
                                PostalCode = "L2R 3J2",
                                DOI = DateTime.Parse("1951-01-01"),
                                IndustryTypeId = 6 // Events & Festivals
                            },
                            new Organization
                            {
                                Id = 11,
                                OrgName = "Niagara College Teaching Winery",
                                Website = "https://www.niagaracollege.ca/wine",
                                Email = "winery@niagaracollege.ca",
                                PhoneNumber = "+1-905-641-2252",
                                StreetAddress = "135 Taylor Road",
                                City = "Niagara-on-the-Lake",
                                StateProvince = "Ontario",
                                PostalCode = "L0S 1J0",
                                DOI = DateTime.Parse("2001-04-01"),
                                IndustryTypeId = 6 // Winery
                            },
                            new Organization
                            {
                                Id = 12,
                                OrgName = "Ontario Power Generation",
                                Website = "https://www.opg.com",
                                Email = "contact@opg.com",
                                PhoneNumber = "+1-877-448-9766",
                                StreetAddress = "700 University Avenue",
                                City = "Toronto",
                                StateProvince = "Ontario",
                                PostalCode = "M5G 1X6",
                                DOI = DateTime.Parse("1999-01-01"),
                                IndustryTypeId = 1 // Energy
                            },
                            new Organization
                            {
                                Id = 13,
                                OrgName = "The Brock University",
                                Website = "https://www.brocku.ca",
                                Email = "admissions@brocku.ca",
                                PhoneNumber = "+1-905-688-5550",
                                StreetAddress = "500 Glenridge Avenue",
                                City = "St. Catharines",
                                StateProvince = "Ontario",
                                PostalCode = "L2S 3A1",
                                DOI = DateTime.Parse("1964-01-01"),
                                IndustryTypeId = 4 // Education
                            },
                            new Organization
                            {
                                Id = 14,
                                OrgName = "Niagara Falls Bridge Commission",
                                Website = "https://www.niagarafallsbridgecommission.com",
                                Email = "info@niagarafallsbridgecommission.com",
                                PhoneNumber = "+1-905-354-7431",
                                StreetAddress = "3500 Portage Road",
                                City = "Niagara Falls",
                                StateProvince = "Ontario",
                                PostalCode = "L2J 3P6",
                                DOI = DateTime.Parse("1938-07-01"),
                                IndustryTypeId = 5 // Government
                            },
                            new Organization
                            {
                                Id = 15,
                                OrgName = "The Rainbow Bridge",
                                Website = "https://www.niagarafallsbridge.com",
                                Email = "info@niagarafallsbridge.com",
                                PhoneNumber = "+1-905-354-7424",
                                StreetAddress = "Bridge Entrance",
                                City = "Niagara Falls",
                                StateProvince = "Ontario",
                                PostalCode = "L2E 6T2",
                                DOI = DateTime.Parse("1941-11-01"),
                                IndustryTypeId = 5 // Infrastructure
                            }
                        );
                        context.SaveChanges();
                    }


                    // Seed Contacts for Niagara Region, Ontario, Canada
                    if (!context.Contacts.Any())
                    {
                        context.Contacts.AddRange(
                            new Contact
                            {
                                ID = 1,
                                FirstName = "John",
                                LastName = "Tory",
                                Phone = "+1-905-682-9201",
                                Email = "john.tory@niagararegion.ca",
                                DOB = DateTime.Parse("1970-05-15"),
                                PostalCode = "L2V 4T7"
                            },
                            new Contact
                            {
                                ID = 2,
                                FirstName = "Dr. Sarah",
                                LastName = "James",
                                Phone = "+1-905-735-2211",
                                Email = "sarah.james@niagaracollege.ca",
                                DOB = DateTime.Parse("1980-11-01"),
                                PostalCode = "L3C 7L3"
                            },
                            new Contact
                            {
                                ID = 3,
                                FirstName = "Martin",
                                LastName = "Sullivan",
                                Phone = "+1-905-563-6900",
                                Email = "martin.sullivan@peninsulridge.com",
                                DOB = DateTime.Parse("1975-02-25"),
                                PostalCode = "L0R 1B2"
                            },
                            new Contact
                            {
                                ID = 4,
                                FirstName = "Dr. Emma",
                                LastName = "Morris",
                                Phone = "+1-905-378-4647",
                                Email = "emma.morris@niagarahealth.on.ca",
                                DOB = DateTime.Parse("1975-08-12"),
                                PostalCode = "L2S 0A9"
                            },
                            new Contact
                            {
                                ID = 5,
                                FirstName = "Stephen",
                                LastName = "Harper",
                                Phone = "+1-905-643-4700",
                                Email = "stephen.harper@marotta.ca",
                                DOB = DateTime.Parse("1965-07-25"),
                                PostalCode = "L0R 1B6"
                            },
                            new Contact
                            {
                                ID = 6,
                                FirstName = "Michelle",
                                LastName = "Jones",
                                Phone = "+1-905-356-2241",
                                Email = "michelle.jones@niagaraparks.com",
                                DOB = DateTime.Parse("1982-03-10"),
                                PostalCode = "L2E 6T2"
                            },
                            new Contact
                            {
                                ID = 7,
                                FirstName = "Jake",
                                LastName = "Smith",
                                Phone = "+1-888-325-5788",
                                Email = "jake.smith@fallsviewcasinoresort.com",
                                DOB = DateTime.Parse("1990-01-01"),
                                PostalCode = "L2G 7X5"
                            },
                            new Contact
                            {
                                ID = 8,
                                FirstName = "Linda",
                                LastName = "Parker",
                                Phone = "+1-905-688-8248",
                                Email = "linda.parker@niagararegion.ca",
                                DOB = DateTime.Parse("1977-05-03"),
                                PostalCode = "L2V 4T7"
                            },
                            new Contact
                            {
                                ID = 9,
                                FirstName = "David",
                                LastName = "Allen",
                                Phone = "+1-905-682-1325",
                                Email = "david.allen@niagarafarmersmarket.com",
                                DOB = DateTime.Parse("1984-09-22"),
                                PostalCode = "L2J 2K9"
                            },
                            new Contact
                            {
                                ID = 10,
                                FirstName = "Rachel",
                                LastName = "Watson",
                                Phone = "+1-905-688-0212",
                                Email = "rachel.watson@niagarawinefestival.com",
                                DOB = DateTime.Parse("1985-12-11"),
                                PostalCode = "L2R 3J2"
                            },
                            new Contact
                            {
                                ID = 11,
                                FirstName = "Chris",
                                LastName = "Thompson",
                                Phone = "+1-905-641-2252",
                                Email = "chris.thompson@niagaracollege.ca",
                                DOB = DateTime.Parse("1988-07-18"),
                                PostalCode = "L0S 1J0"
                            },
                            new Contact
                            {
                                ID = 12,
                                FirstName = "Jason",
                                LastName = "Miller",
                                Phone = "+1-877-448-9766",
                                Email = "jason.miller@opg.com",
                                DOB = DateTime.Parse("1973-11-05"),
                                PostalCode = "M5G 1X6"
                            },
                            new Contact
                            {
                                ID = 13,
                                FirstName = "Angela",
                                LastName = "White",
                                Phone = "+1-905-688-5550",
                                Email = "angela.white@brocku.ca",
                                DOB = DateTime.Parse("1980-06-20"),
                                PostalCode = "L2S 3A1"
                            },
                            new Contact
                            {
                                ID = 14,
                                FirstName = "Michael",
                                LastName = "Johnson",
                                Phone = "+1-905-354-7431",
                                Email = "michael.johnson@niagarafallsbridgecommission.com",
                                DOB = DateTime.Parse("1960-09-11"),
                                PostalCode = "L2J 3P6"
                            },
                            new Contact
                            {
                                ID = 15,
                                FirstName = "Patricia",
                                LastName = "Davies",
                                Phone = "+1-905-354-7424",
                                Email = "patricia.davies@niagarafallsbridge.com",
                                DOB = DateTime.Parse("1975-04-15"),
                                PostalCode = "L2E 6T2"
                            }
                        );
                        context.SaveChanges();
                    }


                    // Seed Members for Niagara Region, Ontario, Canada
                    if (!context.Members.Any())
                    {
                        context.Members.AddRange(
                            new Member
                            {
                                OrganizationId = 1,  // Niagara Region Government Organization
                                ContactID = 1,  // John Tory
                                MembershipTypeId = 1,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 1, 1),
                                MembershipRenewDate = new DateTime(2023, 1, 1)
                            },
                            new Member
                            {
                                OrganizationId = 2,  // Niagara College
                                ContactID = 2,  // Dr. Sarah James
                                MembershipTypeId = 2,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 6, 1),
                                MembershipRenewDate = new DateTime(2023, 6, 1)
                            },
                            new Member
                            {
                                OrganizationId = 3,  // Peninsula Ridge Estates Winery
                                ContactID = 3,  // Martin Sullivan
                                MembershipTypeId = 2,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 4, 15),
                                MembershipRenewDate = new DateTime(2023, 4, 15)
                            },
                            new Member
                            {
                                OrganizationId = 4,  // Niagara Health System
                                ContactID = 4,  // Dr. Emma Morris
                                MembershipTypeId = 2,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 5, 10),
                                MembershipRenewDate = new DateTime(2023, 5, 10)
                            },
                            new Member
                            {
                                OrganizationId = 5,  // Marotta Winery
                                ContactID = 5,  // Stephen Harper
                                MembershipTypeId = 1,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 7, 20),
                                MembershipRenewDate = new DateTime(2023, 7, 20)
                            },
                            new Member
                            {
                                OrganizationId = 6,  // Niagara Parks Commission
                                ContactID = 6,  // Michelle Jones
                                MembershipTypeId = 3,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 8, 1),
                                MembershipRenewDate = new DateTime(2023, 8, 1)
                            },
                            new Member
                            {
                                OrganizationId = 7,  // Fallsview Casino Resort
                                ContactID = 7,  // Jake Smith
                                MembershipTypeId = 5,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 10, 5),
                                MembershipRenewDate = new DateTime(2023, 10, 5)
                            },
                            new Member
                            {
                                OrganizationId = 8,  // Niagara Region Chamber of Commerce
                                ContactID = 8,  // Linda Parker
                                MembershipTypeId = 3,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 9, 10),
                                MembershipRenewDate = new DateTime(2023, 9, 10)
                            },
                            new Member
                            {
                                OrganizationId = 9,  // Niagara Farmers Market
                                ContactID = 9,  // David Allen
                                MembershipTypeId = 4,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 3, 1),
                                MembershipRenewDate = new DateTime(2023, 3, 1)
                            },
                            new Member
                            {
                                OrganizationId = 10,  // Niagara Wine Festival
                                ContactID = 10,  // Rachel Watson
                                MembershipTypeId = 4,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 11, 5),
                                MembershipRenewDate = new DateTime(2023, 11, 5)
                            },
                            new Member
                            {
                                OrganizationId = 11,  // Brock University
                                ContactID = 11,  // Chris Thompson
                                MembershipTypeId = 1,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 2, 20),
                                MembershipRenewDate = new DateTime(2023, 2, 20)
                            },
                            new Member
                            {
                                OrganizationId = 12,  // Ontario Power Generation
                                ContactID = 12,  // Jason Miller
                                MembershipTypeId = 2,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 5, 5),
                                MembershipRenewDate = new DateTime(2023, 5, 5)
                            },
                            new Member
                            {
                                OrganizationId = 13,  // Brock University
                                ContactID = 13,  // Angela White
                                MembershipTypeId = 3,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 7, 15),
                                MembershipRenewDate = new DateTime(2023, 7, 15)
                            },
                            new Member
                            {
                                OrganizationId = 14,  // Niagara Falls Bridge Commission
                                ContactID = 14,  // Michael Johnson
                                MembershipTypeId = 2,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 6, 25),
                                MembershipRenewDate = new DateTime(2023, 6, 25)
                            },
                            new Member
                            {
                                OrganizationId = 15,  // Niagara Falls Bridge Commission
                                ContactID = 15,  // Patricia Davies
                                MembershipTypeId = 3,  // Membership Type 
                                MembershipStartDate = new DateTime(2022, 8, 15),
                                MembershipRenewDate = new DateTime(2023, 8, 15)
                            }
                        );
                        context.SaveChanges();
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.GetBaseException().Message);
                }
            }
        }
    }
}
